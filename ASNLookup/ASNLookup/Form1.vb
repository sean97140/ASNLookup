﻿' Copyright 2015 Sean Mahan
' Licensed under "GPL 2.0" license


Imports System.IO
Imports System.Net



Public Class Form1
    Dim ipRangeToASN As New Dictionary(Of String, Integer)
    Dim ASNToOwner As New Dictionary(Of Integer, String)
    Dim OwnerToASNs As New Dictionary(Of String, List(Of Integer))
    Dim ASNToIPRange As New Dictionary(Of Integer, List(Of String))
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadASNTables()
    End Sub
    Private Sub LoadASNTables()
        'http://quaxio.com/bgp/ much credit deserved for finding this method
        LoadAndBuildIpRangeToASNTable()
        LoadAndBuildASNToOwnerTable()
        BuildOwnerToASNsTable()
    End Sub
    Private Sub LoadAndBuildIpRangeToASNTable()
        Dim ipRangeToASNDataFile As String = "data-raw-table.txt"
        Dim ipRangeBinaryReader As BinaryReader
        Dim appData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

        Try
            ipRangeBinaryReader = New BinaryReader(System.IO.File.OpenRead(ipRangeToASNDataFile))
        Catch ex As Exception
            MsgBox("No ASN data file found, please wait while it is downloaded. File size 10mb")
            My.Computer.Network.DownloadFile("http://thyme.apnic.net/current/data-raw-table", "data-raw-table.txt")
            ipRangeBinaryReader = New BinaryReader(System.IO.File.OpenRead(ipRangeToASNDataFile))
        End Try

        Dim ipRangeBinaryData As Byte() = ipRangeBinaryReader.ReadBytes(ipRangeBinaryReader.BaseStream.Length)
        Dim ms As MemoryStream = New MemoryStream(ipRangeBinaryData, 0, ipRangeBinaryData.Length)
        Dim ipRangeDataFileReader As New System.IO.StreamReader(ms)
        Dim TextLine As String = ""
        Dim ipRange As String
        Dim asn As Integer = -1

        Do While ipRangeDataFileReader.Peek() <> -1
            TextLine = ipRangeDataFileReader.ReadLine()
            ipRange = TextLine.Split()(0)
            asn = ConvertStringToInt(TextLine.Split()(1))
            ipRangeToASN.Add(ipRange, asn)


            If ASNToIPRange.ContainsKey(asn) Then
                Dim ipRangeList As List(Of String) = ASNToIPRange.Item(asn)
                ipRangeList.Add(ipRange)
            Else
                Dim ipRangeList As New List(Of String)
                ipRangeList.Add(ipRange)
                ASNToIPRange.Add(asn, ipRangeList)
            End If
        Loop

        ipRangeDataFileReader.Close()
    End Sub
    Private Sub LoadAndBuildASNToOwnerTable()
        Dim ASNToOwnerDataFile As String = "data-used-autnums.txt"
        Dim asnOwnerBinaryReader As BinaryReader
        Dim appData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim installPath As String = appData + "\DMCA Preventer"

        Try
            asnOwnerBinaryReader = New BinaryReader(System.IO.File.OpenRead(ASNToOwnerDataFile))
        Catch ex As Exception
            MsgBox("No ASN to Owner data file found, please wait while it is downloaded. File size 2mb")
            My.Computer.Network.DownloadFile("http://thyme.apnic.net/current/data-used-autnums", "data-used-autnums.txt")
            asnOwnerBinaryReader = New BinaryReader(System.IO.File.OpenRead(ASNToOwnerDataFile))
        End Try

        Dim asnOwnerBinaryData As Byte() = asnOwnerBinaryReader.ReadBytes(asnOwnerBinaryReader.BaseStream.Length)
        Dim ms2 As MemoryStream = New MemoryStream(asnOwnerBinaryData, 0, asnOwnerBinaryData.Length)
        Dim ASNToOwnerDataFileReader As New System.IO.StreamReader(ms2)
        Dim ownerParts As String()
        Dim owner As String = ""
        Dim TextLine As String = ""
        Dim asn As Integer = -1

        Do While ASNToOwnerDataFileReader.Peek() <> -1
            owner = ""
            TextLine = ASNToOwnerDataFileReader.ReadLine().ToString().Trim()
            ownerParts = TextLine.Split()
            For i As Integer = 1 To ownerParts.Length - 1
                owner = owner + " " + ownerParts(i)
            Next

            asn = ConvertStringToInt(TextLine.Split()(0))
            ASNToOwner.Add(asn, owner.Trim())
        Loop

        ASNToOwnerDataFileReader.Close()
    End Sub

    Private Sub BuildOwnerToASNsTable()
        For Each i As Integer In ASNToOwner.Keys()
            Dim owner1 As String = ASNToOwner.Item(i)
            If OwnerToASNs.ContainsKey(owner1) Then
                Dim asnList As List(Of Integer) = OwnerToASNs.Item(owner1)
                asnList.Add(i)
            Else
                Dim asnList As New List(Of Integer)
                asnList.Add(i)
                OwnerToASNs.Add(owner1, asnList)
            End If
        Next

    End Sub
    Public Shared Function ConvertStringToInt(inputString As String) As Integer
        Try
            Return Convert.ToInt32(inputString)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Function GetASNumber(ipAddress As String) As String
        'http://www.unixwiz.net/techtips/netmask-ref.html
        'http://quaxio.com/bgp/ much credit deserved for finding this method

        Dim ipAddressArray As String() = ipAddress.Split(".")
        Dim matchWasFound As Boolean = False
        Dim asnNum As Integer = -1
        Dim ipRangeString As String = ""

        For maskBits As Integer = 0 To 32 Step 1
            If maskBits <= 8 Then
                Dim firstPrefix As Integer = ConvertStringToInt(ipAddressArray(3))
                firstPrefix = (firstPrefix >> maskBits) << maskBits
                ipAddressArray(3) = firstPrefix.ToString
            ElseIf maskBits <= 16 Then
                Dim secondPrefix As Integer = ConvertStringToInt(ipAddressArray(2))
                secondPrefix = (secondPrefix >> maskBits - 8) << maskBits - 8
                ipAddressArray(2) = secondPrefix.ToString
            ElseIf maskBits <= 24 Then
                Dim thirdPrefix As Integer = ConvertStringToInt(ipAddressArray(1))
                thirdPrefix = (thirdPrefix >> maskBits - 16) << maskBits - 16
                ipAddressArray(1) = thirdPrefix.ToString
            ElseIf maskBits <= 32 Then
                Dim fourthPrefix As Integer = ConvertStringToInt(ipAddressArray(0))
                fourthPrefix = (fourthPrefix >> maskBits - 24) << maskBits - 24
                ipAddressArray(0) = fourthPrefix.ToString
            End If

            ipRangeString = String.Join(".", ipAddressArray) + "/" + (32 - maskBits).ToString()

            If ipRangeToASN.ContainsKey(ipRangeString) Then
                asnNum = ipRangeToASN.Item(ipRangeString)
                matchWasFound = True
                Exit For
            Else
                matchWasFound = False
            End If
        Next

        If matchWasFound Then
            Return asnNum.ToString + " " + ipRangeString
        Else
            Return -1
        End If

    End Function

    Private Sub GetASNButton_Click(sender As Object, e As EventArgs) Handles GetASNButton.Click
        Dim ASNIPRange As String = GetASNumber(ipAddressInput.Text)
        Dim ASN As Integer = ASNIPRange.Split(" ")(0)
        Dim Range As String = ASNIPRange.Split(" ")(1)
        Dim Owner As String = ASNToOwner.Item(ASN)
        Dim OtherASNsList As List(Of Integer) = OwnerToASNs.Item(Owner)
        Dim OtherAsnRangeString As String = " <"
        Dim msgString As String = Owner + " with a range of: " + Range + " and an ASN of: " + ASN.ToString

        If otherASNs.Checked Then
            For Each i In OtherASNsList
                If ASNToIPRange.ContainsKey(i) Then
                    Dim ipRangeList As List(Of String) = ASNToIPRange.Item(i)
                    For Each s In ipRangeList
                        If s <> Range Then
                            OtherAsnRangeString += "> <" + i.ToString + " " + s
                        End If
                    Next
                Else
                    OtherAsnRangeString += "> <" + i.ToString + " missing range"
                End If
            Next

            OtherAsnRangeString += ">"
            msgString += " with other ASN/Ranges: " + OtherAsnRangeString
        End If

        MsgBox(msgString)
    End Sub
    Private Function GetIPAddress() As String
        Dim wc As New WebClient
        Dim ipExternal As String

        Try
            ipExternal = wc.DownloadString("http://ipv4.icanhazip.com")
        Catch ex1 As Exception
            Return "0.0.0.0"
        End Try

        Return ipExternal
    End Function

    Private Sub getIPAddressButton_Click(sender As Object, e As EventArgs) Handles getIPAddressButton.Click
        ipAddressInput.Text = GetIPAddress()
    End Sub
End Class

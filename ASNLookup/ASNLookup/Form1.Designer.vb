<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1

    ' Copyright 2015 Sean Mahan
    ' Licensed under the "GPL 2.0" license

    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GetASNButton = New System.Windows.Forms.Button()
        Me.ipAddressInput = New System.Windows.Forms.TextBox()
        Me.otherASNs = New System.Windows.Forms.CheckBox()
        Me.getIPAddressButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.GetASNButton.Location = New System.Drawing.Point(75, 62)
        Me.GetASNButton.Name = "Button1"
        Me.GetASNButton.Size = New System.Drawing.Size(54, 23)
        Me.GetASNButton.TabIndex = 0
        Me.GetASNButton.Text = "Lookup"
        Me.GetASNButton.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.ipAddressInput.Location = New System.Drawing.Point(12, 12)
        Me.ipAddressInput.Name = "TextBox1"
        Me.ipAddressInput.Size = New System.Drawing.Size(117, 20)
        Me.ipAddressInput.TabIndex = 1
        '
        'otherASNs
        '
        Me.otherASNs.AutoSize = True
        Me.otherASNs.Location = New System.Drawing.Point(12, 39)
        Me.otherASNs.Name = "otherASNs"
        Me.otherASNs.Size = New System.Drawing.Size(112, 17)
        Me.otherASNs.TabIndex = 2
        Me.otherASNs.Text = "Show other ASN's"
        Me.otherASNs.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.getIPAddressButton.Location = New System.Drawing.Point(12, 61)
        Me.getIPAddressButton.Name = "Button2"
        Me.getIPAddressButton.Size = New System.Drawing.Size(57, 24)
        Me.getIPAddressButton.TabIndex = 3
        Me.getIPAddressButton.Text = "My IP"
        Me.getIPAddressButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(143, 93)
        Me.Controls.Add(Me.getIPAddressButton)
        Me.Controls.Add(Me.otherASNs)
        Me.Controls.Add(Me.ipAddressInput)
        Me.Controls.Add(Me.GetASNButton)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "ASN Lookup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GetASNButton As System.Windows.Forms.Button
    Friend WithEvents ipAddressInput As System.Windows.Forms.TextBox
    Friend WithEvents otherASNs As System.Windows.Forms.CheckBox
    Friend WithEvents getIPAddressButton As System.Windows.Forms.Button

End Class

# ASNLookup

Take any IP address and get the associated ASN, Owner and IP range and optinally any other ASNs or ranges belonging to the same owner. 

Copyright 2015 Sean Mahan

Licensed under the "GPL 2.0" license.

This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

When it comes to being a network administrator or being in charge of some servers there will come a time when you need to lookup an ASN or IP range in order to ban it from your network/server. So what does one do now if they need to lookup what IP range belongs to an ISP for a given IP address? There are a few free tools on the internet. Most of them do not function correctly or have gaps in their database and when you do find one that actually works you have already wasted 10 minutes that you could have used to give you an early head start on blocking an attacker. My tool will function offline after downloading a data file containing the information it needs to look up an ASN.

https://en.wikipedia.org/wiki/Autonomous_system_(Internet)
http://www.team-cymru.org/IP-ASN-mapping.html

This program was written in Visual Studio 2013 in Visual Basic .NET.
If you can not access Visual Basic .NET feel free to adapt the code to any language you wish, the code should read enough like english or other languages that anyone can decipher what is going on.

Developer Note:

This program is a Visual Studio 2013 Visual Basic project, it is intended to be opened and compiled with this version or newer of Visual Studio. I apologize that Visual Studio is not free software, but due to time constraints I needed to quickly mock up this concept and Visual Basic was the best language for me to do so having already written some of the core code for another project in this language. Feel free to fork and adapt this code into any other language, following the terms of the GPL 2.0 license where necessary.


Example

Given ip address: 131.252.209.15

Results:
Owner, ASN, RANGE
Portland State University 6366 131.252.0.0/16

Others:
ASN, RANGE

6366 38.100.210.0/23
6366 38.100.216.0/21
6366 38.103.168.0/22

# ASNLookup
Take any IP address and get the associated ASN, Owner and IP range. 

Copyright 2015 Sean Mahan

Licensed under the "GPL 2.0" license.

When it comes to being a network administrator or being in charge of some servers there will come a time when you need to lookup an ASN or IP range in order to ban it from your network/server. So what does one do now if they need to lookup what IP range belongs to an ISP for a given IP address? There are a few free tools on the internet. Most of them do not function correctly or have gaps in their database and when you do find one that actually works you have already wasted 10 minutes that you could have used to give you an early head start on blocking an attacker. My tool will function offline after downloading a data file containing the information it needs to look up an ASN.

https://en.wikipedia.org/wiki/Autonomous_system_(Internet)
http://www.team-cymru.org/IP-ASN-mapping.html

The tool will start off as a standalone windows utility but will evolve (time permitting) into an API that lives on the web for developers to integrate into their own projects.

Example

Given ip address: 131.252.209.15

Results:

ASN: AS6366

Other ASN(s) for owner: NONE

Owner: PDXNET - Portland State University,US

IP Range(s) 131.252.0.1/16, x.x.x.x/x, .... 

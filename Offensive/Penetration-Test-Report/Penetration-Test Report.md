# Penetration-Test "Blue" - TryHackMe 

## 1. Managerial Summary

This test was conducted on a virtual environment in compliance with NIS2 Article 21 to showcase if security controls were implemented correctly

Critical risks were found within the tested system regarding outdated Server Message Block and Remote Desktop services. These vulnerabilities can lead to an attacker gaining full control in form of the NT AUTHORITY\SYSTEM, gaining access to every file and process on the system.

Within a real network, this vulnerability could have significant negative impact on business operations due to stolen data being exfiltrated, as well as in regards to legal ramifications. After NIS2 Article 23, an exploitation of this vulnerability would be classified as 'severe' and would need to be reported to a CSIRT entity within 24 hours or otherwise risk high fines under NIS2 Article 34 Paragraph 4 and 5.

## 2. Scope and Environment

The test was performed on the TryHackMe platform

- Attacking System: 10.112.107.24 (Ubuntu with preinstalled Kali tools)
- Target System: 10.112.140.209 (Windows x64)
  
Goals: 
- Perform reconnaissance
- Gain access, escalate privileges
- Find and extract files
- Crack hashed secrets within those files

## 3. Methodology

A black box environment was created with only the IP adress of the target system known. 
The test itself follows roughly the Penetration Testing Execution Standard as far as this is possible within a virtual environment.

### 3.1 Reconnaissance
  - Using ICMP to confirm target being online
  - Using nmap to scan for open ports and vulnerabilities
### 3.2: Vulnerability Analysis
  - Discovering unpatched Windows vulnerabilities in form of MS17-010 and MS12-020
### 3.3 Exploitation
  - Using the Metasploit framework to gain initial access to the system
  - Leveraging MS17-010 to execute code remotely
### 3.4 Post-Exploitation
  - Escalating from windows shell to meterpreter shell and migrating to spoolsv.exe
  - Extration of password hashes and offline cracking
  

## 4. Timeline

## 5. Findings

## 6. Remediation Suggestions

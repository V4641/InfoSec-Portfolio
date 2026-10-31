# Hello there, I am Elea Novah

### Historian turned InfoSec | CompTIA Security+


![](https://komarev.com/ghpvc/?username=V4641&color=blueviolet&style=plastic)


## Who I am 

Greetings! I am a studied historian, pivoting towards Cybersecurity.
The aim of this repo is to demonstrate both conceptual understanding with the certifications I own as well as hands on skills with my own projects.
Welcome to my portfolio, a continuous work in progress.

## My certifications

- Google AI Essentials | April 10th, 2026
  > Practical AI literacy, understanding capabilities and limitations, prompt building

  > [Google AI Essentials Certificate](https://coursera.org/share/72d99ef2997ed2faadad63e55bb5e83b)
- Google Cybersecurity | April 15th, 2026
  > Security theory fundamentals, SQL, Python, SIEM tooling (Splunk)

  > [Google Cybersecurity Certificate](https://coursera.org/share/ffc26d91a4809cfcadbf86396df8c714)
- TryHackMe Pre Security (Sec0) | April 16th, 2026
  > Networking fundamentals, security concepts, Windows / Linux fundamentals, hardware fundamentals, offensive / defensive security fundamentals

  > [Sec0 Certificate](https://assets.tryhackme.com/certification-certificate/69dfce85c532418aec2403ab.pdf)
- TryHackMe Cyber Security 101 (Sec1) | May 4th, 2026
  > Network traffic analysis, web vulnerabilitiy asessment, cryptography
  
  > [Sec1 Certificate](https://assets.tryhackme.com/certification-certificate/69f8177f76d33de727dc6ad2.pdf)
- CompTIA Security+ | August 2nd, 2026
  > Security concepts, cryptography, threat detection, vulnerability management, security architecture,

  > data protection, asset management, security monitoring and tooling, access management,

  > incident response, security program management, risk management,
  
  > compliance, audits, security awareness training

  > CompTIA Security+ verification ID: be4e0e155ac049c99b5f71a72e62c114
  
## My skills and tools

In addition to getting certifications, although they also include hands on  practice, be it in full or partially, I do try to broaden my knowledge and capability in multiple directions.
These do include familiarizing myself with ISO 27001 and 27002 frameworks, NIS2 and MITRE ATT&CK, that I try to map some of my projects to. 

I did try to sort these skills in regards to four main levels: If I have used them in a real environment, if I practiced them in my own environment and own hardware / software, if I had exposure to them through labs like "Hack the Box" and "Try hack me" or if they were part of study material for these learning platforms or for certifications. There is some level of overlap tho, for example the level "studied +", that implies this topic was practically applied but not in a scope that allows for it to be placed any higher with confidence.

```
+----+--------------------------------------------------+----------------------+------------+
| ID |                      Skill                       |        Level         |    Area    |
+----+--------------------------------------------------+----------------------+------------+
|  1 | IT security consulting                           | real environment     | consulting |
|  2 | Quality assurance and data entry                 | real environment     | other      |
|  3 | Network mapping and web vulnerability assessment | real environment     | offensive  |
+----+--------------------------------------------------+----------------------+------------+
|  4 | Virtualisation of services through Proxmox       | applied in own setup | network    |
|  5 | Password generator and strength checker          | applied in own setup | defensive  |
|  6 | USB-Kill and board level forensics               | applied in own setup | forensics  |
|  7 | Rubber ducky and HID exploitation                | applied in own setup | offensive  |
|  8 | Havoc Command & Control framework                | applied in own setup | offensive  |
|  9 | RFID cloning / replay attacks                    | applied in own setup | offensive  |
+----+--------------------------------------------------+----------------------+------------+
| 10 | Pentesting                                       | lab practiced        | offensive  |
| 11 | SIEM tooling                                     | lab practiced        | defensive  |
| 12 | Reverse engineering                              | lab practiced        | forensics  |
| 13 | Log analysis                                     | lab practiced        | defensive  |
| 14 | CTF's                                            | lab practiced        | offensive  |
| 15 | NIS2 and ISO 27001 compliance report             | lab practiced        | consulting |
+----+--------------------------------------------------+----------------------+------------+
| 16 | Security architecture                            | studied              | defensive  |
| 17 | Asset management                                 | studied              | defensive  |
| 18 | Cryptography                                     | studied +            | defensive  |
| 19 | Access management                                | studied              | defensive  |
| 20 | Risk management                                  | studied              | defensive  |
| 21 | Risk awareness training                          | studied +            | consulting |
+----+--------------------------------------------------+----------------------+------------+
```
------------
### Applied in a real environment
<details>
<summary><img src="Icons/consulting.svg" width="28" alt="Consulting"align="absmiddle"> IT security consulting </summary>

### What I did:
Consulting staff at a local 'Verein' about the risks of their usage of consumer grade Tp-link routers, advising on best practices in regards of passwords and advising staff in the installation and usage of "fdupes" to optimize their NAS due to storage issues.
### Limits:
Very small scope at a 'Verein' with limited IT knowledge.
### Tools:
Fdupes
</details>

<details>
<summary><img src="Icons/data-entry.svg" width="28" alt="Data-Entry"align="absmiddle"> Quality assurance and data entry </summary>

### What I did:
Sorting through data entries and ensuring their quality, integrity and availability for a contractor as well
as scraping and preparing data from official sources and public records for company operations.
Being a contact person for both costumers and local archives for said data collection.

### Limits:
Internship with mostly entry level responsibilities.
### Tools:
Internal database 
</details>

<details>
<summary><img src="Icons/offensive-crosshair.svg" width="28" alt="Offensive"align="absmiddle"> Network mapping and web vulnerability assessment  </summary>

### What I did:
Conducting network scans as well as web vulnerability assessments in a consensual setting for friends and acquaintances, testing for open ports, SQLi, SSTI as well as basic directory traversal attacks.
### Limits:
Small scope outside a professional environment with limited results due to limited practice yet.
### Tools:
Nmap, Burpsuite, Gobuster, Sstimap
</details>

------------
### Applied in my own setup

<details>
<summary><img src="Icons/network-topology.svg" width="28" alt="Network"align="absmiddle"> Virtualization of services through Proxmox   </summary>

### What I did:
Using Proxmox to setup a home server, hosting containers and vm's as well as well as for storage. Main usage for remote network access via tailscale,
hosting a dns-sinkhole to block ads and unwanted telemetry as well as a Havoc teamserver.
### Limits:
Limited hardware, exclusively home-use. Not yet comfortable with automation.
### Tools:
Proxmox, Pi-hole, Tailscale, Havoc
</details>

<details>
<summary><img src="Icons/defensive.svg" width="28" alt="Defensive"align="absmiddle"> Password generator and strength checker  </summary>

### What I did:
Creating a simple console application in .NET with C# for three basic use cases:
1. Checking for password strength in regards of composition rules and length.
2. Checking for password breach status via 'Have I been pawned' API.
3. Generating truly random passwords with composition, RandomNumberGenerator.GetInt32 and shuffle.
### Limits:
Simple application that cannot store passwords or be used as a standalone pw-manager yet.
Limited coding experience.
### Tools:
.NET, Microsoft Visual Studio, C#
### Have a look for yourself:
[My own Password Checker and Generator](https://github.com/V4641/InfoSec-Portfolio/tree/main/Defensive/Password-Checker)
</details>

<details>
<summary><img src="Icons/forensics-magnifier.svg" width="28" alt="Forensics"align="absmiddle">  USB-Kill and board level forensics   </summary>

### What I did:
Testing a USB-Kill device on own hardware for surge protection, data loss as well as damage to periphery devices and data storage devices.
After successful test phase, examining the motherboard to pinpoint surge pathways as well as damage inspection to single chipsets.
Being able to identify the damage marks a USB-Kill device leaves on the dead physical hardware.
### Limits:
Limited hardware supply that is expandable.
Limited use cases.
### Tools:
USB-Kill, Manual hardware inspection
</details>

<details>
<summary><img src="Icons/offensive-crosshair.svg" width="28" alt="Offensive"align="absmiddle">  Rubber ducky and HID exploitation    </summary>

### What I did:
Programming a Rasberry Pi Pico as a HID, masking its identity to the operating system and inserting keystrokes into a target system for demonstration purposes.
### Limits:
Simple .py script, no attack chain beyond opening a shell, opening notepad and sending a small message.
### Tools:
Thonny, Micro-Python
</details>

<details>
<summary><img src="Icons/offensive-crosshair.svg" width="28" alt="Offensive"align="absmiddle"> Havoc Command & Control framework    </summary>

### What I did:
Everything listed was used on own hardware only!

Using the Havoc client for Remote Access Trojan creation, infecting own hardware and taking control and access via the Havoc Teamserver hosted via Proxmox, creating a small Botnet
### Limits:
Limited scope due to hardware limitations, as modern Windows Defender does automatically filter out everything but extremely customized payloads.
### Tools:
Havoc
</details>

<details>
<summary><img src="Icons/offensive-crosshair.svg" width="28" alt="Offensive"align="absmiddle"> RFID cloning / replay attacks     </summary>

### What I did:
Using a Flipper Zero to close unprotected RFID cards, catching IR and sub-ghz signals and replaying it.
### Limits:
Limited usecase, as it is most useful as a demonstration tool, how easily certain systems can be interacted with.
### Tools:
Flipper Zero
</details>

-------
### Lab practiced

<details>
<summary><img src="Icons/offensive-crosshair.svg" width="28" alt="Offensive"align="absmiddle"> Pentesting     </summary>

### What I did:
Executing attack chains inside THM and HTB after the 'Penetration Testing Execution Standard' as well as writing a report afterwards. Mapping findings to NIS2, ISO 27001 and MITRE ATT&CK frameworks.

Discovering and exploiting MS17-010 vulnerability on the target system, creating a reverse shell and extracting password hashes and flags.
### Limits:
Still at a beginner level, following simple attack vectors with a deliberately vulnerable target system
### Tools:
ICMP, Nmap, Metasploit, Hashdump, John
### Have a look yourself:
![Penetration-Test "Blue" - TryHackMe](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Penetration-Test%20Report.md)
</details>

<details>
<summary><img src="Icons/defensive.svg" width="28" alt="Defensive"align="absmiddle"> SIEM tooling  </summary>

### What I did:
Using the SOC-Simulator within THM to gain experience both with splunk, analysing concentrated log data as well as working through a ticketing system, writing small reports for every ticket closed.

Analyzing phishing mails and malware files with a a fast MTTR and good true positive and false positive classification.
### Limits:
Only training, no real SOC experience. Limited Splunk Syntax knowledge.
### Tools:
Splunk
### Have a look for yourself:
[SOC-Simulation](https://github.com/V4641/InfoSec-Portfolio/blob/main/Defensive/Soc-Simulator/THM%20Phishing%20Unfolding/Soc-Simulation-Reflection.md) 
</details>

<details>
<summary><img src="Icons/forensics-magnifier.svg" width="28" alt="Forensics"align="absmiddle">  Reverse engineering  </summary>

### What I did:
Trying myself on Crackme challenges as well as inspecting programs I got full consent for
### Limits:
Very early beginner level due to lack of programming experience
### Tools:
Dotpeek, Ghidra
</details>

<details>
<summary><img src="Icons/defensive.svg" width="28" alt="Defensive"align="absmiddle"> Log Analysis  </summary>

### What I did:
Inspection of packet capture files or firewall logs, filtering and detecting signs of data exfiltration, network detection or MITM attacks both manually and with IDS tooling
### Limits:
Limited to THM rooms.
### Tools:
Wireshark, Network Miner, Snort
</details>

<details>
<summary><img src="Icons/offensive-crosshair.svg" width="28" alt="Offensive"align="absmiddle"> CTF's    </summary>

### What I did:
Independently starting attack chains within controlled attack box environments and target systems, going through Reconnaissance, Initial Access, Discovery and Data Exfiltration.

Mostly within "Hack the Box" but also THM and RedMimicry
### Limits: 
Beginner level, but constantly learning and improving
### Tools:
ICMP, Nmap, Metasploit, Hashdump, John, FTP, SSH, Awsclient ... and probably more I don't remember q-q
</details>

<details>
<summary><img src="Icons/consulting.svg" width="28" alt="Consulting"align="absmiddle"> NIS2 and ISO 27001 compliance report   </summary>

### What I did:
Referenced within the Pentesting section, mapping findings to NIS2 and ISO 27001 in the managerial summary and findings sections.

Compliance reporting for a fictional organization hosting the target system of the CTF as training and familiarizing myself with the frameworks
### Limits:
Compliance does only work on fiction in a limited capacity
### Have a look yourself:
![Penetration-Test "Blue" - TryHackMe](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Penetration-Test%20Report.md)
</details>

--------
### Studied

<details>
<summary><img src="Icons/defensive.svg" width="28" alt="Defensive"align="absmiddle"> Security architecture   </summary>

### What I did:
Familiarizing myself with zero trust and perimeter network security architecture, SDN and Airgapping
### Limits:
Conceptual knowledge without application yet.
</details>

<details>
<summary><img src="Icons/defensive.svg" width="28" alt="Defensive"align="absmiddle">  Asset management   </summary>
  
### What I did:
Familiarizing myself with the process of tracking assets through their lifecycle, data classification, states of data and the means to secure it
### Limits:
Conceptual knowledge without application yet.
</details>

 <details>
<summary><img src="Icons/defensive.svg" width="28" alt="Defensive"align="absmiddle">  Cryptography  </summary>
  
### What I did:
Familiarizing myself with PKIs, Obfuscation, Hashing, Blockchain and Certificates. Using Sha1 hashing and k-Anonymity to transmit Password Hashes to the HIBP-API within the [Password generator / Checker](https://github.com/V4641/InfoSec-Portfolio/tree/main/Defensive/Password-Checker)
### Limits:
Conceptual knowledge without many applications yet.
</details>

<details>
<summary><img src="Icons/defensive.svg" width="28" alt="Defensive"align="absmiddle">  Risk management    </summary>
  
### What I did:
Familiarizing myself with both qualitative and quantitative risk asessment using SLO, ARO and ALE, Identifying Risks, Creating Risk Management Strategies and Recovery
### Limits:
Conceptual knowledge without application yet.
</details>

<details>
<summary><img src="Icons/consulting.svg" width="28" alt="Defensive"align="absmiddle">  Risk awareness training    </summary>
  
### What I did:
Familiarizing myself with potential buisness impact and communicating best practices to employees to lower the companys attack surface.

Using this to advise family, friends and acquaintances how to proceed after data breaches and stolen access credentials
### Limits:
Conceptual knowledge without many applications yet.
</details>


## Background and education

I am a woman from Germany and hold an Abitur, which is roughly the equivalent to a highschool diploma with advanced placement classes.
I did study 'Historical Sciences' (which is mostly history, but combined with a bit of philosophy, theology, psychology and digital humanities) at the University of Passau, earning my Bachelor of Arts on July 4th, 2024.

In the meantime I already developed a newfound interest in tech, starting out with micro controllers and C# programming, but decided to continue my studies for the 'M.A in History and Humanities', which also included
digital humanities, but quickly realised it is less about history itself but more about teaching it in the field of education. I also got heavily invested into hardware repair, soldering and building my own projects.

Due to my tech interest growing and my interest in the M.A decreasing I decided to pivot away
from my old course and fully commit to InfoSec in March of 2026, inspired by someone close to pick up the trade. It has been nothing but excitement to learn and dig into a world that is so vast and I am more than eager to continuously improve, learn and develop. I am more than willing to give it my all, and to learn every trait necassery to solve the tasks ahead.

And while I did not study CS, I am more than capable of writing comprehensive and deep analysis reports as well as translating those to a non tech audience.
Besides being able to hold my own in numerous presentations in front of large audiences, another transferable skill is a critical and analytical mind,
that collects all relevant sources, correlates them and is able to comprehensively analyse data.
What I do lack in theoretical CS knowledge, I try to make up by self study, while also having the advantage of knowing how people work on a deep level. I studied human behavior across the centuries.
And human behavior still is a primary security concern.


Languages:
- German C2
- English C1-C2
- Latinum (not that this is relevant but I have it and I list it :3)

## My roadmap

At the current time, I did finish my Security+ certificate, which was the baseline for me to start looking at the job market. As for now, my roadmap includes this portfolio, uploading projects, pentest reports and other experiments.
I do aim for Junior SOC or Security Consulting roles at the moment.
I did also start connecting to people through CTF's and my attendance at it-sa Nürnberg 2026.
Other Certifications and Qualifications I do aim for:
- Splunk Search Expert 101-103
  > As it is a core part of most SIEM operations and I aim for that field in particular
- AWS CCP
  > due to the importance and high usage of cloud environments, I deem a deeper understanding on an operational level beneficial
- TryHackMe SAL1
  > since it is a hands on SOC simulation certificate
- CompTIA CySA+
  > as it is the natural progression after Security+
- CompTIA PenTest+
  > as despite my current trajectory, offensive security was what got me into the field and I wish to broaden my understanding on this side as well

## Contact
  **elea-novah@proton.me**


<h3 align="left">Connect with me:</h3>
<p align="left">
<a href="https://github.com/V4641" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/github.svg" alt="V4641" height="30" width="40" /></a>
<a href="https://discord.gg/novahspee" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/discord.svg" alt="novahspee" height="30" width="40" /></a>
</p>

<h3 align="left">Languages and Tools:</h3>
<p align="left"> <a href="https://developer.mozilla.org/en-US/docs/Web/arduino" target="_blank" rel="noreferrer"> <img src="https://skillicons.dev/icons?i=arduino" alt="arduino" width="40" height="40"/> </a> </a> <a href="https://developer.mozilla.org/en-US/docs/Web/csharp" target="_blank" rel="noreferrer"> <img src="https://skillicons.dev/icons?i=cs" alt="csharp" width="40" height="40"/> </a> <a href="https://developer.mozilla.org/en-US/docs/Web/linux" target="_blank" rel="noreferrer"> <img src="https://skillicons.dev/icons?i=linux" alt="linux" width="40" height="40"/> </a> <a href="https://developer.mozilla.org/en-US/docs/Web/mysql" target="_blank" rel="noreferrer"> <img src="https://skillicons.dev/icons?i=mysql" alt="mysql" width="40" height="40"/> </a> <a href="https://developer.mozilla.org/en-US/docs/Web/python" target="_blank" rel="noreferrer"> <img src="https://skillicons.dev/icons?i=py" alt="python" width="40" height="40"/> </a></p>

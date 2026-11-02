# Hack the Box - Vaccine

* **Category:** [Web]
* **Difficulty:** [Very Easy]
* **Points:** [250]
* **Author:** [MinatoTW]

---

## 1. Goal
Gaining system access, escalating priveleges and extracting both user.txt flag as well as root.txt flag

## 2. Description
> [Paste the official challenge description provided in the CTF platform here.]

---

## 3. Reconnaissance & Initial Analysis
* **Given files / endpoints:** [e.g., `challenge.zip`, `http://target.ctf:1337`]
* **Observations:** 
  * [What did you discover first? e.g., run `file`, `strings`, `checksec`, or inspect HTTP headers.]
  * [Mention dead ends or initial false starts briefly so others learn from them.]

---

## 4. Step-by-Step Solution

### Phase 1: [First Logical Approach]
1. [Describe the first action taken, e.g., analyzing source code or running a script.]
2. [Include relevant code snippets or terminal commands cleanly formatted:]
   ```bash
   $ python3 exploit.py --target http://target.ctf:1337
   ```

### Phase 2: [Exploitation / Deep Dive]
1. [Explain the vulnerability or core logic flaw found.]
2. [Detail how you triggered or exploited it.]

---

## 5. Solution Summary
* **Core Pattern / Vulnerability:** [e.g., Buffer Overflow, SQLi, SSTI, Unsafe Deserialization]
* **Why it worked:** [1–2 sentences explaining the underlying mechanism.]

## 6. Flag
```text
CTF{pl0h_1ns3rt_fl4g_h3r3}
```

---

## 7. Lessons Learned
* **Key Takeaway 1:** [e.g., Always check for hidden endpoints in `robots.txt` or source maps.]
* **Key Takeaway 2:** [e.g., Tool or technique practiced.]
* **Credit & References:** [Link any helpful blog posts, writeups, or tools that helped you solve it, e.g., [Reference Link](https://example.com)]

# Novah-Pass

This is a little exercise to create a password strength and breach checker as well as a password generator inside a terminal  
Passwords are evaluated on three criteria: Length, complexity and breach status.

Recommended length in this project is 24 characters with a mix in of at least two upper case letters, two numbers and two special characters, tho it does generate shorter random passwords if so desired.

## Why composition rules AND length?

The decision to include both was made consciously.

NIST 800-63B recommends a minimum length of 8 characters, discarding complexity rules.

But while length is an important factor, dropping such rules is largely due to avoiding human bias, like adding an 1! after a standard password to meet the requirements.

This tool not only checks for strength but also generates true random passwords, eliminating human bias completely.

### Length as one of several variables

Insisting on length is important and correct, but should not be the only solution. Especially with a minimum of 8 characters, all lower case letter passwords could be cracked depending on the hashing algorithm between a few seconds and a few hours at maximum.

Meanwhile an 8 character password with high entropy, a random mix of upper and lower case letters, numbers and special characters brings this up to between several months on weak algorithms and hundreds of years for complex algorithms to be cracked.

The NIST 800-63B recommendation tackles the real issue of predictable patterns that a generator would totally bypass. And a password with many characters and high entropy without human patterns has the best chances to stay strong for a while.

### Breach checking

While the recommendation of a certain length is nice, the most important aspect is to know about the breach status of a password in use.

For that reason, no matter how many boxes an inserted password ticks, if the password is known on a breachlist on HIBP, it will be strongly recommended not to use it.

No matter the level of entropy and the length, if it has been breached before and publicised, it should not be used again.


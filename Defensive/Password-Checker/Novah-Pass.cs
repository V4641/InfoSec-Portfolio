using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NovahSysAuthUtility
{
    class Program
    {
        // All the pretty reds :3

        private const string RED = "\x1b[38;2;200;0;0m";
        private const string DARK_RED = "\x1b[38;2;139;0;0m";
        private const string RESET = "\x1b[0m";
        private const string BOLD = "\x1b[1m";

        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"\n{DARK_RED}=== Novah Sys | Auth Utility ==={RESET}");
                Console.WriteLine($"{RED}1.{RESET} Check Password Strength & Breach Status");
                Console.WriteLine($"{RED}2.{RESET} Generate Secure Password");
                Console.WriteLine($"{RED}3.{RESET} Exit");

                Console.Write($"\n{BOLD}Select an option (1-3): {RESET}");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write($"{DARK_RED}Enter password to evaluate (input hidden): {RESET}");
                    string pwd = ReadPassword();

                    // Local Strength Check
                    Console.WriteLine(EvaluatePassword(pwd));

                    // External API Breach Check
                    Console.WriteLine($"\n{DARK_RED}[*] Querying HaveIBeenPwned API via k-Anonymity...{RESET}");
                    int breachCount = await CheckPwnedPasswordsAsync(pwd);

                    if (breachCount > 0)
                    {
                        Console.WriteLine($"{RED}[!] FATAL: Password found in {breachCount:N0} known breaches. DO NOT USE.{RESET}");
                    }
                    else if (breachCount == 0)
                    {
                        Console.WriteLine($"{RED}[+] Safe: Password not found in known data breaches.{RESET}");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write($"{DARK_RED}Enter length (default 24): {RESET}");
                    string lengthInput = Console.ReadLine();
                    int length = 24;

                    if (!string.IsNullOrWhiteSpace(lengthInput))
                    {
                        if (!int.TryParse(lengthInput, out length))
                        {
                            Console.WriteLine($"{RED}[!] Invalid input. Please enter an integer.{RESET}");
                            continue;
                        }
                    }

                    if (length < 24)
                    {
                        Console.WriteLine($"{RED}[!] Warning: Generating a password under 24 characters would result in a moderate or weak rating.{RESET}");
                        Console.Write($"{DARK_RED}Do you want to proceed anyway? (y/n): {RESET}");

                        string confirm = Console.ReadLine()?.Trim().ToLower();

                        if (confirm != "y" && confirm != "yes")
                        {
                            Console.WriteLine($"{RED}[*] Aborting password generation.{RESET}");
                            continue;
                        }
                    }

                    string genPwd = GeneratePassword(length);
                    Console.WriteLine($"\n{BOLD}Generated:{RESET} {RED}{genPwd}{RESET}");
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"{RED}[!] Invalid selection.{RESET}");
                }
            }
        }

        static string EvaluatePassword(string password)
        {
            int upperCount = password.Count(char.IsUpper);
            int lowerCount = password.Count(char.IsLower);
            int digitCount = password.Count(char.IsDigit);
            int specialCount = password.Count(c => "!@#$%^&*(),.?\":{}|<>-=_+".Contains(c));

            List<string> feedback = new List<string>();

            if (password.Length < 24)
                feedback.Add("Increase length to at least 24 characters.");

            if (upperCount < 2)
                feedback.Add($"Add more uppercase letters (found {upperCount}, minimum 2 required).");

            if (digitCount < 2)
                feedback.Add($"Add more numbers (found {digitCount}, minimum 2 required).");

            if (specialCount < 2)
                feedback.Add($"Add more special characters (found {specialCount}, minimum 2 required).");

            if (lowerCount < 1)
                feedback.Add("Add at least one lowercase letter.");

            int missingCount = feedback.Count;

            if (missingCount == 0)
            {
                return $"\n{RED}[+] Strong password requirements met.{RESET}";
            }
            else if (missingCount < 3)
            {
                string msg = $"\n{DARK_RED}[~] Moderate password. Required changes:{RESET}\n";
                foreach (var f in feedback) msg += $"    - {f}\n";
                return msg.TrimEnd();
            }
            else
            {
                string msg = $"\n{RED}[!] Weak password. Required changes:{RESET}\n";
                foreach (var f in feedback) msg += $"    - {f}\n";
                return msg.TrimEnd();
            }
        }

        static async Task<int> CheckPwnedPasswordsAsync(string password)
        {
            string hash = ComputeSha1Hash(password);
            string prefix = hash.Substring(0, 5);
            string suffix = hash.Substring(5);

            string url = $"https://api.pwnedpasswords.com/range/{prefix}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                return ParseBreachCount(responseBody, suffix);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{RED}[!] Error checking API: {ex.Message}{RESET}");
                return -1;
            }
        }

        private static string ComputeSha1Hash(string rawData)
        {
            using (SHA1 sha1Hash = SHA1.Create())
            {
                byte[] bytes = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("X2"));
                }
                return builder.ToString();
            }
        }

        private static int ParseBreachCount(string apiResponse, string hashSuffix)
        {
            string[] lines = apiResponse.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && parts[0] == hashSuffix)
                {
                    return int.Parse(parts[1]);
                }
            }
            return 0;
        }

        static string GeneratePassword(int length = 16)
        {
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string special = "!@#$%^&*()-_=+";
            const string allChars = lowercase + uppercase + digits + special;

            // Hard minimum 
            if (length < 7)
            {
                Console.WriteLine($"{RED}[!] Length adjusted to 7 to meet minimum complexity requirements.{RESET}");
                length = 7;
            }

            char[] passwordChars = new char[length];

            // Guarantee minimum required characters
            passwordChars[0] = lowercase[RandomNumberGenerator.GetInt32(lowercase.Length)];
            passwordChars[1] = uppercase[RandomNumberGenerator.GetInt32(uppercase.Length)];
            passwordChars[2] = uppercase[RandomNumberGenerator.GetInt32(uppercase.Length)];
            passwordChars[3] = digits[RandomNumberGenerator.GetInt32(digits.Length)];
            passwordChars[4] = digits[RandomNumberGenerator.GetInt32(digits.Length)];
            passwordChars[5] = special[RandomNumberGenerator.GetInt32(special.Length)];
            passwordChars[6] = special[RandomNumberGenerator.GetInt32(special.Length)];

            // Fill the remainder randomly
            for (int i = 7; i < length; i++)
            {
                passwordChars[i] = allChars[RandomNumberGenerator.GetInt32(allChars.Length)];
            }

            // Shuffle the array to randomize character positions
            for (int i = 0; i < length; i++)
            {
                int swapIndex = RandomNumberGenerator.GetInt32(length);
                char temp = passwordChars[i];
                passwordChars[i] = passwordChars[swapIndex];
                passwordChars[swapIndex] = temp;
            }

            return new string(passwordChars);
        }

        static string ReadPassword()
        {
            string password = string.Empty;
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }
}

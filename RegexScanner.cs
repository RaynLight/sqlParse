using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace sqlParse
{
    internal static class RegexScanner
    {
        private static Dictionary<string, string> GetPatterns()
        {
            var patterns = new Dictionary<string, string>();
            patterns.Add("MD5", @"\b[a-f0-9]{32}\b");
            patterns.Add("SHA1", @"\b[a-f0-9]{40}\b");
            patterns.Add("SHA256", @"\b[a-f0-9]{64}\b");
            patterns.Add("NTLM Hash", @"\b[a-fA-F0-9]{32}:[a-fA-F0-9]{32}\b");
            patterns.Add("Email", @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
            patterns.Add("Base64 String", @"([A-Za-z0-9+/]{20,}={0,2})");
            patterns.Add("Password Field", @"(?i)(password|passwd|pwd)[^a-zA-Z0-9]?\s*[:=]?\s*\S+");
            patterns.Add("AWS Key", @"AKIA[0-9A-Z]{16}");
            patterns.Add("JWT Token", @"eyJ[A-Za-z0-9_-]+\.[A-Za-z0-9._-]+\.[A-Za-z0-9._-]+");
            patterns.Add("Credit Card", @"\b(?:\d[ -]*?){13,16}\b");
            return patterns;
        }

        public static List<string> ScanData(string input)
        {
            var findings = new List<string>();
            var patterns = GetPatterns();

            foreach (var pair in patterns)
            {
                MatchCollection matches = Regex.Matches(input, pair.Value);
                foreach (Match match in matches)
                {
                    findings.Add("[REGEX HIT] " + pair.Key + ": " + match.Value);
                }
            }

            return findings;
        }

        public static List<string> BatchScan(Queue<string> inputQueue)
        {
            var results = new List<string>();
            while (inputQueue.Count > 0)
            {
                string line = inputQueue.Dequeue();
                List<string> matches = ScanData(line);
                if (matches.Count > 0)
                {
                    results.Add("[!] Analyzing Line: " + line);
                    results.AddRange(matches);
                    results.Add(""); // spacing
                }
            }
            return results;
        }
    }
}

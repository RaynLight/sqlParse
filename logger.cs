using System;
using System.IO;
using System.Text;

namespace sqlParse
{
    internal static class Logger
    {
        private static readonly object _lock = new object();
        private static string _logFile;

        public static void Init()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            Directory.CreateDirectory(dir);

            string baseName = "sqlParse.log";
            string path = Path.Combine(dir, baseName);
            int i = 1;
            while (File.Exists(path))
            {
                path = Path.Combine(dir, Path.GetFileNameWithoutExtension(baseName) + "_" + i + ".log");
                i++;
            }
            _logFile = path;

            Write("INIT", "Logger initialized: " + _logFile);
        }

        private static void Write(string tag, string msg)
        {
            lock (_lock)
            {
                string line = string.Format("[{0}] [{1}] {2}",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), tag, msg);
                File.AppendAllText(_logFile, line + Environment.NewLine, Encoding.UTF8);
            }
        }

        public static void Info(string msg) { Write("INFO", msg); }
        public static void Error(string msg) { Write("ERROR", msg); }
        public static void Query(string sql) { Write("QUERY", sql); }
        public static void Connection(string user, string ip, bool success, string detail)
        {
            Write("CONNECT", string.Format("{0}@{1} -> {2} ({3})",
                user, ip, success ? "SUCCESS" : "FAIL", detail));
        }
        public static void ScannerQuery(string sql) { Write("SCANNER", "(query) " + sql); }
        public static void RegexHit(string label, string value)
        {
            // truncate very long values in log
            if (value != null && value.Length > 300) value = value.Substring(0, 300) + "...";
            Write("SCANNER", "[regex hit] " + label + ": " + value);
        }
    }
}

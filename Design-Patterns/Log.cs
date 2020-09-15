﻿using System;
using System.IO;

namespace DesignPatterns
{
    public class Log
    {
        public static void Info(string format, params object[] args)
        {
            WriteLine(LogLevel.Info, format, args);
        }

        public static void Warning(string format, params object[] args)
        {
            WriteLine(LogLevel.Warning, format, args);
        }

        public static void Error(string format, params object[] args)
        {
            WriteLine(LogLevel.Error, format, args);
        }

        public static void Debug(string format, params object[] args)
        {
#if DEBUG
            WriteLine(LogLevel.Debug, format, args);
#endif
        }

        public static void Debug(object obj)
        {
#if DEBUG
            WriteLine(LogLevel.Debug, obj.ToString());
#endif
        }

        public static void Status(string format, params object[] args)
        {
            WriteLine(LogLevel.Status, format, args);
        }

        public static void Exception(Exception ex, string description = null, params object[] args)
        {
            if (description != null)
                WriteLine(LogLevel.Error, description, args);
            WriteLine(LogLevel.Exception, ex.ToString());
        }

        public static void Unimplemented(string format, params object[] args)
        {
            WriteLine(LogLevel.Unimplemented, format, args);
        }

        public static void WriteLine(LogLevel level, string format, params object[] args)
        {
            Write(level, format + Environment.NewLine, args);
        }

        private static void Write(LogLevel level, string format, params object[] args)
        {
            switch (level)
            {
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogLevel.Status:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogLevel.Exception:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Unimplemented:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.Write("[{0}]", level);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("[{0}]", DateTime.Now.ToString("HH:mm:ss.ffffff"));

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - ");
            Console.Write(format, args);
        }
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Debug,
        Status,
        Exception,
        Unimplemented
    }
}

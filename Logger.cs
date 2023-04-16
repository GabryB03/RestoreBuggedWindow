using System;

public static class Logger
{
    public static void LogInfo(string content)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("] " + content + "\r\n");
    }

    public static void LogError(string content)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("] " + content + "\r\n");
    }

    public static void LogWarning(string content)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("] " + content + "\r\n");
    }

    public static void LogSuccess(string content)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("] " + content + "\r\n");
    }
}
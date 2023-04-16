using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;

public class Program
{
    public static void Main()
    {
        Console.Title = "RestoreBuggedWindow | Made by https://github.com/GabryB03/";

        if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator))
        {
            Logger.LogWarning("The program is not run with Administrator privileges. The program may not work correctly.");
        }

        Logger.LogInfo("Please, choose one of the opened windows:");
        int i = 1;
        List<IntPtr> windowHandles = GetWindowHandles(ref i);
        string selectedOption = "";

        while (!IsNumberValid(selectedOption, i - 1))
        {
            Console.Write("> ");
            selectedOption = Console.ReadLine();

            if (!IsNumberValid(selectedOption, i - 1))
            {
                Logger.LogError("Invalid number, please try again.");
            }
        }

        try
        {
            IntPtr windowHandle = windowHandles[int.Parse(selectedOption) - 1];
            Native.RECT windowRect = new Native.RECT();

            if (!Native.GetWindowRect(windowHandle, ref windowRect))
            {
                Logger.LogError("Failed to restore your window. Error on executing 'GetWindowRect'. Press ENTER to exit from the program.");
                Console.ReadLine();
                return;
            }

            int width = windowRect.Right - windowRect.Left, height = windowRect.Bottom - windowRect.Top;
            Native.MoveWindow(windowHandle, 0, 0, width, height, true);
            Logger.LogInfo("Succesfully restored your window. Press ENTER to exit from the program.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to restore your window. Error:\r\n{ex.Message}\r\n{ex.StackTrace}\r\n{ex.Source}");
        }
    }

    private static bool IsNumberValid(string str, int options)
    {
        if (!Microsoft.VisualBasic.Information.IsNumeric(str))
        {
            return false;
        }

        int x = 0;

        if (!(int.TryParse(str, out x) && x > 0))
        {
            return false;
        }

        if (x > options)
        {
            return false;
        }

        return true;
    }

    private static List<IntPtr> GetWindowHandles(ref int i)
    {
        List<IntPtr> windowHandles = new List<IntPtr>();

        foreach (Process process in Process.GetProcesses())
        {
            try
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    if (process.MainWindowTitle != null && process.MainWindowTitle.Replace(" ", "").Replace('\t'.ToString(), "") != "")
                    {
                        Console.WriteLine($"{i}) {process.MainWindowTitle} (PID: {process.Id})");
                        i++;
                        windowHandles.Add(process.MainWindowHandle);
                    }
                }
            }
            catch
            {

            }
        }

        return windowHandles;
    }
}
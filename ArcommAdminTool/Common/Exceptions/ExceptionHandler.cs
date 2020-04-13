using System;
using System.Windows.Forms;
using ArcommAdminTool.Common.Exceptions.Enums;

namespace ArcommAdminTool.Common.Exceptions
{
    public static class ExceptionHandler
    {
        public static void LogException(string message, Exception ex, Severity severity)
        {
            Console.WriteLine($"[{severity}] {message} {ex}");
        }

        public static void LogException(Exception ex, Severity severity)
        {
            Console.WriteLine($"[{severity}] {ex}");
        }

        public static void LogException(string message, Severity severity)
        {
            Console.WriteLine($"[{severity}] {message}");
        }

        public static void ShowBox(string message, string title, MessageBoxButtons button, MessageBoxIcon type)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void ShowValidationErrorBox(string message)
        {
            ShowBox(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            LogException(message, Severity.Informational);
        }

        public static void ShowErrorBox(string message)
        {
            ShowBox(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogException(message, Severity.Continuable);
        }
    }
}
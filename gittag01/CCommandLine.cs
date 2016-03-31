using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GitTag01
{
    public static class CCommandLine
    {
        /// <summary>
        /// Выполняет вызов команда из командной строки
        /// </summary>
        /// <param name="command">Команда</param>
        /// <param name="args">Параметры команды</param>
        /// <param name="directory">Рабочая папка</param>
        /// <param name="stdout">Флаг перенаправления stdout в буфер</param>
        /// <param name="stderr">Флаг перенаправления stderr в буфер</param>
        /// <param name="throwOnError">Флаг выброса исключения при появлении данных в stderr</param>
        /// <returns>Вывод stdout и stderr в виде списка строк</returns>
        public static List<string> Execute(
            string command, string args, string directory = "",
            bool stdout = true, bool stderr = true, bool throwOnError = true
        )
        {
            var stdoutString = new List<string>();
            var stderrString = new List<string>();
 
            Process process;
            ProcessStartInfo psi;
 
            try {
                process = new Process();
                psi = new ProcessStartInfo(command, args);

                psi.UseShellExecute = false;
                if (!String.IsNullOrEmpty(directory)) psi.WorkingDirectory = directory;
                if (stdout) psi.RedirectStandardOutput = true;
                if (stderr || throwOnError) psi.RedirectStandardError = true;

                process.StartInfo = psi;
                process.Start();
 
                if (stderr || throwOnError) stderrString = ReadStream(process.StandardError); 
                if (throwOnError && stderrString.Count > 0)
                    throw new Exception(
                        string.Format("Error in CCommandLine while executing {0} with arguments {1}: {2}",
                        command, args, String.Join(" ", stderrString.ToArray())));
 
                if (stdout) stdoutString = ReadStream(process.StandardOutput);
                if (stderr) stdoutString.AddRange(stderrString);
 
                process.WaitForExit();
            } catch (Exception e) {
                throw new Exception(
                    string.Format("Error in CCommandLine while executing {0} with arguments {1}", command, args), e);
            }
 
            // Return the output string
            return stdoutString;
        }

        /// <summary>
        /// Построчно считывает поток
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <returns>Считанный поток в виде списка строк</returns>
        private static List<string> ReadStream(System.IO.StreamReader stream)
        {
            var result = new List<string>();
            string lineVal = stream.ReadLine();

            while (lineVal != null) {
                result.Add(lineVal);
                lineVal = stream.ReadLine();
            }
            return result;
        }
    }
}

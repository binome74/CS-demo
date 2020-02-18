using System;
using System.Collections.Generic;
using System.Text;

namespace GitTag01
{
    public static class CGit
    {
        /// <summary>
        /// Команда для вызова GIT
        /// </summary>
        private static readonly string gitCommand = @"git";

        /// <summary>
        /// Клонирует указанный репозиторий
        /// </summary>
        /// <param name="url">URL репозитория</param>
        /// <param name="directory">Папка, куда будет клонирован репозиторий</param>
        /// <returns>Вывод stdout и stderr в виде списка строк</returns>
        public static List<string> Clone(string url, string directory = "")
        {
            return CCommandLine.Execute(gitCommand, "clone " + url , directory, true, true, false);
        }

        /// <summary>
        /// Получает перечень тегов репозитория
        /// </summary>
        /// <param name="repo">Путь к репозиторию</param>
        /// <returns>Вывод stdout и stderr в виде списка строк</returns>
        public static List<string> Tag(string repo)
        {
            return CCommandLine.Execute(gitCommand, "tag", repo);
        }

        /// <summary>
        /// Получает информацию git show по тегу
        /// </summary>
        /// <param name="repo">Путь к репозиторию</param>
        /// <param name="tag">Тег</param>
        /// <returns>Вывод stdout и stderr в виде списка строк</returns>
        public static List<String> Show(string repo, string tag)
        {
            return CCommandLine.Execute(gitCommand, "show " + tag + " --no-patch", repo);
        }
    }
}

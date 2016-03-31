using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace GitTag01
{
    class Program
    {
        /// <summary>
        /// Директория, кода будем складывать клонированные репозитории
        /// </summary>
        private static readonly string tempDirectory;
        /// <summary>
        /// Директория текущего репозитория
        /// </summary>
        private static string repoDirectory;
        /// <summary>
        /// Наименования текущего репозитория
        /// </summary>
        private static string repoName;

        /// <summary>
        /// Конструктор (статический)
        /// </summary>
        static Program()
        {
            tempDirectory = Path.Combine(Path.GetTempPath(), "GitTag");
        }

        /// <summary>
        /// Основная функция, точка входа в приложение
        /// </summary>
        /// <param name="args">Параметры командной строки</param>
        static void Main(string[] args)
        {
            string url = null;

            PrepareDirectory();
            if (args.Length > 0) url = args[0];
            if (Clone(url)) {
                var tags = FetchTags();
                if (tags != null) Console.WriteLine(SaveTagsToXml(tags));
            }

            Console.Write("Task is completed. Press any key ...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Подготовка папки приложения
        /// </summary>
        private static void PrepareDirectory()
        {
            if (!Directory.Exists(tempDirectory))
                Directory.CreateDirectory(tempDirectory);
        }

        /// <summary>
        /// Клонирует указанный репозиторий, либо запрашивает url и клонирует, устанавливает его наименование и путь
        /// </summary>
        /// <param name="url">URL репозитория</param>
        /// <returns>Признак успешного завершения</returns>
        private static bool Clone(string url = null)
        {
            if (string.IsNullOrEmpty(url)) {
                Console.Write("Enter repository URL: ");
                url = Console.ReadLine();
            }
            Console.WriteLine(String.Format("Trying to clone {0}, this may take a while ... ", url));
            var result = CGit.Clone(url, tempDirectory);
            PrintList(result);
                
            var myRegex = new Regex(@"clon.+?into\s+'(.+?)'", RegexOptions.IgnoreCase);
            string repo = result.Find(delegate(string s) { return myRegex.IsMatch(s); });
            if (repo == null) return false;

            repo = myRegex.Match(repo).Groups[1].ToString();
            repoDirectory = Path.Combine(tempDirectory, repo);
            repoName = repo;

            return true;
        }

        /// <summary>
        /// Получает список тегов репозитория в комбинации с датой
        /// </summary>
        /// <returns>Словарь тег - дата</returns>
        private static Dictionary<string, string> FetchTags()
        {
            if (!Directory.Exists(repoDirectory)) return null;

            var result = new Dictionary<string, string>();
            var tags = CGit.Tag(repoDirectory);
            var dateRegEx = new Regex(@"^date:\s+(.+?)$", RegexOptions.IgnoreCase);

            foreach (string tag in tags) {
                var tagInfo = CGit.Show(repoDirectory, tag);
                string date = tagInfo.Find(delegate(string s) { return dateRegEx.IsMatch(s); });
                if (date == null) continue;
                result.Add(tag, dateRegEx.Match(date).Groups[1].ToString());
            }

            return result;
        }

        /// <summary>
        /// Записывает переданные теги и даты в XML-файл
        /// </summary>
        /// <param name="tags">Набор тегов и дат</param>
        /// <returns>Имя созданного XML-файла</returns>
        private static string SaveTagsToXml(Dictionary<string, string> tags)
        {
            string output = Path.Combine(tempDirectory, Path.GetRandomFileName() + ".xml");

            using (XmlWriter writer = XmlWriter.Create(output)) {
                writer.WriteStartDocument();
                writer.WriteStartElement("root");

                foreach (var tag in tags) {
                    writer.WriteStartElement("tag");
                    writer.WriteStartAttribute("name");
                    writer.WriteValue(tag.Key);
                    writer.WriteEndAttribute();
                    writer.WriteStartAttribute("date");
                    writer.WriteValue(tag.Value);
                    writer.WriteEndAttribute();
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }

            return output;
        }

        /// <summary>
        /// Выводит список строк в консоль построчно
        /// </summary>
        /// <param name="list">Список строк</param>
        private static void PrintList(List<string> list)
        {
            Console.WriteLine(String.Join(Environment.NewLine, list.ToArray()));
        }
    }
}

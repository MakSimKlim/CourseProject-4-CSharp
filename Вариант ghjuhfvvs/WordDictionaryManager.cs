using System;
using System.Collections.Generic;
using System.IO;

namespace проект_CSharp
{
    public class WordDictionaryManager
    {
        private Dictionary dictionary;

        public WordDictionaryManager()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EnglishRussian.txt");
            dictionary = new Dictionary(filePath);
        }

        public void ShowDictionary(string translationDirection)
        {
            DictionaryEntry[] entries = dictionary.GetEntries(translationDirection);

            if (entries.Length == 0)
            {
                Console.WriteLine("Словарь пуст.");
            }
            else
            {
                Console.WriteLine($"Словарь ({translationDirection}):");
                foreach (var entry in entries)
                {
                    Console.WriteLine($"{entry.Word} - {string.Join(", ", entry.Translations)}");
                }
            }

            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню.");
            Console.ReadLine();
        }

        public void AddWord(string translationDirection)
        {
            Console.WriteLine($"Добавление слова ({translationDirection}):");

            Console.Write("Введите слово: ");
            string word = Console.ReadLine();

            Console.Write("Введите перевод(-ы), через запятую: ");
            string translationsInput = Console.ReadLine();
            string[] translations = translationsInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);


            // Добавляем слово и его переводы в словарь
            dictionary.AddEntry(translationDirection, word, translations);

            Console.WriteLine($"Слово '{word}' успешно добавлено в словарь.\nНажмите Enter, чтобы вернуться в меню.");
            Console.ReadLine();
        }

        public void ReplaceWord(string translationDirection)
        {
            Console.WriteLine($"Замена слова ({translationDirection}):");

            Console.Write("Введите слово для замены: ");
            string oldWord = Console.ReadLine();

            Console.Write("Введите новое слово: ");
            string newWord = Console.ReadLine();

            Console.Write("Введите новый перевод(-ы), через запятую: ");
            string translationsInput = Console.ReadLine();
            string[] newTranslations = translationsInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            dictionary.ReplaceEntry(translationDirection, oldWord, newWord, newTranslations);

            Console.WriteLine($"Слово '{oldWord}' успешно заменено на '{newWord}' в словаре.\nНажмите Enter, чтобы вернуться в меню.");
            Console.ReadLine();
        }

        public void DeleteWord(string translationDirection)
        {
            Console.WriteLine($"Удаление слова ({translationDirection}):");

            Console.Write("Введите слово для удаления: ");
            string wordToDelete = Console.ReadLine();

            dictionary.DeleteEntry(translationDirection, wordToDelete);

            Console.WriteLine($"Слово '{wordToDelete}' успешно удалено из словаря.\nНажмите Enter, чтобы вернуться в меню.");
            Console.ReadLine();
        }

        public void SearchWord(string translationDirection)
        {
            Console.WriteLine($"Поиск перевода слова ({translationDirection}):");

            Console.Write("Введите слово для поиска перевода: ");
            string wordToSearch = Console.ReadLine();

            DictionaryEntry entry = dictionary.FindEntry(translationDirection, wordToSearch);

            if (entry != null)
            {
                Console.WriteLine($"Перевод слова '{wordToSearch}': {string.Join(", ", entry.Translations)}");
            }
            else
            {
                Console.WriteLine($"Перевод для слова '{wordToSearch}' не найден.");
            }

            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню.");
            Console.ReadLine();
        }

        public void ExportWord(string translationDirection)
        {
            Console.WriteLine($"Экспорт слова ({translationDirection}):");

            Console.Write("Введите слово для экспорта: ");
            string wordToExport = Console.ReadLine();

            DictionaryEntry entry = dictionary.FindEntry(translationDirection, wordToExport);

            if (entry != null)
            {
                // Используем метод экспорта из класса Dictionary
                dictionary.ExportWordToFile(translationDirection, wordToExport);
                Console.WriteLine($"Слово '{wordToExport}' успешно экспортировано.\nНажмите Enter, чтобы вернуться в меню.");
            }
            else
            {
                Console.WriteLine($"Слово '{wordToExport}' не найдено в словаре.");
            }

            Console.ReadLine();
        }

        // Другие методы (если есть)
    }
}

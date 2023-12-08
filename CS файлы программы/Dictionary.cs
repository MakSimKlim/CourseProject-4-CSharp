using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace проект_CSharp
{
    public class Dictionary
    {
        private List<DictionaryEntry> entries;
        private string filePath; // Путь к файлу для сохранения и загрузки словаря

        public Dictionary(string filePath)
        {
            this.filePath = filePath;
            entries = new List<DictionaryEntry>();
        }


        public void AddEntry(string translationDirection, string word, string[] translations)
        {
            DictionaryEntry existingEntry = FindEntry(translationDirection, word);
            if (existingEntry != null)
            {
                // Если слово уже существует, добавляем новые переводы
                existingEntry.Translations.AddRange(translations);
            }
            else
            {
                // Создаем новую запись
                DictionaryEntry newEntry = new DictionaryEntry
                {
                    TranslationDirection = translationDirection,
                    Word = word,
                    Translations = new List<string>(translations)
                };

                entries.Add(newEntry);
            }
        }

        public void ReplaceEntry(string translationDirection, string oldWord, string newWord, string[] newTranslations)
        {
            DictionaryEntry existingEntry = FindEntry(translationDirection, oldWord);
            if (existingEntry != null)
            {
                // Заменяем слово и переводы
                existingEntry.Word = newWord;
                existingEntry.Translations = new List<string>(newTranslations);
            }
        }

        public void DeleteEntry(string translationDirection, string wordToDelete)
        {
            DictionaryEntry entryToDelete = FindEntry(translationDirection, wordToDelete);
            if (entryToDelete != null)
            {
                // Удаляем запись из словаря
                entries.Remove(entryToDelete);
            }
        }

        public DictionaryEntry FindEntry(string translationDirection, string wordToFind)
        {
            return entries.FirstOrDefault(entry => entry.TranslationDirection == translationDirection && entry.Word == wordToFind);
        }

        public DictionaryEntry[] GetEntries(string translationDirection)
        {
            return entries.Where(entry => entry.TranslationDirection == translationDirection).ToArray();
        }

        public void SaveToFile(string filePath)
        {
            // Логика сохранения словаря в файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.TranslationDirection} - {entry.Word} - {string.Join(", ", entry.Translations)}");
                }
            }
            Console.WriteLine($"Словарь сохранен в файл: {filePath}");
        }

        // Загрузка словаря из файла
        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                entries.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split('-');
                        if (parts.Length >= 3)
                        {
                            string translationDirection = parts[0].Trim();
                            string word = parts[1].Trim();
                            string[] translations = parts[2].Split(',').Select(t => t.Trim()).ToArray();
                            AddEntry(translationDirection, word, translations);
                        }
                    }
                }
                Console.WriteLine($"Словарь загружен из файла: {filePath}");
            }
            else
            {
                Console.WriteLine($"Файл '{filePath}' не найден. Создан новый словарь.");
            }
        }
        // Экспорт слова и его переводов в отдельный файл
        public void ExportWordToFile(string translationDirection, string word)
        {
            DictionaryEntry entryToExport = FindEntry(translationDirection, word);

            if (entryToExport != null)
            {
                string exportFilePath = $"{translationDirection}_{word}_Export.txt";

                using (StreamWriter writer = new StreamWriter(exportFilePath))
                {
                    writer.WriteLine($"Translation Direction: {entryToExport.TranslationDirection}");
                    writer.WriteLine($"Word: {entryToExport.Word}");
                    writer.WriteLine("Translations:");
                    foreach (var translation in entryToExport.Translations)
                    {
                        writer.WriteLine($"- {translation}");
                    }
                }

                Console.WriteLine($"Слово и его переводы экспортированы в файл: {exportFilePath}");
            }
            else
            {
                Console.WriteLine($"Слово '{word}' не найдено в словаре.");
            }
        }


    }
}

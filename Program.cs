using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        DictionaryManager dictionaryManager = new DictionaryManager();

        while (true)
        {
            Console.WriteLine("1. Создать словарь");
            Console.WriteLine("2. Добавить слово и перевод");
            Console.WriteLine("3. Заменить слово или перевод");
            Console.WriteLine("4. Удалить слово или перевод");
            Console.WriteLine("5. Найти перевод слова");
            Console.WriteLine("6. Экспортировать словарь");
            Console.WriteLine("7. Выход");

            int choice = GetChoice(1, 7);

            switch (choice)
            {
                case 1:
                    dictionaryManager.CreateDictionary();
                    break;
                case 2:
                    dictionaryManager.AddWordTranslation();
                    break;
                case 3:
                    dictionaryManager.ReplaceWordTranslation();
                    break;
                case 4:
                    dictionaryManager.DeleteWordTranslation();
                    break;
                case 5:
                    dictionaryManager.SearchTranslation();
                    break;
                case 6:
                    dictionaryManager.ExportDictionary();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    class DictionaryManager
    {
        private Dictionary<string, Dictionary<string, List<string>>> dictionaries;
        private string currentDictionary;

        public DictionaryManager()
        {
            dictionaries = new Dictionary<string, Dictionary<string, List<string>>>();
        }

        public void CreateDictionary()
        {
            Console.WriteLine("Введите название словаря:");
            string dictionaryName = Console.ReadLine();

            if (!dictionaries.ContainsKey(dictionaryName))
            {
                dictionaries.Add(dictionaryName, new Dictionary<string, List<string>>());
                Console.WriteLine($"Словарь '{dictionaryName}' успешно создан.");
                currentDictionary = dictionaryName;
            }
            else
            {
                Console.WriteLine($"Словарь '{dictionaryName}' уже существует.");
            }
        }

        public void AddWordTranslation()
        {
            Console.WriteLine("Введите слово:");
            string word = Console.ReadLine();

            Console.WriteLine("Введите перевод(ы), разделяя их запятой:");
            string translationsInput = Console.ReadLine();
            List<string> translations = new List<string>(translationsInput.Split(','));

            if (dictionaries.ContainsKey(currentDictionary))
            {
                if (dictionaries[currentDictionary].ContainsKey(word))
                {
                    dictionaries[currentDictionary][word].AddRange(translations);
                }
                else
                {
                    dictionaries[currentDictionary][word] = translations;
                }

                Console.WriteLine($"Слово '{word}' успешно добавлено в словарь '{currentDictionary}'.");
            }
            else
            {
                Console.WriteLine("Сначала создайте словарь.");
            }
        }

        public void ReplaceWordTranslation()
        {
            Console.WriteLine("Введите слово для замены:");
            string wordToReplace = Console.ReadLine();

            if (dictionaries.ContainsKey(currentDictionary) && dictionaries[currentDictionary].ContainsKey(wordToReplace))
            {
                Console.WriteLine($"Введите новое слово для '{wordToReplace}':");
                string newWord = Console.ReadLine();

                Console.WriteLine($"Введите новый перевод(ы) для '{newWord}', разделяя их запятой:");
                string newTranslationsInput = Console.ReadLine();
                List<string> newTranslations = new List<string>(newTranslationsInput.Split(','));

                dictionaries[currentDictionary].Remove(wordToReplace);
                dictionaries[currentDictionary][newWord] = newTranslations;

                Console.WriteLine($"Слово '{wordToReplace}' успешно заменено на '{newWord}' в словаре '{currentDictionary}'.");
            }
            else
            {
                Console.WriteLine($"Слово '{wordToReplace}' не найдено в словаре '{currentDictionary}'.");
            }
        }

        public void DeleteWordTranslation()
        {
            Console.WriteLine("Введите слово для удаления:");
            string wordToDelete = Console.ReadLine();

            if (dictionaries.ContainsKey(currentDictionary) && dictionaries[currentDictionary].ContainsKey(wordToDelete))
            {
                dictionaries[currentDictionary].Remove(wordToDelete);

                Console.WriteLine($"Слово '{wordToDelete}' успешно удалено из словаря '{currentDictionary}'.");
            }
            else
            {
                Console.WriteLine($"Слово '{wordToDelete}' не найдено в словаре '{currentDictionary}'.");
            }
        }

        public void SearchTranslation()
        {
            Console.WriteLine("Введите слово для поиска перевода:");
            string wordToSearch = Console.ReadLine();

            if (dictionaries.ContainsKey(currentDictionary) && dictionaries[currentDictionary].ContainsKey(wordToSearch))
            {
                List<string> translations = dictionaries[currentDictionary][wordToSearch];
                Console.WriteLine($"Перевод слова '{wordToSearch}': {string.Join(", ", translations)}");
            }
            else
            {
                Console.WriteLine($"Слово '{wordToSearch}' не найдено в словаре '{currentDictionary}'.");
            }
        }

        public void ExportDictionary()
        {
            if (dictionaries.ContainsKey(currentDictionary))
            {
                Console.WriteLine("Введите путь для экспорта словаря:");
                string exportPath = Console.ReadLine();

                using (FileStream fileStream = new FileStream(exportPath, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<string, List<string>>));
                    serializer.Serialize(fileStream, dictionaries[currentDictionary]);
                }

                Console.WriteLine($"Словарь '{currentDictionary}' успешно экспортирован в файл '{exportPath}'.");
            }
            else
            {
                Console.WriteLine("Сначала создайте словарь.");
            }
        }
    }

    static int GetChoice(int min, int max)
    {
        int choice;
        while (true)
        {
            Console.Write($"Введите выбор ({min}-{max}): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
            {
                return choice;
            }
            else
            {
                Console.WriteLine($"Некорректный ввод. Пожалуйста, введите число от {min} до {max}.");
            }
        }
    }
}

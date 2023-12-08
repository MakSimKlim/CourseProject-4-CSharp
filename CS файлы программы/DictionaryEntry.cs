using System;
using System.Collections.Generic;
using System.Linq;

namespace проект_CSharp
{
    public class DictionaryEntry
    {
        private string translationDirection;
        private string word;
        private List<string> translations;

        public DictionaryEntry()
        {
            translations = new List<string>();
        }

        public string TranslationDirection
        {
            get { return translationDirection; }
            set { translationDirection = value; }
        }

        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        public List<string> Translations
        {
            get { return translations; }
            set { translations = value; }
        }

        // Добавление нового перевода
        public void AddTranslation(string newTranslation)
        {
            translations.Add(newTranslation);
        }

        // Замена переводов новыми
        public void ReplaceTranslations(List<string> newTranslations)
        {
            translations = newTranslations;
        }

        // Поиск перевода в списке
        public bool ContainsTranslation(string searchTranslation)
        {
            return translations.Contains(searchTranslation);
        }

        // Удаление перевода из списка
        public void RemoveTranslation(string translationToRemove)
        {
            translations.Remove(translationToRemove);
        }

        // Вывод информации о записи
        public void DisplayEntry()
        {
            Console.WriteLine($"Translation Direction: {translationDirection}");
            Console.WriteLine($"Word: {word}");
            Console.WriteLine("Translations:");
            foreach (var translation in translations)
            {
                Console.WriteLine($"- {translation}");
            }
        }
    }
}

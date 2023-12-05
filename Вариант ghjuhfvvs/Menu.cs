using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace проект_CSharp
{
    public class Menu
    {
        private WordDictionaryManager dictionaryManager;

        public Menu(WordDictionaryManager manager)
        {
            dictionaryManager = manager;
        }
        public void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***************** РУССКИЙ МультиСЛОВАРЬ V1.0.0 ***********");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\n\n\n\t\t   1. Загрузить словарь");
            Console.WriteLine("\t\t   0. Выход\n");
            Console.WriteLine("\t\t   Введите 1 или 0:");

            Console.WriteLine("\n\n\n\n\n\n\n**********************************************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            string choice = Console.ReadLine();
            ProcessMainMenuChoice(choice);
        }

        private void ProcessMainMenuChoice(string choice)
        {
            Console.Clear();
            switch (choice)
            {
                case "1":
                    ShowDictionaryLanguageMenu();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    ShowMainMenu();
                    break;
            }
        }

        private void ShowDictionaryLanguageMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("****************    Выберите язык словаря:    ************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\n\n\t\t   1. Китайский");
            Console.WriteLine("\t\t   2. Английский");
            Console.WriteLine("\t\t   3. Немецкий");
            Console.WriteLine("\t\t   4. Назад");
            Console.WriteLine("\t\t   0. Выход");
            Console.WriteLine("\n\n\t\t   Введите 1-4 или 0:");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\n**********************************************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            string choice = Console.ReadLine();
            ProcessDictionaryLanguageMenuChoice(choice);
        }

        private void ProcessDictionaryLanguageMenuChoice(string choice)
        {
            Console.Clear();

            switch (choice)
            {
                case "1":
                    ShowDictionaryTypeMenuChina();
                    break;
                case "2":
                    ShowDictionaryTypeMenuEnglish();
                    break;
                case "3":
                    ShowDictionaryTypeMenuDeutsche();
                    break;
                case "4":
                    ShowMainMenu();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    ShowDictionaryLanguageMenu();
                    break;
            }
        }

        private void ShowDictionaryTypeMenuChina()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("****   Выбрать тип словаря (направление перевода):   *****");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\n\n\n\t\t   1. Русско-Китайский");
            Console.WriteLine("\t\t   2. Китайско-Русский");
            Console.WriteLine("\t\t   3. Назад");
            Console.WriteLine("\t\t   0. Выход");
            Console.WriteLine("\n\n\t\t   Введите 1-3 или 0:");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n\n**********************************************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            string choice = Console.ReadLine();
            ProcessDictionaryTypeMenuChoiceChina(choice);
        }

        private void ProcessDictionaryTypeMenuChoiceChina(string choice)
        {
            Console.Clear();
            switch (choice)
            {
                case "1":
                    ShowDictionaryOperationsMenu("Русско-Китайский");
                    break;
                case "2":
                    ShowDictionaryOperationsMenu("Китайско-Русский");
                    break;
                case "3":
                    ShowDictionaryLanguageMenu();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    ShowDictionaryTypeMenuChina();
                    break;
            }
        }
        private void ShowDictionaryTypeMenuEnglish()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("****   Выбрать тип словаря (направление перевода):   *****");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\n\n\n\t\t   1. Русско-Английский");
            Console.WriteLine("\t\t   2. Англо-Русский");
            Console.WriteLine("\t\t   3. Назад");
            Console.WriteLine("\t\t   0. Выход");
            Console.WriteLine("\n\n\t\t   Введите 1-3 или 0:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n\n\n**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            string choice = Console.ReadLine();
            ProcessDictionaryTypeMenuChoiceEnglish(choice);
        }

        private void ProcessDictionaryTypeMenuChoiceEnglish(string choice)
        {
            Console.Clear();
            switch (choice)
            {
                case "1":
                    ShowDictionaryOperationsMenu("Русско-Английский");
                    break;
                case "2":
                    ShowDictionaryOperationsMenu("Англо-Русский");
                    break;
                case "3":
                    ShowDictionaryLanguageMenu();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    ShowDictionaryTypeMenuEnglish();
                    break;
            }
        }
        private void ShowDictionaryTypeMenuDeutsche()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("****   Выбрать тип словаря (направление перевода):   *****");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\n\n\n\t\t   1. Русско-Немецкий");
            Console.WriteLine("\t\t   2. Немецко-Русский");
            Console.WriteLine("\t\t   3. Назад");
            Console.WriteLine("\t\t   0. Выход");
            Console.WriteLine("\n\n\t\t   Введите 1-3 или 0:");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n\n\n\n**********************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            string choice = Console.ReadLine();
            ProcessDictionaryTypeMenuChoiceDeutsche(choice);
        }

        private void ProcessDictionaryTypeMenuChoiceDeutsche(string choice)
        {
            Console.Clear();
            switch (choice)
            {
                case "1":
                    ShowDictionaryOperationsMenu("Русско-Немецкий");
                    break;
                case "2":
                    ShowDictionaryOperationsMenu("Немецко-Русский");
                    break;
                case "3":
                    ShowDictionaryLanguageMenu();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    ShowDictionaryTypeMenuDeutsche();
                    break;
            }
        }


        public void ShowDictionaryOperationsMenu(string translationDirection)
        {
            if (translationDirection == "Русско-Китайский" || translationDirection == "Китайско-Русский")
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**********************************************************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"********    Выбран словарь: {translationDirection}    *********");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**********************************************************");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (translationDirection == "Русско-Английский" || translationDirection == "Англо-Русский")
            {

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("**********************************************************");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"********    Выбран словарь: {translationDirection}    *********");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**********************************************************");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (translationDirection == "Русско-Немецкий" || translationDirection == "Немецко-Русский")
            {

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("**********************************************************");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"********    Выбран словарь: {translationDirection}    *********");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("**********************************************************");
                Console.ForegroundColor = ConsoleColor.White;
            }


            Console.WriteLine("\n\t   Выберите действие:");
            Console.WriteLine("\n\t   1. Показать словарь");
            Console.WriteLine("\t   2. Добавить слово");
            Console.WriteLine("\t   3. Заменить слово или его перевод");
            Console.WriteLine("\t   4. Удалить слово или его перевод");
            Console.WriteLine("\t   5. Искать перевод слова");
            Console.WriteLine("\t   6. Экспортировать слово с переводом");
            Console.WriteLine("\t      в отдельный файл");
            Console.WriteLine("\t   7. Назад");
            Console.WriteLine("\t   0. Выход");
            Console.WriteLine("\n\t   Введите 1-7 или 0:");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n**********************************************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            string choice = Console.ReadLine();
            ProcessDictionaryOperationsMenuChoice(choice, translationDirection);
        }

        private void ProcessDictionaryOperationsMenuChoice(string choice, string translationDirection)
        {
            Console.Clear();
            switch (choice)
            {
                case "1":
                    dictionaryManager.ShowDictionary(translationDirection);
                    break;
                case "2":
                    dictionaryManager.AddWord(translationDirection);
                    break;
                case "3":
                    dictionaryManager.ReplaceWord(translationDirection);
                    break;
                case "4":
                    dictionaryManager.DeleteWord(translationDirection);
                    break;
                case "5":
                    dictionaryManager.SearchWord(translationDirection);
                    break;
                case "6":
                    dictionaryManager.ExportWord(translationDirection);
                    break;
                case "7":
                    if (translationDirection == "Русско-Немецкий" || translationDirection == "Немецко-Русский")
                        ShowDictionaryTypeMenuDeutsche();
                    if (translationDirection == "Русско-Английский" || translationDirection == "Англо-Русский")
                        ShowDictionaryTypeMenuEnglish();
                    else
                        ShowDictionaryTypeMenuChina();

                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    ShowDictionaryOperationsMenu(translationDirection);
                    break;
            }
        }
    }

}

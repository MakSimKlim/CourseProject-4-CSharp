using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
//using проект_CSharp;

namespace проект_CSharp
{
    class Program
    {
        static void Main()
        {
            // настройка параметров консоли
            Console.Title = "Приложение на С# 'РУССКИЙ МультиСЛОВАРЬ V1.0.0'";//задает заголовок консоли
            Console.SetWindowSize(60, 23);// задает размер окна консоли
            Console.SetBufferSize(60, 23);//убирает полосы прокруток (значения должны быть равными SetWindowSize)

            WordDictionaryManager dictionaryManager = new WordDictionaryManager();
            Menu menu = new Menu(dictionaryManager);

            while (true)
            {
                menu.ShowMainMenu();
            }
        }
    }
}


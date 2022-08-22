using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork;

namespace HomeWork_5
{
    //  1. Создать программу, которая будет проверять корректность ввода логина.
    //  Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры,
    //  при этом цифра не может быть первой.

    // решение предоставил Юрченко Н.А.

    class Task1
    {           
    /// <summary>
    /// Метод проверяющий логин на количество символов
    /// </summary>
    /// <param name="login">Введенный логин</param>
        static bool CheckLengthLogin(string login)
        {
            if (login.Length >= 2 && login.Length <= 10)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Метод проверяющий первый символ число или буква
        /// </summary>
        /// <param name="login">Введенный логин</param>
        static bool CheckFirstSymbolLogin(string login)
        {
            if (Char.IsLetter(login[0]))           
                return true;
            else
                return false;
        }

        /// <summary>
        /// Метод проверяющий на использование в логине букв латинского алфавита или цифр
        /// </summary>
        /// <param name="login">Введенный логин</param>
        static bool CheckingLoginCharacters(string login)
          {
              for (int i = 0; i < login.Length; i++)
              {
                if (!(Char.IsLetterOrDigit(login[i]) || login[i] >= 'a' && login[i] <= 'z' || login[i] >= 'A' && login[i] <= 'Z'))                    
                    return false;
            }

            return true;
          }

        /// <summary>
        /// Метод проверяющий логин на заданные условия и присваивающий значение переменной
        /// </summary>
        /// <returns></returns>
        static string ReadLogin()
        {
            bool check = true;
            string login;

            do
            {
                login = Console.ReadLine();                

                if (!CheckFirstSymbolLogin(login))
                {
                    check = false;
                    Console.WriteLine("Логин должен начинаться с буквы\n");
                    Console.Write("Повторите ввод: ");
                    continue;
                }

                if (!CheckLengthLogin(login))
                {
                    check = false;
                    Console.WriteLine("Логин должен быть не менее двух и не более десяти символов\n");
                    Console.Write("Повторите ввод: ");
                    continue;
                }

                if (!CheckingLoginCharacters(login))
                {
                    check = false;
                    Console.WriteLine("Логин может содержать только буквы латинского алфавита или цифры\n");
                    Console.Write("Повторите ввод: ");
                    continue;
                }

                check = true;

            }
            while (check == false);

            return login;
        }
        


        static void Main(string[] args)
        {
            var screen = new Screen();
            screen.ScreenPrint(5, 1);
            // Вызов метода ScreenPrint cо второй домашней работы, для вывода номера задания 
            // и домашней работы, а также вывода ФИО выполнившего студента

            string login;

            Console.Write("Введите логин: ");

            login = ReadLogin();

            Console.WriteLine("Нажмите любую клавишу для выхода");

            Console.ReadLine();
        }
    }
}

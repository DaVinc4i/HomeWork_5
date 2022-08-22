using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork;


namespace HomeWork_5
{
    /* 2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
     * а) Вывести только те слова сообщения, которые содержат не более n букв.
     * б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
     * в) Найти самое длинное слово сообщения.
     * г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
     * д) *** Создать метод, который производит частотный анализ текста.
     * В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает 
     * сколько раз каждое из слов массива входит в этот текст.Здесь требуется использовать класс Dictionary. */

    // решение предоставил Юрченко Н.А.
    class Message
    {
        private static string[] message { get; set; }

        /// <summary>
        /// Свойство преобразующее введенную строку в массив слов
        /// </summary>
        public string Read
        {
            set { message = value.Split(' ', '?', ',', '.', '-', '!', ';', ':', ')', '('); }
        }

        /// <summary>
        /// Метод выводящий слова с символами не более заданного количества символов
        /// </summary>
        /// <param name="n">Число символов в слове</param>
        /// <returns></returns>
        public static string PrintWords(int n)
        {
            string newMessage = null;

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i].Length <= n)
                    newMessage += message[i] + " ";
            }
            return newMessage;
        }

        /// <summary>
        /// Метод выводящий слова введенного сообщения, за исключением тех, которые заканчиваются на заданный символ
        /// </summary>
        /// <param name="symbol">Заданный символ</param>
        /// <returns></returns>
        public static string RemoveWords(char symbol)
        {
            string newMessage = "";
            for (int i = 0; i < message.Length; i++)
            {
                if (!message[i].EndsWith(symbol.ToString()))
                    newMessage += message[i] + " ";
            }
            return newMessage;
        }

        /// <summary>
        /// Метод проводящий сортировку и возвращающий первое самое длинное слов
        /// </summary>
        /// <returns></returns>
        public static string FindLongestWord()
        {
            var newMessage = message;

            for (int i = 0; i < newMessage.Length; i++)
            {
                for (int j = i + 1; j < newMessage.Length; j++)
                {
                    if (newMessage[i].Length < newMessage[j].Length)
                    {
                        string temp = newMessage[i];
                        newMessage[i] = newMessage[j];
                        newMessage[j] = temp;
                    }
                }
            }
            
                return newMessage[0];
                        

        }

        /// <summary>
        /// Метод выводящий строку из самых длинных слов в сообщении
        /// </summary>
        /// <returns></returns>
        public static string BuildLongString()
        {
            StringBuilder newString = new StringBuilder();

            newString.Append(Message.FindLongestWord());// самое длинное слово в сообщении
                       
                for(int i = 1; i < message.Length; i++)     
                if (message[i].Length == message[i - 1].Length && Message.FindLongestWord().Length == message[i].Length)
                    newString.Append(" "+message[i]);
                
            return newString.ToString();
        }
    }

    class Task2
    {
        #region Методы преобразования в строки в типы
        /// <summary>
        /// Преобразование строки в число
        /// </summary>
        /// <param name="value">Введенное значение</param>
        /// <returns></returns>
        static int Parsing(string value)
        {
            int number;
            bool result = int.TryParse(value, out number);

            if (value == "")
                value = null;

            while (value == null && result == false)
            {
                Console.Write("Повторите ввод:  ");
                value = Console.ReadLine();
                result = int.TryParse(value, out number);

                if (value == "")
                    value = null;
            }

            return number;
        }

        /// <summary>
        /// Преобразование строки в символ типа Char
        /// </summary>
        /// <param name="value">Введенное значение</param>
        /// <returns></returns>
        static char ParsingChar(string value)
        {
            char symbol;
            bool result = char.TryParse(value, out symbol);

            if (value == "")
                value = null;

            while (value == null && result == false)
            {
                Console.Write("Повторите ввод:  ");
                value = Console.ReadLine();
                result = char.TryParse(value, out symbol);

                if (value == "")
                    value = null;
            }

            return symbol;
        }
        #endregion

        static void Main(string[] args)
        {
            var screen = new Screen();
            screen.ScreenPrint(5, 2);
            // Вызов метода ScreenPrint cо второй домашней работы, для вывода номера задания 
            // и домашней работы, а также вывода ФИО выполнившего студента

            Message message = new Message();
            Console.Write("Введите сообщение для работы: ");
            message.Read = Console.ReadLine();

            Console.Write("Для вывода слов не более заданной длины, введите количество букв (n): ");
            string value = Console.ReadLine();
            int n = Parsing(value);
            Console.WriteLine(Message.PrintWords(n)+"\n");

            Console.Write("Введите символ, слова оканчивающиеся на который будут удалены: ");
            value = Console.ReadLine();
            char symbol = ParsingChar(value);
            Console.WriteLine(Message.RemoveWords(symbol) + "\n");

            Console.Write("Самое длинное слово в строке это: ");
            Console.WriteLine(Message.FindLongestWord()+"\n");

            Console.Write("Строка из самых длинных слов с помощью StringBuilder: ");
            Console.WriteLine(Message.BuildLongString());

            Console.ReadLine();
        }
    }
}




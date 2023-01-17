using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
    internal abstract class EnterData
    {
        /**
         * Метод ввода и валидации целого числа в диапазоне
         *
         * @param minVariant минимальное число
         * @param maxVariant максимальное число
         * @return введенное целое число
         * @throws RuntimeException
         */
        protected int InputInt(int minVariant, int maxVariant)
        {
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                throw new Exception("You didn't input anything");
            }
            catch (FormatException)
            {
                throw new FormatException("This is not number.");
            }
            catch (Exception)
            {
                throw new Exception("Something wrong.");
            }
            if (num < minVariant || num > maxVariant)
            {
                throw new Exception("You entered an invalid value.");
            }
            return num;
        }

        /**
         * Метод ввода и валидации целого числа в диапазоне
         *
         * @param minVariant минимальное число
         * @param maxVariant максимальное число
         * @return введенное целое число
         * @throws RuntimeException
         */
        protected long InputLong(long minVariant, long maxVariant)
        {
            long num;
            try
            {
                num = long.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                throw new Exception("You didn't input anything");
            }
            catch (FormatException)
            {
                throw new FormatException("This is not number.");
            }
            catch (Exception)
            {
                throw new Exception("Something wrong.");
            }
            if (num < minVariant || num > maxVariant)
            {
                throw new Exception("You entered an invalid value.");
            }
            return num;
        }

        /**
         * Метод ввода строки и ее валидация на пустую строку
         *
         * @return строку
         */
        protected string InputString()
        {
            string? str = string.Empty;
            try
            {
                str = Console.ReadLine();
            }
            catch (Exception)
            {
                throw new Exception("Something wrong.");
            }
            if (String.IsNullOrEmpty(str))
            {
                throw new Exception("You must something enter");
            }
            return str;
        }

        /**
         * Meтод ввода даты и ее валидация
         *
         * @return дата
         * @throws RuntimeException
         */
        protected DateTime InputDate()
        {
            string str;
            DateTime date;
            try
            {
                str = Console.ReadLine();
            }
            catch (Exception)
            {
                throw new Exception("Something wrong.");
            }
            if (String.IsNullOrEmpty(str))
            {
                throw new Exception("You must something enter");
            }
            try
            {
                date = DateTime.Parse(str);
            }
            catch (FormatException)
            {
                throw new FormatException("You must enter date");
            }
            return date;
        }
    }
}

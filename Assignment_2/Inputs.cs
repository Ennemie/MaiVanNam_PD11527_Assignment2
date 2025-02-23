using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Assignment_2
{
    public class Inputs
    {
        public static string InputName(string message) //Hàm nhập họ tên
        {
            string name;
            while(true)
            {
                Console.Write(message);
                name = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Vui lòng không để trống họ tên!");
                }
                else if (Regex.IsMatch(name, @"\d") || Regex.IsMatch(name, @"[^A-Za-zÀ-Ỹà-ỹ\s]"))
                {
                    Console.WriteLine("Vui lòng nhập tên hợp lệ!");
                }
                else return name;
            }
        }
        public static double InputGrade(string message) //Hàm nhập điểm
        {
            double grade;
            bool isValid;
            do
            {
                Console.Write(message);
                isValid = double.TryParse(Console.ReadLine(), out grade);
                if (!isValid || grade < 0 || grade > 10)
                {
                    Console.WriteLine("Vui lòng nhập số điểm hợp lệ từ 0 -> 10!");
                    isValid = false;
                }
            } while (!isValid);
            return grade;
        }
        public static string InputEmail(string message) //Hàm nhập email
        {
            string email;
            string patternEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            while (true)
            {
                Console.Write(message);
                email = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Vui lòng không để trống email!");
                    continue;
                }
                else if (!Regex.IsMatch(email, patternEmail))
                {
                    Console.WriteLine("Vui lòng nhập email hợp lệ!");
                    continue;
                }
                else
                {
                    return email;
                }
            }
        }
        public static int InputInt(string message) //Hàm nhập số nguyên
        {
            int x;
            bool isValid;
            do
            {
                Console.Write(message);

                isValid = int.TryParse(Console.ReadLine(), out x);
                if (!isValid) Console.WriteLine("Vui lòng nhập số hợp lệ!");
            } while (!isValid);
            return x;
        }
        public static double InputDouble(string message) // Hàm nhập số thực
        {
            double x;
            bool isValid;
            do
            {
                Console.Write(message);

                isValid = double.TryParse(Console.ReadLine(), out x);
                if (!isValid) Console.WriteLine("Vui lòng nhập số hợp lệ!");
            } while (!isValid);
            return x;
        }
    }
}

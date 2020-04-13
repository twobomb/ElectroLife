using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectroLife
{
    public class Utils
    {
        public static long next = Constant.SEED;

    public static double rand()
    {
        next = (214013*next + 2531011)%4294967296; //Линейный конгруэнтный метод (a*x + c) % m
        return (double)next / 4294967296f;
    }

        public static void log(string str)
        {
            Console.WriteLine(str);
            
        }

        public static string minFormat(object str1, int min, string symb = " ")
        {
            string str = str1.ToString();
            while (str.Length < min)
                str = symb + str;
            return str;

        }
        public static int getRandInt(int min, int max)
        {
            return (int) (min + Math.Round(rand() * (max-min)));
        }

    }
}

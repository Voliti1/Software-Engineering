using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friday_Software_Engineering
{
    internal class Function
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Hello("김길동"));
            Console.WriteLine(Hello("이민호"));

            string result = Hello("서준원");
            Console.WriteLine($"신입생인사 : {result}");

            Console.WriteLine(Add(2, 1));
            Add2(2, 1);

            Console.WriteLine(Sub(2, 1));
        }

        static string Hello(string name)
        {
            string hi = "제 이름은 " + name + "입니다. 만나서 반갑습니다.";
            return hi;
        }

        static string Add(int a, int b)
        {
            int result = a + b;
            return $"두 수의 합은 {result}";
        }

        static void Add2(int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"두 수의 합은 {result}");
        }

        static string Sub(int a, int b)
        {
            int result = a - b;
            return $"두 수의 차는 {result}";
        }
    }
}

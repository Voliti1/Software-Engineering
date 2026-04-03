using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friday_Software_Engineering
{
    internal class Control
    {
        static void Main(string[] args)
        {
            Console.WriteLine("숫자를 입력하세요");
            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            //if (num > 0)
            //{
            //    Console.WriteLine($"{num}는 양수입니다.");
            //    //Console.WriteLine(num + "는 양수입니다.");
            //}
            //else if (num < 0)
            //{
            //    Console.WriteLine($"{num}는 음수입니다.");
            //}
            //else
            //{
            //    Console.WriteLine("입력된 수는 0입니다.");
            //}

            //for (int i = 0; i <= num; i++)
            //{
            //    //if (i % 2 == 1)
            //    //    sum += i;

            //    if (i % 2 == 0)
            //        continue;
            //    sum += i;


            //}

            for (int i = 1; ; i+=2)
            {
                if (i > num)
                    break;
                sum += i;                
            }

            Console.WriteLine($"1부터 {num}까지의 합은 {sum}입니다.");
        }
    }
}

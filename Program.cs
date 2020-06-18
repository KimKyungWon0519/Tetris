//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System.Threading;

//namespace ConsoleApp2
//{
//    class Program
//    {


//        static void Main(string[] args)
//        {
//            int i, j, k;
//            int num = 0;

//            byte[,] font = new byte[2, 8] {
//                {0x00,0x38,0x44,0x04,0x08,0x10,0x20,0x7c},
//                {0x00,0x38,0x44,0x04,0x18,0x04,0x44,0x38}
//            };

//            Console.Clear();

//            for(k = 0; k < 8; k++)
//            {
//                for(j = 0; j < 2; j++)
//                {
//                    for(i = 0; i < 8; i++)
//                    {
//                        if ((font[j, k] & (0x01 << (7 - i))) > 0)
//                        {
//                            Console.Write("*");
//                        }
//                        else
//                        {
//                            Console.Write(" ");
//                        }
//                    }

//                    Console.Write("\t");
//                }

//                Console.WriteLine();
//            }
//        }
//    }
//}

using System;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        public static int overlap_count = 0;
        public static int line_count = 0;
        public static void delete_block(int x, int y, int[,] block_L)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (block_L[j, i] == 1)
                    {
                        Console.SetCursorPosition(x + i, y + j);
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void make_block(int x, int y, int[,] block_L)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (block_L[j, i] == 1)
                    {
                        Console.SetCursorPosition(x + i, y + j);
                        Console.Write("*");
                    }
                }

                Console.WriteLine();
            }
        }

        public static int overlapCheck(int[,] block_L, int[,] background, int x, int y)
        {
            int overlap_count = 0;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (block_L[j, i] == 1 && background[j + y, i + x] == 1)
                    {
                        overlap_count++;
                    }
                }
            }

            return overlap_count;
        }

        public static void draw_background(int[,] background)
        {
            Console.SetCursorPosition(0, 0);
            for (int j = 0; j < 12; j++)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (background[j, i] == 1)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("*");
                    }
                    else
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("-");
                    }
                }

                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int count = 0;
            int x = 4;
            int y = 1;
            int[,] block_L = new int[4, 4] {
                { 0,0,0,0 },
                { 0,1,0,0 },
                { 0,1,1,1 },
                { 0,0,0,0 }
            };
            int[,] background = new int[12, 12]
            {
                { 1,1,1,1,1,1,1,1,1,1,1,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,1,0,0,0,0,0,0,0,0,0,1 },
                { 1,1,1,1,1,1,1,1,1,1,1,1 },
            };
            ConsoleKeyInfo key_value;
            String ch;

            draw_background(background);

            while (true)
            {
                if (count == 10)
                {
                    count = 0;

                    overlap_count = overlapCheck(block_L, background, x, y + 1);

                    if (overlap_count == 0)
                    {
                        delete_block(x, y, block_L);

                        //----------------------------------------------------

                        y++;

                        //----------------------------------------------------

                        make_block(x, y, block_L);
                    }
                    else
                    {
                        for(int j = 0; j < 4; j++)
                        {
                            for(int i = 0; i < 4; i++)
                            {
                                if(block_L[j, i] == 1)
                                {
                                    background[j + y, i + x] = 1;
                                }
                            } 
                        }

                        //---------------------------------------------------
                        line_count = 0;

                        for(int i = 1; i <= 10; i++)
                        {
                            if(background[10, i] == 1)
                            {
                                line_count++;
                            }
                        }

                        if(line_count == 10)
                        {
                            for (int j = 10; j > 1; j--)
                            {
                                for (int i = 1; i < 10; i++)
                                {
                                    background[j, i] = background[j - 1, i];
                                }
                            }

                            draw_background(background);
                        }

                        //--------------------------------------------------

                        y = 1;
                    }
                }

                if (Console.KeyAvailable)
                {

                    key_value = Console.ReadKey(true);
                    ch = key_value.Key.ToString();

                    if (ch == "A")
                    {
                        overlap_count = overlapCheck(block_L, background, x - 1, y);

                        if (overlap_count == 0)
                        {
                            delete_block(x, y, block_L);

                            //----------------------------------------------------

                            x--;

                            //----------------------------------------------------

                            make_block(x, y, block_L);
                        }
                    }
                    else if (ch == "D")
                    {
                        overlap_count = overlapCheck(block_L, background, x + 1, y);

                        if (overlap_count == 0)
                        {
                            delete_block(x, y, block_L);

                            //----------------------------------------------------

                            x++;

                            //----------------------------------------------------

                            make_block(x, y, block_L);
                        }
                    }
                    else if (ch == "W")
                    {
                        overlap_count = overlapCheck(block_L, background, x, y - 1);

                        if (overlap_count == 0)
                        {
                            delete_block(x, y, block_L);

                            //----------------------------------------------------

                            y--;

                            //----------------------------------------------------

                            make_block(x, y, block_L);
                        }
                    }
                    else if (ch == "S")
                    {
                        overlap_count = overlapCheck(block_L, background, x, y + 1);

                        if (overlap_count == 0)
                        {
                            delete_block(x, y, block_L);

                            //----------------------------------------------------

                            y++;

                            //----------------------------------------------------

                            make_block(x, y, block_L);
                        }
                    }
                }
                
                count++;
                Thread.Sleep(100);


            }


        }
    }
}
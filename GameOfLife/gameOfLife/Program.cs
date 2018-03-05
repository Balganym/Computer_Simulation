using System;
using System.Text;

namespace gameOfLife
{        
    static class Program
    {
        static int xpos;
        static int ypos;

        static int[] ngx = {-1,-1,-1,1,1,1,0,0};
        static int[] ngy = {0,1,-1,1,-1,0,1,-1};

        static string cellChar = "O";

        static bool[,] Cells = new bool[50, 25];

        static ConsoleKeyInfo cki;

        static void Main(string[] args)
        {
            Console.WriteLine("Move the cursor with the arrow keys, and press spacebar to make a cell alive");
            Console.WriteLine("Press s button to start the game");
            Console.WriteLine("Press any key to start planting cells");
            Console.ReadKey();
            Console.Clear();
            game_loop();
        }
        static void read_cursor_position()
        {
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.UpArrow)
            {
                remove_char();
             
                if (ypos == 0);
                else
                {
                    ypos--;
                }
                
            }

            if (cki.Key == ConsoleKey.DownArrow)
            {
                remove_char();
                ypos++;
            }

            if (cki.Key == ConsoleKey.LeftArrow)
            {
                remove_char();
                if (xpos == 0);
                else
                {
                    xpos--;
                }
            }

            if (cki.Key == ConsoleKey.RightArrow)
            {
                remove_char();
                xpos++;
            }

            if (cki.Key == ConsoleKey.Spacebar)
            {
                remove_char();
                plant_cell();
            }

            if (cki.Key == ConsoleKey.S)
            {
                while (true)
                {
                    start_algorithm();
                }
            }
        }

        static int neighbours(int x, int y)
        {

            // int neighbours = 0;

            // for (int i = 0; i < 8; ++i){
            //     if(Cells[x+ngx[i], y+ngy[i]]){
            //         neighbours++;
            //     }
            // }
            // return neighbours;


            int neighbours = 0;

            if (Cells[x - 1, y - 1])
            {
                neighbours++;
            }
            if (Cells[x, y - 1])
            {
                neighbours++;
            }
            if (Cells[x + 1, y - 1])
            {
                neighbours++;
            }
            if (Cells[x - 1, y])
            {
                neighbours++;
            }
            if (Cells[x + 1, y])
            {
                neighbours++;
            }
            if (Cells[x - 1, y + 1])
            {
                neighbours++;
            }
            if (Cells[x, y + 1])
            {
                neighbours++;
            }
            if (Cells[x + 1, y + 1])
            {
                neighbours++;
            }

            return neighbours;
        }

        static void start_algorithm()
        {
            bool[,] new_generation = new bool[50, 25];

            for (int x = 1; x < 49; x++)
            {
                for (int y = 1; y < 24; y++)
                {
                    if (Cells[x, y])
                    {
                        if (neighbours(x,y) >= 2 && neighbours(x, y) <= 3)
                        {
                            new_generation[x, y] = true;
                        }
                        else
                        {
                            new_generation[x, y] = false;
                        }
                    }
                    else
                    {
                        if (neighbours(x,y) == 3)
                        {
                            new_generation[x, y] = true;
                        }
                        else 
                        {
                            new_generation[x, y] = false;
                        }
                    }
                    draw_cells(x, y,new_generation);
                }
            }

            Cells = null;

            Cells = new_generation;
        }

        static void draw_cells(int x, int y,bool[,] cells)
        {
            if (cells[x, y] == true)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(cellChar);
            }
            else
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(" ");
            }
        }

        static void draw_cursor()
        {
            Console.SetCursorPosition(xpos, ypos);
            Console.WriteLine("#");
        }

        static void plant_cell()
        {
            Cells[xpos, ypos] = true;
            Console.SetCursorPosition(xpos, ypos);
            Console.WriteLine(cellChar);
        }

        static void remove_char()
        {
            Console.SetCursorPosition(xpos, ypos);
            if (Cells[xpos, ypos])
            {
                Console.Write(cellChar);
            }
            else
            {
                Console.Write(" ");
            }
        }

        static void game_loop()
        {
            while (true)
            {
                read_cursor_position();
                draw_cursor();
            }
        }
    }
}


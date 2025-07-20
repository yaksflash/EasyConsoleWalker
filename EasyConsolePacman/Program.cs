using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsolePacman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            char[,] map =
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                { '#', ' ', ' ', '#', 'x', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', 'x', ' ', '#'},
                { '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', 'x', '#', ' ', ' ', ' ', ' ', '#', '#', ' ', '#'},
                { '#', ' ', 'x', '#', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', '#', '#', 'x', ' ', '#'},
                { '#', ' ', '#', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', 'x', '#', ' ', '#', '#', ' ', '#'},
                { '#', ' ', '#', ' ', ' ', ' ', '#', '#', ' ', ' ', ' ', '#', 'x', ' ', '#', ' ', ' ', '#'},
                { '#', ' ', '#', ' ', ' ', '#', 'x', ' ', ' ', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', '#', ' ', '#', '#', '#', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', 'x', ' ', ' ', ' ', '#', '#', '#', '#', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', '#', ' ', 'x', '#', ' ', ' ', ' ', ' ', '#'},
                { '#', '#', ' ', ' ', '#', ' ', '#', ' ', ' ', '#', ' ', '#', ' ', ' ', '#', '#', ' ', '#'},
                { '#', 'x', ' ', ' ', '#', 'x', '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', 'x', ' ', '#'},
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };

            Console.SetCursorPosition(0, 0);

            int userX = 1, userY = 1;
            int coins = 0;
            int coinCounter = 0;

            bool isOpen = true;
            while (isOpen)
            {
                coinCounter = 0;
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j] == 'x')
                        {
                            coinCounter++;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(map[i, j]);
                        }
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();

                Console.SetCursorPosition(userY, userX);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('@');
                Console.ResetColor();

                Console.SetCursorPosition(5, 20);
                if (coinCounter == 0)
                {
                    Console.WriteLine($"Вы собрали {coins} монеток и победили!");
                    isOpen = false;
                }
                else 
                { 
                Console.WriteLine($"Ваши монетки: {coins}");
                Console.WriteLine($"Осталось монеток: {coinCounter}");
                }

                ConsoleKeyInfo tappedKey = Console.ReadKey();
                switch (tappedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[userX - 1, userY] != '#')
                        {
                            if (map[userX - 1, userY] == 'x')
                            {
                                coins += 1;
                                map[userX - 1, userY] = ' ';
                            }
                            --userX;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[userX + 1, userY] != '#')
                        {
                            if (map[userX + 1, userY] == 'x')
                            {
                                coins += 1;
                                map[userX + 1, userY] = ' ';
                            }
                            ++userX;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[userX, userY - 1] != '#')
                        {
                            if (map[userX, userY - 1] == 'x')
                            {
                                coins += 1;
                                map[userX, userY - 1] = ' ';
                            }
                            --userY;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[userX, userY + 1] != '#')
                        {
                            if (map[userX, userY + 1] == 'x')
                            {
                                coins += 1;
                                map[userX, userY + 1] = ' ';
                            }
                            ++userY;
                        }
                        break;

                }

                Console.Clear();
            }

            
        }
    }
}

using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace small_consolegame
{



    class Program
    {

     
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vKey);


        static void Main(string[] args)
        {
            Snake snake = new Snake();
            Apple apple = new Apple();

            char[,] map = new char[50, 50];


            Random applePos = new Random();
            
            bool goUp = false;
            bool goDown = false;
            bool goRight = false;
            bool goLeft = false;
            bool isTaken = false;

            int _progress = 1000;
            bool _gameOver = false;

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    map[i, j] = ' ';
                }
            }

            while (true)
            {
                Console.WriteLine("SNAKE_CONSOLE_V2.1" + snake.point);
                Console.WriteLine("Point: " + snake.point);

                if(_gameOver == false && snake.posX >= 0 && snake.posX <= 19 && snake.posY >= 0 && snake.posY <= 14)
                { 
                    for (int i = 0; i < 15; i++)
                    {
                     for (int j = 0; j < 20; j++)
                     {
                      Console.Write(map[i,j]);
                     }

                 Console.WriteLine("");

                    }

                    for(int y = 0; y < 15; y++) //left
                    {
                        map[y, 0] = '#';
                    }

                    for (int y = 0; y < 15; y++) //right
                    {
                        map[y, 19] = '#';
                    }
                    
                    for (int x = 0; x < 20; x++) //up
                    {
                        map[0,x] = '#';
                    }

                    for (int x = 0; x < 20; x++) //down
                    {
                        map[14, x] = '#';
                    }
                    

                    map[snake.posY, snake.posX] = 'O';
                     System.Threading.Thread.Sleep(_progress);
                     System.Console.Clear();
                     moveSnake();
                     checkPoint();
                }else
                {
                    break;
                }

            }

          

           void moveSnake()
            {
                bool w = (GetAsyncKeyState('W') & 1) != 0;
                bool s = (GetAsyncKeyState('S') & 1) != 0;
                bool a = (GetAsyncKeyState('A') & 1) != 0;
                bool d = (GetAsyncKeyState('D') & 1) != 0;

                // Snake movement
                if (w == true)
                {
                    goUp = true;
                    goDown = false;
                    goRight = false;
                    goLeft = false;
                }
                if (s == true)
                {
                    goDown = true;
                    goUp = false;
                    goRight = false;
                    goLeft = false;
                }
                if (a == true)
                {
                    goLeft = true;
                    goUp = false;
                    goDown = false;
                    goRight = false;
                }
                if (d == true)
                {
                    goRight = true;
                    goUp = false;
                    goDown = false;
                    goLeft = false;
                }

                if (snake.posX != 20 && snake.posY != 15)
                {

                    if (goUp == true)
                    {
                        if (snake.posY > 0)
                        {
                            if (map[snake.posY - 1, snake.posX] == 'O')
                            {
                                gameOver();
                            }
                            snake.posY--;
                        }else gameOver();

                    }

                    if (goDown == true)
                    {
                        if (map[snake.posY + 1, snake.posX] == 'O')
                        {
                            gameOver();
                        }
                        snake.posY++;
                    }

                    if (goRight == true)
                    {
                        if (map[snake.posY, snake.posX + 1] == 'O')
                        {
                            gameOver();  
                        }
                        snake.posX++;
                    }

                    if(snake.posX > 0)
                    { 
                         if (goLeft == true)
                         {
                               if (map[snake.posY, snake.posX - 1] == 'O')
                               {
                                 gameOver();
                               }
                               snake.posX--;
                         }
                    }else gameOver();


                }
                else
                {
                    gameOver();
                }
            }

            void checkPoint()
            {
                if (isTaken == false)
                {

                    while (true)
                    {
                        applePos = new Random();

                        for (int i = 0; i < 5; i++) //rand loop
                        {
                            apple.PosX = applePos.Next(1, 19);
                            apple.PosY = applePos.Next(1, 14);
                        }

                        if (map[apple.PosX, apple.PosY] == ' ')
                        {
                            map[apple.PosX, apple.PosY] = 'X';
                            break;
                        }

                    }

                    isTaken = true;
                }

                if (snake.posX == apple.PosY && snake.posY == apple.PosX)
                {
                    isTaken = false;
                    snake.point += apple.point;
                    _progress -= 50;
                    if (_progress <= 50)
                        _progress = 50;
                }
            }


            void gameOver()
            {
                _gameOver = true;
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("GAME OVER\nGAME OVER\nGAME OVER\nGAME OVER\n");
                Console.WriteLine("GAME OVER\nGAME OVER\nGAME OVER\nGAME OVER\n");
                Console.WriteLine("GAME OVER\nGAME OVER\nGAME OVER\nGAME OVER\n");
                Console.WriteLine("GAME OVER\nGAME OVER\nGAME OVER\nGAME OVER\n");
                Console.WriteLine("GAME OVER\nGAME OVER\nGAME OVER\nGAME OVER\n");
                Console.WriteLine("GAME OVER\nGAME OVER\nGAME OVER\nGAME OVER\n");
                Console.WriteLine("GAME OVER\nGAME OVER\nGAME OVER\nGAME OVER\n");
                Console.WriteLine("GAME OVER\nGAME OVER\nGAME OVER\nGAME OVER\n");
                

            }

        }
    }
}

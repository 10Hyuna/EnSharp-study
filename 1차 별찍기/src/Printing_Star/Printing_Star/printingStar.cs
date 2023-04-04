using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Printing_Star
{
    public class PrintingStar
    {
        private int Line;

        public PrintingStar(int Row)
        {
            Line = Row;
        }

        public void Triangle()
        {
            for(int i=1;i<=Line; i++)
            {
                for (int j = 1; j <= Line-i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();

            }
        }

        public void ReverseTriangle()
        {
            for (int i =Line;i>= 1; i--)
            {
                for (int j = 1; j <= Line - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }

        public void SandGlass()
        {
           for(int i=Line;i>=1;i--)
            {
                for (int j = 1; j <= Line - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
           
           for(int i = 2; i <= Line; i++)
            {
                for (int j = 1; j <= Line - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        public void Diamond()
        {
            for(int i=1;i<=Line;i++)
            {
                for (int j = 1; j <= Line - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
            for(int i=Line-1;i>=1;i--)
            {
                for(int j=1;j<=Line-i;j++)
                    Console.Write(" ");
                for(int j=1;j<=2*i-1;j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
    }

    public class GameStart
    {
        private int ShapeLine;
        public void Menu()
        {
            Console.WriteLine("☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆☆*☆*☆*☆*☆*☆*☆*☆*");
            Console.WriteLine(" *                                                                *");
            Console.WriteLine("☆                                                                ☆");
            Console.WriteLine(" *             *                            *******               *");
            Console.WriteLine("☆             ***                            *****               ☆");
            Console.WriteLine(" *           *****                            ***                 *");
            Console.WriteLine("☆           *******                            *                 ☆");
            Console.WriteLine(" *                                                                *");
            Console.WriteLine("☆        1. 정삼각형                     2. 역삼각형             ☆");
            Console.WriteLine(" *                                                                *");
            Console.WriteLine("☆                                                                ☆");
            Console.WriteLine(" *                                                                *");
            Console.WriteLine("☆           *****                              *                 ☆");
            Console.WriteLine(" *           ***                              ***                 *");
            Console.WriteLine("☆             *                              *****               ☆");
            Console.WriteLine(" *           ***                              ***                 *");
            Console.WriteLine("☆           *****                              *                 ☆");
            Console.WriteLine(" *                                                                *");
            Console.WriteLine("☆        3. 모래시계                    4. 다이아몬드            ☆");
            Console.WriteLine(" *                                                                *");
            Console.WriteLine("☆                                                                ☆");
            Console.WriteLine(" *                                                                *");
            Console.WriteLine("☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*☆*");
        }

        public void SelectType()
        {
            Menu();
            Console.WriteLine();
            Console.Write("출력하고자 하는 도형의 번호를 입력하시오: ");
            int SelectNum = int.Parse(Console.ReadLine());
            if (SelectNum>=1&&SelectNum<=4)
            {
                LineNum(SelectNum);
            }
            else
            {
                ErrorNum();
            }
        }
        public void LineNum(int SelectNum)
        {
            Console.WriteLine();
            Console.Write("출력하고자 하는 도형의 줄 수를 입력하시오: ");
            ShapeLine = int.Parse(Console.ReadLine());
            Console.Clear();
            PrintShape(SelectNum);

        }
        public void ErrorNum()
        {
            int Num = 0;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Menu();
                Console.Write("잘못된 입력입니다. 1부터 4 사이의 번호를 입력해 주세요.");
                Num = int.Parse(Console.ReadLine());
                if (Num >= 1 && Num <= 4)
                {
                    exit = true;
                }
            }
            LineNum(Num);
        }
        public void PrintShape(int SelectNum)
        {
            PrintingStar printingStar = new PrintingStar(ShapeLine);
            switch (SelectNum)
            {
                case 1:
                    printingStar.Triangle();
                    break;
                case 2:
                    printingStar.ReverseTriangle();
                    break;
                case 3:
                    printingStar.SandGlass();
                    break;
                case 4:
                    printingStar.Diamond();
                    break;
            }
        }
        public int ReturnPrint()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine();
            Console.WriteLine("다시 시도하시겠습니까?");
            Console.WriteLine("1. 예     2. 아니요");
            int Exit = int.Parse(Console.ReadLine());
            return Exit;
        }
    }
    class printingStar
    {
        static void Main(string[] args)
        {
            int exit = 1;

            GameStart gameStart = new GameStart();
            GameStart ExitRandomValue = new GameStart();

            while (exit == 1)
            {
                gameStart.SelectType();
                exit = ExitRandomValue.ReturnPrint();
                Console.Clear();
            }
        }
    }
}
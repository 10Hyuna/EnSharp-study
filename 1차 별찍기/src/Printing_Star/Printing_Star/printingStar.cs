using System;
using System.Reflection.Metadata;

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
                    Console.Write("");
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

            for (int i = 1; i <= Line; i++)
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
    class printingStar
    {
        static void Main(string[] args)
        {
            int exit = 1;

            while(exit == 1)
            {
                Console.Clear();
                Console.WriteLine("1번: 정삼각형");
                Console.WriteLine("2번: 역삼각형");
                Console.WriteLine("3번: 모래시계");
                Console.WriteLine("4번: 다이아몬드");
                Console.WriteLine();
                Console.Write("출력하고자 하는 도형의 번호를 선택하시오: ");
                int Num = 0, row;
                while(Num<1||Num>4)
                {
                    Num = int.Parse(Console.ReadLine());
                    if(Num<1||Num>4)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("다시 시도하시겠습니까?");
                        Console.WriteLine("1. 다시 시도     2. 종료");
                        exit=int.Parse(Console.ReadLine());
                        if (exit == 0)
                            break;
                        else
                            Num = 0;
                    }
                }
                Console.Write("출력하고자 하는 도형의 높이를 입력하시오: ");
                row = int.Parse(Console.ReadLine());
                PrintingStar printingStar = new PrintingStar(row);
                Console.Clear();
                switch(Num)
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
                Console.WriteLine("다시 시도하시겠습니까?");
                Console.WriteLine("1. 예     2. 아니요");
                exit= int.Parse(Console.ReadLine());
            }
        }
    }
}
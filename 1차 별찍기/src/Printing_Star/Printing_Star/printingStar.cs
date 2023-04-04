using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Printing_Star 
{
    public class PrintingStar   // 출력하고자 하는 별의 모양에 따라 출력하는 클래스
    {
        private int Line;   // Line 함수를 사용자가 직접 접근할 수 없게  private 변수로 선언

        public PrintingStar(int Row)    // 다른 클래스나 함수에서 호출할 수 있는 생성자 // 여기서 출력될 별의 줄 수를 저장
        {
            Line = Row;
        }

        public void Triangle()  // 사용자가 가운데로 정렬된 삼각형을 출력하고자 할 때
        {
            for(int i=1;i<=Line; i++)   // 입력받은 줄 수만큼 반복
            {
                for (int j = 1; j <= Line-i; j++)      // 한 줄에서 i, 즉 몇 번째 줄인지에 따라 전체 줄 수에서 i만큼을 뺀 값에 공백을 출력
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)    // 삼각형을 출력하기 위해서는 한 줄에 별의 모양이 홀수 개로 존재해야 하고, 몇 번째 줄인지, i에 따라 출력되는 별의 개수가 달라짐
                    Console.Write("*");
                Console.WriteLine();    // 한 줄을 모두 입력하고 나서 다음 줄로 넘어가기 위하여 Console.WriteLine()으로 다음 줄로 넘어감

            }
        }

        public void ReverseTriangle()   // 사용자가 가운데로 정렬된 역삼각형을 출력하고자 할 때
        {
            for (int i =Line;i>= 1; i--)    // 입력받은 줄 수만큼 반복인데, 역삼각형으로 출력하고자 하기 때문에 가장 바깥에 존재하는 반복문의 변수가 Line에서 시작해 점차 줄어나가는 형식으로 설정
            {
                for (int j = 1; j <= Line - i; j++)     // 정삼각형을 출력하는 코드와 동일
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }

        public void SandGlass()     // 사용자가 모래시계 형식의 별을 출력하고자 할 때
        {
           for(int i=Line;i>=1;i--) // 우선 역삼각형을 출력하고 이후에 정삼각형을 출력하면 되기 때문에 앞서 사용한 역삼각형의 코드와 동일하게 진행
            {
                for (int j = 1; j <= Line - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
           
           for(int i = 2; i <= Line; i++)   // 이후 정삼각형을 출력하면 되는데, 정삼각형의 코드를 똑같이 사용하면 역삼각형과 정삼각형이 만날 때 꼭짓점이 두 개가 되기 때문에 정삼각형의 변수는 1이 아닌 2로 시작해서 둘쨋줄부터 출력하도록 함
            {
                for (int j = 1; j <= Line - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        public void Diamond()   // 사용자가 다이아몬드 형식의 별을 출력하고자 할 때  
        {
            for(int i=1;i<=Line;i++)    // 우선 정삼각형을 출력하고 이후에 역삼각형을 출력하면 되기 때문에 앞서 사용한 정삼각형 코드와 동일하게 진행
            {
                for (int j = 1; j <= Line - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
            for(int i=Line-1;i>=1;i--)  // 마찬가지로 밑변이 두 번 출력될 경우를 막기 위하여 (Line - 1)의 값에서 출력 시작
            {
                for(int j=1;j<=Line-i;j++)
                    Console.Write(" ");
                for(int j=1;j<=2*i-1;j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
    }

    public class GameStart  // 게임을 시작하는 클래스
    {
        private int ShapeLine;  // 사용자가 줄 수에 직접 접근하지 못하도록 private 변수로 지정
        public void Menu()  // 사용자가 선택할 수 있는 별 찍기의 모양을 제공하는 메소드
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

        public void SelectType() // 사용자가 제공된 별 찍기의 모양을 보고 선택할 수 있도록 하는 메소드
        {
            Menu();     // 사용자에게 제공 가능한 별 찍기의 모양을 제공
            Console.WriteLine();
            Console.Write("출력하고자 하는 도형의 번호를 입력하시오: ");
            int SelectNum = int.Parse(Console.ReadLine());  // 제공하고자 하는 별 찍기의 모양의 번호를 입력받음
            if (SelectNum>=1&&SelectNum<=4) // 그 수가 제공되어 있는 1부터 4 사이의 번호일 경우
            {
                LineNum(SelectNum); // 정상적으로 줄 수를 입력받는 메소드로 넘어감
            }
            else // 그렇지 않을 경우
            {
                ErrorNum(); // 번호를 다시 입력할 수 있는 메소드로 넘어감
            }
        }
        public void LineNum(int SelectNum) // 줄 수를 입력받는 메소드
        {
            Console.WriteLine();
            Console.Write("출력하고자 하는 도형의 줄 수를 입력하시오: ");
            ShapeLine = int.Parse(Console.ReadLine()); // 줄 수를 입력
            Console.Clear(); // 도형을 출력하기 위해 화면 전환
            PrintShape(SelectNum); // 도형을 출력할 수 있는 메소드

        }
        public void ErrorNum() // 잘못된 도형 번호를 선택했을 경우
        {
            int Num = 0;
            bool exit = false;
            while (!exit)   // 올바른 수를 입력할 때까지 계속 반복하기 위하여 무한반복문으로 설정
            {
                Console.Clear(); // 잘못된 입력이라는 문구만 뜨도록 하기 위하여 화면 전환
                Menu(); // 메뉴 제공
                Console.WriteLine("잘못된 입력입니다. 1부터 4 사이의 번호를 입력해 주세요."); 
                Console.Write("입력하세요: ");
                Num = int.Parse(Console.ReadLine());    // 메뉴 번호 입력
                if (Num >= 1 && Num <= 4) // 올바른 수를 입력했을 경우
                {
                    exit = true; // 무한반복문 탈출
                }
            }
            LineNum(Num); // 무한반복문을 탈출했을 경우는 올바른 수를 입력한 경우이기 때문에 줄 수를 입력받는 메소드로 전환
        }
        public void PrintShape(int SelectNum)   // 도형 출력
        {
            PrintingStar printingStar = new PrintingStar(ShapeLine);    // 도형을 출력할 수 있는 클래스를 사용하기 위하여 생성자 선언
            switch (SelectNum) 
            {
                case 1:
                    printingStar.Triangle(); // 1번을 선택했을 경우 Triangle()로 넘어감
                    break;
                case 2:
                    printingStar.ReverseTriangle(); // 2번을 선택했을 경우 ReverseTriangle()로 넘어감
                    break;
                case 3:
                    printingStar.SandGlass();   // 3번을 선택했을 경우 SandGlass()로 넘어감
                    break;
                case 4:
                    printingStar.Diamond();     // 4번을 선택했을 경우 Diamond()로 넘어감
                    break;
            }
        }
        public int ReturnPrint()    // 도형 출력 게임을 다시 진행할지 사용자에게 묻는 메소드
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine();
            Console.WriteLine("다시 시도하시겠습니까?");
            Console.WriteLine("1. 예     2. 아니요");
            int Exit = int.Parse(Console.ReadLine()); 
            return Exit; // 값을 넘김
        }
    }
    class printingStar
    {
        static void Main(string[] args)
        {
            int exit = 1;

            GameStart gameStart = new GameStart();  // 도형을 출력하기 위한 변수
            GameStart ExitRandomValue = new GameStart();    // 게임을 계속해서 진행할 것인지 묻는 변수

            while (exit == 1)
            {
                gameStart.SelectType(); // 게임 시작
                exit = ExitRandomValue.ReturnPrint();   // 반복문을 제어하는 exit 변수에 ReturnPrint() 함수의 리턴값을 넣어 그 값이 다시 시도하겠다는 응답인 1일 경우, 계속 반복, 아닐 경우 종료
                Console.Clear();
            }
        }
    }
}
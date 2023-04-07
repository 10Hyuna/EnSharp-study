using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class StartingTheGame
    {
        InformationForGame informationForGame = new InformationForGame();   // 클래스 내에서 
        HandingException handingException = new HandingException();         // 사용할 함수가 정의되어 있는
        GamingWithComputer vsComputer = new GamingWithComputer();           // 클래스의 생성자 인스턴스
        GamingWithUser vsUser = new GamingWithUser();
        ReturnOrEnd GetReturnOrEnd = new ReturnOrEnd();     //
        BoardControl controlBoard=new BoardControl();

        public string userChoice;   // 사용자의 선택을 예외 처리하기 위하여 문자열로 입력

        private const int gamingWithComputer = 1;
        private const int gaiminWithUser = 2;
        private const int printScoreboard = 3;
        private const int endProgram = 4;

        private const int menuStart = 1;
        private const int menuEnd = 4;

        private const string endProgramstring = "2";

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) //ctrl + z 등 단축키를 통해
        {                                                                           // 프로그램이 터지는 경우를
            e.Cancel = true;                                                        // 방지해 주는 함수
        }

        public void StartTheTicTacToe()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);    // 단축키로 인해 프로그램이 종료될 경우, 그 단축키를 다시 반환해 프로그램이 종료되는 것을 방지

            while (true)    // 무한 반복                // true ㅇㅢ미
            {
                Console.Clear();
                controlBoard.SetBoard();    // 게임이 다시 시작하면 board 배열을 다시 초기화
                informationForGame.DisplayMenu();   // 메뉴 출력
                Console.WriteLine();
                Console.WriteLine("원하는 항목을 선택해 주세요.");
                Console.Write("> 입력: ");

                int select = 0; // 사용자가 입력한 값이 숫자일 경우, 그 숫자를 저장하기 위한 변수

                do
                {
                    userChoice = Console.ReadLine();    // 예외 처리를 위해 문자열로 입력
                    if (handingException.DealWithException(userChoice) == true)     // 예외 처리를 했을 때, 그 값이 숫자라면
                    {
                        select = Convert.ToInt32(userChoice);   // 값을 수로 변환
                        if(select >= menuStart && select <= menuEnd)  // 사용자가 고른 값이 주어진 메뉴의 값의 범위에 해당
                        {
                            break;  // 반복문 탈출
                        }
                        else if (select > menuStart || select < menuEnd)  // 범위에서 벗어난다면
                        {
                            Console.Clear();
                            informationForGame.DisplayMenu();
                            Console.WriteLine();
                            Console.WriteLine("원하는 항목을 선택해 주세요.");
                            Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1, 2, 3, 4 중에서 고르세요.");
                            Console.Write("> 입력: ");
                            continue;
                        }
                    }
                    else    // 입력 값이 문자라면
                    {
                        Console.Clear();
                        informationForGame.DisplayMenu();
                        Console.WriteLine();
                        Console.WriteLine("원하는 항목을 선택해 주세요.");
                        Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1, 2, 3 중에서 고르세요.");
                        Console.Write("> 입력: ");
                        continue;
                    }
                } while (true);

                switch(select)
                {
                    case gamingWithComputer:
                        vsComputer.VsComputer();
                        break;
                    case gaiminWithUser:
                        vsUser.VsUser();
                        break;
                    case printScoreboard:
                        informationForGame.DisplayScoreBoard();
                        break;
                    case endProgram:
                        break;
                }
                string returnOrEnd = GetReturnOrEnd.ReturnOrEndFunc();  // 예외 처리를 위하여 문자열로 입력
                                                                        // 프로그램을 종료할 것인지 묻는 함수
                if (returnOrEnd == endProgramstring)                                 // 반환 값이 2라면 프로그램 종료
                {
                    break;
                }
            }
        }
    }
}

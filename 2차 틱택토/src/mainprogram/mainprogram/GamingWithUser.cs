using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GamingWithUser
    {
        private char user1Mark = 'O';
        private char user2Mark = 'X';
        private string userChoice;

        private const int vaildRangeStart = 1;
        private const int vaildRangeEnd = 9;

        InformationForGame information= new InformationForGame();
        HandingException handingException = new HandingException();
        BoardControl controlBoard = new BoardControl();

        public void VsUser()
        {
            Console.Clear();
            while (true)        // 무한 반복
            {
                MoveUser1();        // 유저 1이 선공
                if (information.IsBoardFull())      // 돌을 놓는 행위마다 비기는지 승패를 확인
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("비겼습니다!");
                    break;
                }
                if (information.IsWinner(user1Mark) == true)    // 이겼을 경우
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    information.currentWinner = "User1";
                    information.PrintWinner();
                    break;
                }
                MoveUser2();            // 유저 2가 후공
                if (information.IsBoardFull())  
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("비겼습니다!");
                    break;
                }
                if (information.IsWinner(user2Mark) == true)
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    information.currentWinner = "User2";
                    information.PrintWinner();
                    break;
                }
            }

        }

        public void MoveUser1()
        {
            Console.WriteLine();
            controlBoard.DisplayBoard(); 
            Console.WriteLine();
            Console.WriteLine("User1의 차례입니다.");
            Console.WriteLine("돌을 둘 자리를 입력하세요.");
            Console.Write("> 입력: ");
            int select = 0;
            do          // 예외 처리를 위해 무한반복문
            {
                userChoice = Console.ReadLine();
                if (handingException.DealWithException(userChoice) == true) // 숫자일 경우
                {
                    select = Convert.ToInt32(userChoice);
                    if (select >= vaildRangeStart && select <= vaildRangeEnd)     // 주어진 판 범위에 해당하는 값
                    {
                        if (information.IsvalidPart(select - 1) == false)   // 그 자리에 돌을 놓을 수 없다면
                        {

                            Console.Clear();
                            controlBoard.DisplayBoard();
                            Console.WriteLine();
                            Console.WriteLine("잘못된 입력입니다. 1부터 9까지의 숫자 중 아직 선택되지 않은 자리의 수를 고르세요.");
                            Console.Write("> 입력: ");
                            continue;
                        }
                        break;      // 돌을 놓을 수 있다면 탈출
                    }
                    else            // 주어진 판 범위에서 벗어난 값
                    {
                        Console.Clear();
                        controlBoard.DisplayBoard();
                        Console.WriteLine();
                        Console.WriteLine("잘못된 입력입니다. 1부터 9까지의 숫자 중 아직 선택되지 않은 자리의 수를 고르세요.");
                        Console.Write("> 입력: ");
                        continue;
                    }
                }
                else        // 문자라면
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("잘못된 입력입니다. 1부터 9까지의 숫자 중 아직 선택되지 않은 자리의 수를 고르세요.");
                    Console.Write("> 입력: ");
                    continue;
                }

            } while (true);

            Console.Clear();
            controlBoard.InputBoard(select - 1, user1Mark); // 그 자리에 돌 놓기
        }

        public void MoveUser2()     // MoverUser1과 같은 로직
        {
            controlBoard.DisplayBoard();

            Console.WriteLine();
            Console.WriteLine("User2의 차례입니다.");
            Console.WriteLine("돌을 둘 자리를 입력하세요.");
            Console.Write("> 입력: ");

            int select = 0;

            do
            {
                userChoice = Console.ReadLine();

                if (handingException.DealWithException(userChoice) == true)
                {
                    select = Convert.ToInt32(userChoice);

                    if (select >= vaildRangeStart && select <= vaildRangeEnd)
                    {
                        if (information.IsvalidPart(select - 1) == false)
                        {
                            Console.Clear();
                            controlBoard.DisplayBoard();
                            Console.WriteLine();
                            Console.WriteLine("잘못된 입력입니다. 1부터 9까지의 숫자 중 아직 선택되지 않은 자리의 수를 고르세요.");
                            Console.Write("> 입력: ");
                            continue;
                        }
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        controlBoard.DisplayBoard();
                        Console.WriteLine();
                        Console.WriteLine("잘못된 입력입니다. 1부터 9까지의 숫자 중 아직 선택되지 않은 자리의 수를 고르세요.");
                        Console.Write("> 입력: ");
                        continue;
                    }
                }
                else
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine("잘못된 입력입니다. 1부터 9까지의 숫자 중 아직 선택되지 않은 자리의 수를 고르세요.");
                    Console.Write("> 입력: ");
                    continue;
                }
            } while (true);

            Console.Clear();
            controlBoard.InputBoard(select - 1, user2Mark);
        }
    }
}

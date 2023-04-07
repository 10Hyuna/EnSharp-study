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

        InformationForGame information= new InformationForGame();
        HandingException handingException = new HandingException();
        ControlBoard controlBoard = new ControlBoard();

        public void VsUser()
        {
            Console.Clear();
            while (true)
            {
                MoveUser1();
                if (information.IsBoardFull())
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("비겼습니다!");
                    break;
                }
                if (information.IsWinner(user1Mark) == true)
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    information.currentWinner = "User1";
                    information.PrintWinner();
                    break;
                }
                MoveUser2();
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
            do
            {
                userChoice = Console.ReadLine();
                if (handingException.DealWithException(userChoice) == true)
                {
                    select = Convert.ToInt32(userChoice);
                    if (select >= 1 && select <= 9)
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
                else if (select > 9 || select < 0)
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("잘못된 입력입니다. 1부터 9까지의 숫자 중 아직 선택되지 않은 자리의 수를 고르세요.");
                    Console.Write("> 입력: ");
                    continue;
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
            } while (true);
            Console.Clear();
            controlBoard.InputBoard(select - 1, user1Mark);
        }

        public void MoveUser2()
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
                    if (select >= 1 && select <= 9)
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
                else if (select > 9 || select < 0)
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("잘못된 입력입니다. 1부터 9까지의 숫자 중 아직 선택되지 않은 자리의 수를 고르세요.");
                    Console.Write("> 입력: ");
                    continue;
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

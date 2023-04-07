using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GamingWithComputer
    {
        ForWin forWin = new ForWin();
        InformationForGame information = new InformationForGame();
        HandingException handingException = new HandingException();
        ControlBoard controlBoard = new ControlBoard();

        private char user1Mark = 'O';
        private char computerMark = 'X';
        private string userChoice;

        public void VsComputer()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                MoveUser();
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
                MoveComputer();
                if (information.IsBoardFull())
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("비겼습니다!");
                    break;
                }
                if (information.IsWinner(computerMark) == true)
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    information.currentWinner = "Computer";
                    information.PrintWinner();
                    break;
                }
            }
        }

        public void MoveUser()
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
            controlBoard.board[select - 1] = user1Mark;
        }
        public void MoveComputer()
        {
            if(information.ForWin(computerMark) != -1)
            {
                controlBoard.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("컴퓨터의 차례입니다.");

                controlBoard.board[information.ForWin(computerMark)] = 'X';
                return;
            }
            else if (information.ForWin(user1Mark) != -1)
            {
                controlBoard.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("컴퓨터의 차례입니다.");

                controlBoard.board[information.ForWin(user1Mark)] = 'X';
                return;
            }

            
            if (controlBoard.board[4] == 'O')
            {
                controlBoard.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("컴퓨터의 차례입니다.");

                controlBoard.board[forWin.CheckCorner()] = 'X';
                return;
            }
            else if (controlBoard.board[4] != 'X')
            {
                controlBoard.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("컴퓨터의 차례입니다.");

                controlBoard.board[4] = 'X';
                return;
            }

            while(true)
            {
                int move = new Random().Next(0, 10);
                if(information.IsvalidPart(move))
                {
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("컴퓨터의 차례입니다.");
                    controlBoard.board[move] = computerMark;
                    return;
                }
            }
        }
    }
}

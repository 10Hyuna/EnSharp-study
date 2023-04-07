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
        BoardControl controlBoard = new BoardControl();

        private char user1Mark = 'O';
        private char computerMark = 'X';
        private string userChoice;

        private const int vaildRangeStart = 1;
        private const int vaildRangeEnd = 9;
        private const char centerNumValue = '5';

        public void VsComputer()        
        {
            Console.Clear();

            while (true)
            {
                Console.Clear();

                MoveUser(); // 유저 선공

                if (information.IsBoardFull())  // 공격이 끝난 후 비겼는지 확인
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();

                    Console.WriteLine();
                    Console.WriteLine("비겼습니다!");
                    break;
                }

                if (information.IsWinner(user1Mark))    // 비기지 않았다면 이겼는지 확인
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();
                    Console.WriteLine();

                    information.currentWinner = "User1";
                    information.PrintWinner();
                    break;
                }

                MoveComputer();     // 컴퓨터 후공

                if (information.IsBoardFull())
                {
                    Console.Clear();
                    controlBoard.DisplayBoard();

                    Console.WriteLine();
                    Console.WriteLine("비겼습니다!");
                    break;
                }
                if (information.IsWinner(computerMark))
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

        public void MoveUser()      // 유저의 공격
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

                if (handingException.DealWithException(userChoice) == true) // 숫자라면
                {
                    select = Convert.ToInt32(userChoice);       // 정수 변환

                    if (select >= vaildRangeStart && select <= vaildRangeEnd)     // 유효한 범위 내의 값이라면
                    {
                        if (information.IsvalidPart(select - 1) == false)   // 돌을 놓을 수 있는 자리가 아니라면
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

                    else        // 유효하지 않은 범위 밖의 값이라면
                    {
                        Console.Clear();
                        controlBoard.DisplayBoard();
                        Console.WriteLine();
                        Console.WriteLine("잘못된 입력입니다. 1부터 9까지의 숫자 중 아직 선택되지 않은 자리의 수를 고르세요.");
                        Console.Write("> 입력: ");
                        continue;
                    }
                }
                else        // 입력 값이 문자라면
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
            controlBoard.InputBoard(select - 1, user1Mark);     // 유효한 자리에 돌 놓기
        }
        public void MoveComputer()      // 컴퓨터 공격
        {
            if(information.BlockUserWin(computerMark) != -1)        // 컴퓨터가 이길 수 있는 상황일 때
            {
                controlBoard.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("컴퓨터의 차례입니다.");
                controlBoard.InputBoard(information.BlockUserWin(computerMark), 'X');
                return;
            }
            else if (information.BlockUserWin(user1Mark) != -1)     // 유저가 승리를 위해 하나의 자리만 남겨 둔 상황일 때
            {
                controlBoard.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("컴퓨터의 차례입니다.");

                controlBoard.InputBoard(information.BlockUserWin(user1Mark), 'X');  // 그 자리에 컴퓨터가 돌을 놔 승리를 막음
                return;
            }

            
            if (controlBoard.CheckBoard(4) == 'O')      // 중앙에 유저의 돌이 있을 때
            {
                controlBoard.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("컴퓨터의 차례입니다.");

                controlBoard.InputBoard(forWin.CheckCorner(), 'X');     // 모서리에 유효한 자리가 있다면 선점
                return;
            }
            else if (controlBoard.CheckBoard(4) == centerNumValue) // 중앙에 값이 없을 때
            {
                controlBoard.DisplayBoard();
                Console.WriteLine();
                Console.WriteLine("컴퓨터의 차례입니다.");

                controlBoard.InputBoard(4, 'X');            // 중앙 선점
                return;
            }

            while(true)
            {
                int move = new Random().Next(0, 10);    // 0보다 크고 10보다 작은 난수 발생

                if(information.IsvalidPart(move))       // 그 난수의 값이 유효한 자리를 뜻한다면
                {
                    controlBoard.DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("컴퓨터의 차례입니다.");
                    controlBoard.InputBoard(move, computerMark);
                    return;
                }
            }
        }
    }
}

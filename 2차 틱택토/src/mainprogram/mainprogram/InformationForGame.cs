using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class InformationForGame
    {
        BoardControl controlBoard = new BoardControl();
        static int computerWin = 0;     // 클래스 내의 함수에 접근할 때마다
        static int user1Win = 0;        // 변수가 초기화되는 것을 막기 위하여
        static int user2Win = 0;        // static 변수로 선언

        public string currentWinner = null;

        private const int vaildRangeStart = 1;
        private const int vaildRangeEnd = 9;

        public void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=======================");
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("||  1. vs. Computer  ||");
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("=======================");
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("||  2. vs. User      ||");
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("=======================");
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("||  3. ScoreBoard    ||");
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("=======================");
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("||  4. Exit          ||");
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("=======================");
        }

        public void DisplayScoreBoard()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=======================");
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("||  1. Computer: {0}   ||", computerWin);
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("=======================");
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("||  2. User1: {0}      ||", user1Win);
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("=======================");
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("||  3. User2: {0}      ||", user2Win);
            Console.Write("||                   ||\n||                   ||\n");
            Console.WriteLine("=======================");
        }

        public void PrintWinner()       // 승자 출력
        {
            Console.WriteLine();
            Console.WriteLine("{0} 이/가 이겼습니다!", currentWinner);
            AddWinCount();  // 출력 후 승수 증가
        }

        public void AddWinCount()  
        {                           // currentWinner 변수에 저장되어 있는 값과 비교해
                                    // 승수 증가
            if (currentWinner == "Computer") 
            { 
                computerWin++;
                currentWinner = null;
            }
            else if (currentWinner == "User1")
            {
                user1Win++;
                currentWinner = null;
            }
            else if(currentWinner == "User2")
            {
                user2Win++;
                currentWinner = null;
            }
        }

        public bool IsWinner(char player)       // 승리할 수 있는 모든 경우의 수 비교
        {
            if ((controlBoard.CheckBoard(0) == player && controlBoard.CheckBoard(1) == player && controlBoard.CheckBoard(2) == player)||
                (controlBoard.CheckBoard(3) == player && controlBoard.CheckBoard(4) == player && controlBoard.CheckBoard(5) == player)||
                (controlBoard.CheckBoard(6) == player && controlBoard.CheckBoard(7) == player && controlBoard.CheckBoard(8) == player)||
                (controlBoard.CheckBoard(0) == player && controlBoard.CheckBoard(3) == player && controlBoard.CheckBoard(6) == player)||
                (controlBoard.CheckBoard(1) == player && controlBoard.CheckBoard(4) == player && controlBoard.CheckBoard(7) == player)||
                (controlBoard.CheckBoard(5) == player && controlBoard.CheckBoard(5) == player && controlBoard.CheckBoard(8) == player) ||
                (controlBoard.CheckBoard(0) == player && controlBoard.CheckBoard(4) == player && controlBoard.CheckBoard(8) == player) ||
                (controlBoard.CheckBoard(2) == player && controlBoard.CheckBoard(4) == player && controlBoard.CheckBoard(6) == player))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsBoardFull()   // 보드가 모두 돌로 가득찰 경우를 확인
        {
            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                if (controlBoard.CheckBoard(i) == (char)( i + '1')) // 저장된 값이 Mark가 아닌 값일 경우
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsvalidPart(int move)   // 움직이려는 자리가 유효한 자리인지 확인
        {
            if (move < vaildRangeStart- 1 || move > vaildRangeEnd)        // 주어진 판 이외에 해당하는 값
            {
                return false;
            }
            else if (controlBoard.CheckBoard(move) == 'O' || controlBoard.CheckBoard(move) == 'X')  
            {               // 이미 돌이 놓여진 자리
                return false;
            }
            else
            {
                return true;    
            }
        }

        public int BlockUserWin(char player)        // 컴퓨터가 무조건 이기거나 비기게 하기 위하여 
        {                                           // 유저가 이길 경우를 방어
                                                    // 모든 경우의 수 

            if ((controlBoard.CheckBoard(0) == player && controlBoard.CheckBoard(1) == player) && IsvalidPart(2))
            {
                return 2;
            }
            else if ((controlBoard.CheckBoard(0) == player && controlBoard.CheckBoard(2) == player) && IsvalidPart(1))
            {
                return 1;
            }
            else if ((controlBoard.CheckBoard(1) == player && controlBoard.CheckBoard(2) == player) && IsvalidPart(0))
            {
                return 0;
            }
            else if ((controlBoard.CheckBoard(3) == player && controlBoard.CheckBoard(4) == player) && IsvalidPart(5))
            {
                return 5;
            }
            else if ((controlBoard.CheckBoard(3) == player && controlBoard.CheckBoard(5) == player) && IsvalidPart(4))
            {
                return 4;
            }
            else if ((controlBoard.CheckBoard(4) == player && controlBoard.CheckBoard(5) == player) && IsvalidPart(3))
            {
                return 3;
            }
            else if ((controlBoard.CheckBoard(6) == player && controlBoard.CheckBoard(7) == player) && IsvalidPart(8))
            {
                return 8;
            }
            else if ((controlBoard.CheckBoard(6) == player && controlBoard.CheckBoard(8) == player) && IsvalidPart(7))
            {
                return 7;
            }
            else if ((controlBoard.CheckBoard(7) == player && controlBoard.CheckBoard(8) == player) && IsvalidPart(6))
            {
                return 6;
            }
            else if ((controlBoard.CheckBoard(2) == player && controlBoard.CheckBoard(4) == player) && IsvalidPart(6))
            {
                return 6;
            }
            else if ((controlBoard.CheckBoard(2) == player && controlBoard.CheckBoard(6) == player) && IsvalidPart(4))
            {
                return 4;
            }
            else if ((controlBoard.CheckBoard(4) == player && controlBoard.CheckBoard(6) == player) && IsvalidPart(2))
            {
                return 2;
            }
            else if ((controlBoard.CheckBoard(0) == player && controlBoard.CheckBoard(4) == player) && IsvalidPart(8))
            {
                return 8;
            }
            else if ((controlBoard.CheckBoard(0) == player && controlBoard.CheckBoard(8) == player) && IsvalidPart(4))
            {
                return 4;
            }
            else if ((controlBoard.CheckBoard(4) == player && controlBoard.CheckBoard(8) == player) && IsvalidPart(0))
            {
                return 0;
            }
            else if ((controlBoard.CheckBoard(0) == player && controlBoard.CheckBoard(3) == player) && IsvalidPart(6))
            {
                return 6;
            }
            else if ((controlBoard.CheckBoard(0) == player && controlBoard.CheckBoard(6) == player) && IsvalidPart(3))
            {
                return 3;
            }
            else if ((controlBoard.CheckBoard(3) == player && controlBoard.CheckBoard(6) == player) && IsvalidPart(0))
            {
                return 0;
            }
            else if ((controlBoard.CheckBoard(1) == player && controlBoard.CheckBoard(4) == player) && IsvalidPart(7))
            {
                return 7;

            }
            else if ((controlBoard.CheckBoard(1) == player && controlBoard.CheckBoard(7) == player) && IsvalidPart(4))
            {
                return 4;
            }
            else if ((controlBoard.CheckBoard(4) ==player && controlBoard.CheckBoard(7) ==player)&&IsvalidPart(1))
            {
                return 1;
            }
            else if ((controlBoard.CheckBoard(2) == player && controlBoard.CheckBoard(5) ==player)&&IsvalidPart(8))
            {
                return 8;
            }
            else if ((controlBoard.CheckBoard(2) ==player && controlBoard.CheckBoard(8) ==player)&&IsvalidPart(5))
            {
                return 5;
            }    
            else if ((controlBoard.CheckBoard(5) == player && controlBoard.CheckBoard(8) ==player)&&IsvalidPart(2))
            {
                return 2;
            }
            else
                    {
                        return -1;
                    }
        }
    }
}

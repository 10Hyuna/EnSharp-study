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
        ControlBoard controlBoard = new ControlBoard();
        static int computerWin = 0;
        static int user1Win = 0;
        static int user2Win = 0;

        public string currentWinner = "Computer";

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

        public void PrintWinner()
        {
            Console.WriteLine();
            Console.WriteLine("{0} 이/가 이겼습니다!", currentWinner);
            AddWinCount();
        }

        public void AddWinCount()
        {
            if (currentWinner == "Computer") { computerWin++; }
            else if (currentWinner == "User1") { user1Win++; }
            else { user2Win++; }
        }

        public bool IsWinner(char player)
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

        public bool IsBoardFull()
        {
            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                if (controlBoard.CheckBoard(i) == 'X' || controlBoard.CheckBoard(i) == 'O')
                {
                    count++;
                }
            }
            if (count == 9)
                return true;
            return false;
        }

        public bool IsvalidPart(int move)
        {
            if(move < 0 || move > 9)
            {
                return false;
            }
            else if (controlBoard.CheckBoard(move) == 'O' || controlBoard.CheckBoard(move) == 'X')
            {
                return false;
            }
            else
            {
                return true;    
            }
        }

        public int ForWin(char player)
        {
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

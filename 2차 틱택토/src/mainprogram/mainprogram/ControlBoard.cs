using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{

    class ControlBoard
    { 
        private static char[] board = new char[9];

        public void InputBoard(int index, char mark)
        {
            board[index] = mark;
        }

        public char CheckBoard(int index)
        {
            return board[index];
        }
        public void SetBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = (char)(i + '1');
            }
        }
        public void DisplayBoard()
        {
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("      {0}    ||     {1}     ||     {2}  ", board[0], board[1], board[2]);
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("====================================");
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("      {0}    ||     {1}     ||     {2}  ", board[3], board[4], board[5]);
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("====================================");
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("      {0}    ||     {1}     ||     {2}  ", board[6], board[7], board[8]);
            Console.WriteLine("           ||           ||            ");
            Console.WriteLine("====================================");
        }
    }
}

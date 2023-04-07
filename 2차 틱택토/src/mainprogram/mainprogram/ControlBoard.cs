using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class ControlBoard
    {
        public char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

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

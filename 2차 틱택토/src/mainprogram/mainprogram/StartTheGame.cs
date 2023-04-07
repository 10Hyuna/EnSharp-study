using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class StartTheGame
    {
        InformationForGame informationForGame = new InformationForGame();
        HandingException handingException = new HandingException();
        GamingWithComputer vsComputer = new GamingWithComputer();
        GamingWithUser vsUser = new GamingWithUser();
        ReturnOrEnd GetReturnOrEnd = new ReturnOrEnd();
        ControlBoard controlBoard=new ControlBoard();

        public string userChoice;
        private int winnerDefine;
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
        }

        public void StartTheTicTacToe()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            while (true)
            {
                Console.Clear();
                controlBoard.SetBoard();
                informationForGame.DisplayMenu();

                Console.WriteLine("원하는 항목을 선택해 주세요.");
                Console.Write("> 입력: ");

                int select = 0;

                do
                {
                    userChoice = Console.ReadLine();
                    if (handingException.DealWithException(userChoice) == true)
                    {
                        select = Convert.ToInt32(userChoice);
                        if(select >= 1 && select <= 3)
                        {
                            break;
                        }
                    }
                    else if(select > 4|| select < 0)
                    {
                        Console.Clear();
                        informationForGame.DisplayMenu();
                        Console.WriteLine("원하는 항목을 선택해 주세요.");
                        Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1, 2, 3 중에서 고르세요.");
                        Console.Write("> 입력: ");
                    }
                    else
                    {
                        Console.Clear();
                        informationForGame.DisplayMenu();
                        Console.WriteLine("원하는 항목을 선택해 주세요.");
                        Console.WriteLine("잘못된 입력입니다. 주어진 메뉴 1, 2, 3 중에서 고르세요.");
                        Console.Write("> 입력: ");
                    }
                } while (handingException.DealWithException(userChoice) == false);

                switch(select)
                {
                    case 1:
                        vsComputer.VsComputer();
                        break;
                    case 2:
                        vsUser.VsUser();
                        break;
                    case 3:
                        informationForGame.DisplayScoreBoard();
                        break;
                }
                string returnOrEnd = GetReturnOrEnd.ReturnOrEndFunc();
                if (returnOrEnd == "2")
                {
                    break;
                }
            }
        }
    }
}

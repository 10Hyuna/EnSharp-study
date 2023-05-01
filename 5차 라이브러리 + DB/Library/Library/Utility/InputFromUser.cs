using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class InputFromUser
    {

        private static InputFromUser inputFromUser;

        private InputFromUser() { }

        public static InputFromUser GetInputFromUser()
        {
            if(inputFromUser == null)
            {
                inputFromUser = new InputFromUser();
            }
            return inputFromUser;
        }
        ConsoleKeyInfo keyInfo;
        public int SelectMenuIndex(int endMenuIndex, int selectedMenu)
        {   // 메뉴는 위아래로 움직임            

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedMenu--;
                if (selectedMenu < 0)
                {
                    selectedMenu = endMenuIndex;
                }
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedMenu++;
                if (selectedMenu > endMenuIndex)
                {
                    selectedMenu = 0;
                }
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                selectedMenu = Constant.ENTER;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                selectedMenu = Constant.EXIT;
            }
            else
            {
                selectedMenu = Constant.FAIL;
            }
            return selectedMenu;
        }
    }
}

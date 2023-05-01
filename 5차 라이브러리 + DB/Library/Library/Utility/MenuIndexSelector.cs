using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class MenuIndexSelector
    {
        private static MenuIndexSelector menuIndexSelector;
        private GuidancePhrase guidancePhrase;
        private InputFromUser inputFromUser;

        private MenuIndexSelector() 
        {
            GuidancePhrase guidancePhrase = GuidancePhrase.SetGuidancePhrase();
            InputFromUser inputFromUser = InputFromUser.GetInputFromUser();
        }

        public static MenuIndexSelector GetMenuIndexSelector()
        {
            if(menuIndexSelector == null)
            {
                menuIndexSelector = new MenuIndexSelector();
            }
            return menuIndexSelector;
        }

        public int SelectMenuIndex(string[] menu, int presentIndex, int consoleColumn, int consoleRow)
        {
            bool isNotEnter = true;
            int selectedMenuIndex;

            while(isNotEnter)
            {
                Console.SetCursorPosition(consoleColumn, consoleRow);

                ColorMenuIndex(menu, presentIndex, consoleColumn, consoleRow);

                selectedMenuIndex = inputFromUser.SelectMenuIndex(menu.Length - 1, presentIndex);

                switch (selectedMenuIndex)
                {
                    case (int)Constant.FAIL:
                        // 잘못된 입력
                        selectedMenuIndex = presentIndex;
                        break;
                    case (int)Constant.ENTER:
                        isNotEnter = false;
                        selectedMenuIndex = presentIndex;
                        break;
                    case (int)Constant.EXIT:
                        isNotEnter = false;
                        selectedMenuIndex = (int)Constant.EXIT;
                        break;
                }
                presentIndex = selectedMenuIndex;
            }
            return presentIndex;
        }

        private void ColorMenuIndex(string[] menu, int presentIndex, int consoleColumn, int consoleRow)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                if (i == presentIndex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    guidancePhrase.PrintMenu(menu[i]);
                    consoleColumn = Console.CursorLeft;
                    Console.ResetColor();
                }
                else
                {
                    guidancePhrase.PrintMenu(menu[i]);
                    consoleColumn = Console.CursorLeft;
                }
                Console.SetCursorPosition(consoleColumn, consoleRow + 1);
            }
        }
    }
}

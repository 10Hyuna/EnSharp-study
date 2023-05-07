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
        private static MenuIndexSelector menuIndexSelector = null;
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
                // 선택하고 있는 메뉴의 인덱스를 색칠해서 출력해 주는 메소드

                selectedMenuIndex = InputFromUser.GetInputFromUser().SelectMenuIndex(menu.Length - 1, presentIndex);   
                // 위아래 엔터 값을 입력받아 옴

                switch (selectedMenuIndex)
                {
                    case (int)Constant.FAIL_INT:
                        // 잘못된 입력
                        selectedMenuIndex = presentIndex;
                        break;
                    case (int)Constant.ENTER_INT:
                        isNotEnter = false;
                        selectedMenuIndex = presentIndex;
                        break;
                    case (int)Constant.EXIT_INT:
                        isNotEnter = false;
                        selectedMenuIndex = (int)Constant.EXIT_INT;
                        break;
                }
                presentIndex = selectedMenuIndex;
            }
            return presentIndex;
        }

        private void ColorMenuIndex(string[] menu, int presentIndex, int consoleColumn, int consoleRow)
        {
            int originColumn = consoleColumn;

            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(consoleColumn, consoleRow++);

                if (i == presentIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    GuidancePhrase.SetGuidancePhrase().PrintMenu(menu[i]);
                    Console.ResetColor();
                }
                else
                {
                    GuidancePhrase.SetGuidancePhrase().PrintMenu(menu[i]);
                }
            }
        }
    }
}

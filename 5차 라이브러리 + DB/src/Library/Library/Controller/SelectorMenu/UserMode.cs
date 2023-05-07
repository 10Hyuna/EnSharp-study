using Library.Utility;
using Library.View;
using Library.Controller.BookAccess;
using Library.Controller.TotalAccess;
using Library.Model.DTO;
using Library.Controller.APIAccess;

namespace Library.Controller.SelectorMode
{
    public class UserMode
    {
        Searcher searcher;
        SortList sortList;
        DeleterInformation deleterInformation;
        MainView MainView;
        MenuIndexSelector menuIndexSelector;
        Rental rental;
        Return returnBook;
        ModificationInformation modificationInformation;
        NaverBookSearch naverBookSearch;

        public UserMode(Searcher searcher, SortList sortList, DeleterInformation deleterInformation, ModificationInformation modificationInformation, NaverBookSearch naverBookSearch)
        {
            this.searcher = searcher;
            this.sortList = sortList;
            this.deleterInformation = deleterInformation;
            this.modificationInformation = modificationInformation;
            rental = new Rental(searcher);
            returnBook = new Return();
            MainView = MainView.SetMainView();
            menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
            this.naverBookSearch = naverBookSearch;
        }

        public void SelectMenu(string userId)
        {
            int column = 30;
            int row = 10;

            int selectedMenu = 0;
            int checkingBreak = -1;

            bool isNotESC = true;

            string[] menu = { "도서 찾기", "도서 대여", "도서 대여 확인", "도서 반납", "도서 반납 내역", "정보 수정", "계정 삭제", "네이버 검색", "요청 도서 내역"};

            while (isNotESC)
            {
                Console.SetWindowSize(76, 22);
                checkingBreak = -1;
                Console.Clear();
                MainView.PrintMain();
                MainView.PrintBox(11);

                selectedMenu = MenuIndexSelector.GetMenuIndexSelector().SelectMenuIndex(menu, selectedMenu, column, row);

                if(selectedMenu == Constant.EXIT_INT)
                {
                    isNotESC = false;
                    continue;
                }

                checkingBreak = EnterSelectedMenu(selectedMenu, userId);        // 선택한 메뉴에 진입함과 동시에 회원탈퇴를 진행한 건지 확인하는 메소드

                if(checkingBreak == Constant.DELETE_ACCOUNT)
                {
                    isNotESC = false;
                }
            }
        }

        private int EnterSelectedMenu(int selectedMenu, string userId)
        {
            int breakPoint = -1;
            List<BookDTO> searchedBook = new List<BookDTO>();
            switch(selectedMenu)
            {
                case (int)USERMENU.FIND:
                    searchedBook = searcher.SearchBook((int)USERMENU.FIND);
                    break;
                case (int)USERMENU.RENT:
                    rental.RentBook(userId);
                    break;
                case (int)USERMENU.RENT_LIST:
                    sortList.AnnounceBookState((int)ENTRY.RENTAL, userId);
                    break;
                case (int)USERMENU.RETURN:
                    returnBook.ReturnBook(userId);
                    break;
                case (int)USERMENU.RETURN_LIST:
                    sortList.AnnounceBookState((int)ENTRY.RETURN, userId);
                    break;
                case (int)USERMENU.MODIFY_MY_INFORMATION:
                    modificationInformation.ModifyInformation((int)MODE.USER, userId);
                    break;
                case (int)USERMENU.DELETE_ACCOUNT:
                    breakPoint = deleterInformation.DeleteUserInformation((int)MODE.USER, userId);
                    break;
                case (int)USERMENU.NAVER_SEARCH:
                    naverBookSearch.EnterNaverSearch((int)MODE.USER, userId);
                    break;
                case (int)USERMENU.REQUEST_LIST:
                    sortList.AnnounceBookState((int)ENTRY.REQUEST, userId);
                    break;
            }
            return breakPoint;
        }
    }
}

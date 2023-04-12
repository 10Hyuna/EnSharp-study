using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Controller;
using Library.Model;

namespace Library
{
    // 패키징  -> 나중을 위해서라도
    // 코드 줄이기
    // constant
    // controller 명명은 지양
    // dataController 이름 싹 바꾸기
    // 코드 안 읽힘 가독성 안 좋음
    // mvc 패턴이랑 vo, dto 정리하는 시간 갖기

    class LibraryStart
    {
        public static int WindowRow = 30;
        public static int WindowColumn = 112;
        static void Main(string[] args)
        {
            string currentTime = DateTime.Now.ToString();
            Console.WriteLine(currentTime);
            UsingLibrary library = new UsingLibrary();
           // Console.SetWindowSize(WindowColumn, WindowRow);
            library.SelectModeOfUserOrManager();
        }
    }
}

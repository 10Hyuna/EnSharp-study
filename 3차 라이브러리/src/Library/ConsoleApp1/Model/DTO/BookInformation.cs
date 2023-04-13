using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Model.DTO
{
    class BookInformation          // 책 정보
    {
        public BookInformation() { }

        public BookInformation(int id, string title, string author, string publisher, string amount, string price, string publishDay, string ISBN, string information)   // 책 정보를 입력
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.amount = amount;
            this.price = price;
            this.publishDay = publishDay;
            this.ISBN = ISBN;
            this.information = information;
        }

        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public string amount { get; set; }
        public string price { get; set; }
        public string publishDay { get; set; }
        public string ISBN { get; set; }
        public string information { get; set; }

    }
    class BorrowBookList : BookInformation
    {
        public string borrowTime { get; set; }
        
        public BorrowBookList(int id, string title, string author, string publisher, string amount, string price, string publishDay, string ISBN, string information, string borrowTime) : base(id, title, author, publisher, amount, price, publishDay, ISBN, information) 
        {
            this.borrowTime = borrowTime;
        }
    }

    class ReturnBookList : BorrowBookList
    {
        public string returnTime { get; set; }

        public ReturnBookList(int id, string title, string author, string publisher, string amount, 
            string price, string publishDay, string ISBN, string information, string borrowTime, string returnTime) 
            : base(id, title, author, publisher, amount, price, publishDay, ISBN, information, borrowTime)
        {
            this.returnTime = returnTime;
        }
    }
}

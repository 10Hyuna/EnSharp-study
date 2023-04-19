using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Model.DTO
{
    class Book          // 책 정보
    {
        public Book() { }

        protected int id;
        protected string title;
        protected string author;
        protected string publisher;
        protected string amount;
        protected string price;
        protected string publishDay;
        protected string ISBN;
        protected string information;

        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPublisher(string publisher)
        {
            this.publisher = publisher;
        }

        public void SetAmount(string Amount)
        {
            this.amount = Amount;
        }

        public void SetPrice(string Price)
        {
            this.price = Price;
        }

        public void SetPublishDay(string PublishDay)
        {
            this.publishDay = PublishDay;
        }

        public void SetISBN(string ISBN)
        {
            this.ISBN = ISBN;
        }

        public void SetInformation(string Information)
        {
            this.information = Information;
        }

        public int GetId()
        {
            return this.id;
        }

        public string GeTitle()
        {
            return this.title;
        }

        public string GetAuthor()
        {
            return this.author;
        }

        public string GetPublisher()
        {
            return this.publisher;
        }

        public string GetAmount()
        {
            return this.amount;
        }

        public string GetPrice()
        {
            return this.price;
        }

        public string GetPublishDay()
        {
            return this.publishDay;
        }

        public string GetISBN()
        {
            return this.ISBN;
        }

        public string GetInformation()
        {
            return this.information;
        }
        public Book(int id, string title, string author, string publisher, string amount, 
            string price, string publishDay, string ISBN, string information)   // 책 정보를 입력
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

    }
    class BorrowBookList : Book
    {
        public BorrowBookList(int id, string title, string author, string publisher, string amount,
            string price, string publishDay, string ISBN, string information, string borrowTime)
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
            this.borrowTime = borrowTime;
        }

        protected string borrowTime;
        
        public BorrowBookList() { }


        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPublisher(string publisher)
        {
            this.publisher = publisher;
        }

        public void SetAmount(string amount)
        {
            this.amount = amount;
        }

        public void SetPrice(string price)
        {
            this.price = price;
        }

        public void SetPublishDay(string publishDay)
        {
            this.publishDay = publishDay;
        }

        public void SetISBN(string ISBN)
        {
            this.ISBN = ISBN;
        }

        public void SetInformation(string information)
        {
            this.information = information;
        }

        public void SetBorrowTime(string borrowTime)
        {
            this.borrowTime = borrowTime;
        }

        public int GetId()
        {
            return this.id;
        }

        public string GetTitle()
        {
            return this.title;
        }

        public string GetAuthor()
        {
            return this.author;
        }

        public string GetPublisher()
        {
            return this.publisher;
        }

        public string GetAmount()
        {
            return this.amount;
        }

        public string GetPrice()
        {
            return this.price;
        }

        public string GetPublishDay()
        {
            return this.publishDay;
        }

        public string GetISBN()
        {
            return this.ISBN;
        }

        public string GetInformation()
        {
            return this.information;
        }

        public string GetBorrowTime()
        {
            return this.borrowTime;
        }
    }

    class ReturnBookList : BorrowBookList
    {
        public ReturnBookList(int id, string title, string author, string publisher, string amount,
            string price, string publishDay, string ISBN, string information, string borrowTime, string returnTime)
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
            this.borrowTime = borrowTime;
            this.returnTime = returnTime;
        }

        private string returnTime;

        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPublisher(string publisher)
        {
            this.publisher = publisher;
        }

        public void SetAmount(string amount)
        {
            this.amount = amount;
        }

        public void SetPublishDay(string publishDay)
        {
            this.publishDay = publishDay;
        }

        public void SetPrice(string price)
        {
            this.price = price;
        }

        public void SetISBN(string ISBN)
        {
            this.ISBN = ISBN;
        }

        public void SetInformation(string information)
        {
            this.information = information;
        }

        public void SetBorrowTime(string borrowTime)
        {
            this.borrowTime = borrowTime;
        }

        public void SetReturnTime(string returnTime)
        {
            this.returnTime = returnTime;
        }
        public int GetId()
        {
            return id;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetAuthor()
        {
            return author;
        }

        public string GetPublisher()
        {
            return publisher;
        }

        public string GetAmount()
        {
            return amount;
        }

        public string GetPrice()
        {
            return price;
        }

        public string GetPublishDay()
        {
            return publishDay;
        }

        public string GetISBN()
        {
            return ISBN;
        }

        public string GetInformation()
        {
            return information;
        }

        public string GetBorrowTime()
        {
            return borrowTime;
        }
        
        public string GetReturnTime()
        {
            return returnTime;
        }
    }
}

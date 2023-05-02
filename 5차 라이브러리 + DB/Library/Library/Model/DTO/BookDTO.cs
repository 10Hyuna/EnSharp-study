using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.DTO
{
    public class BookDTO
    {
        protected int id;
        protected string title;
        protected string author;
        protected string publisher;
        protected int amount;
        protected int price;
        protected string publishDate;
        protected string isbn;
        protected string information;

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }

        public string Title
        {
            get => this.title;
            set => this.title = value;
        }

        public string Author
        {
            get => this.author;
            set => this.author = value;
        }

        public string Publisher
        {
            get => this.publisher;
            set => this.publisher = value;
        }

        public int Amount
        {
            get => this.amount;
            set => this.amount = value;
        }

        public int Price
        {
            get => this.price;
            set => this.price = value;
        }

        public string PublishDate
        {
            get => this.publishDate;
            set => this.publishDate = value;
        }

        public string ISBN
        {
            get => this.isbn;
            set => this.isbn = value;
        }

        public string Information
        {
            get => this.information;
            set => this.information = value;
        }
    }

    public class SearchResult : BookDTO
    {

    }
    public class RentBookDTO : BookDTO
    {
        protected string userId;
        protected string rentTime;

        public string UserId
        {
            get => this.userId;
            set => this.userId = value;
        }

        public string RentTime
        {
            get => this.rentTime;
            set => this.rentTime = value;
        }
    }
    
    public class ReturnBookDTO : RentBookDTO
    {
        private string returnTime;

        public string ReturnTime
        {
            get => this.returnTime;
            set => this.returnTime = value;
        }
    }
}

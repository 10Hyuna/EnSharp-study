using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.DTO
{
    public class SearchResult
    {
        public SearchResult() { }

        private string title;
        private string author;
        private string publisher;

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
    }
}

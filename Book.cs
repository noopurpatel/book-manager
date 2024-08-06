using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm991667498NoopurPatel
{
    public abstract class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string author, int publicationYear, decimal price)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Price = price;
        }

        public abstract string GetCategory();

        public override string ToString()
        {
            return $"{Title}, by {Author} ({PublicationYear}) - ${Price} [{GetCategory()}]";
        }
    }
}

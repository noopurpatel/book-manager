using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm991667498NoopurPatel
{
    public class ReferenceBook : Book
    {
        public ReferenceBook(string title, string author, int publicationYear, decimal price)
            : base(title, author, publicationYear, price) { }

        public override string GetCategory() => "Reference";
    }
}

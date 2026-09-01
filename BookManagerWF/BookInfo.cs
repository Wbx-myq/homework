using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dayWF06
{
    internal class BookInfo
    {
        public string Id { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public double BookPrice { get; set; }

        public string BookLabel {  get; set; }
        public bool IsBorrow {  get; set; }
    }
}

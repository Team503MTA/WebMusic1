using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMusic.Models
{
    public class SearchResult
    {
        public SearchResult() { }

        public SearchResult(int id, string fullName)
        {
            this.id = id;
            this.fullName = fullName;
        }

        public int id { get; set; }

        public string fullName { get; set; }
    }
}

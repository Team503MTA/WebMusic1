using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMusic.Models
{
    public class Product
    {
        public Product() { }

        public int id { get; set; }

        public byte type { get; set; }

        public List<string> artist { get; set; }
        
        public List<string> label { get; set; }
        
        public string name { get; set; }
        
        public string link { get; set; }
        
        public string link_Img { get; set; }  
    }
}

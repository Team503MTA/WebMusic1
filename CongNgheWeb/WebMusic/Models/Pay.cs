using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMusic.Models
{
    public class Pay
    {
        public string email { get; set; }

        public string password { get; set; }

        public string cardNumber { get; set; }

        public string passwordCard { get; set; }

        public Pay() { }
    }
}

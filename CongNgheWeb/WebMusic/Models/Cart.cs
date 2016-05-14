using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMusic.Models;

namespace WebMusic.Models
{
    public class Cart
    {

        MusicEntities db = new MusicEntities();
        public int id { get; set; }

        public int type { get; set; }

        public string name { get; set; }

        public string fullName { get; set; }

        public double cost { get; set; }

        public List<string> artist { get; set; }

        public List<string> label { get; set; }

        public byte sale { get; set; }

        public Cart(int _id ,int _type , string _name,string _fullName , double _cost , List<string> _artist , List<string> _label  )
        {
            id = _id;
            type = _type;
            name = _name;
            fullName = _fullName;
            cost = _cost;
            artist = _artist;
            label = _label;
        }

        public Cart() { }

    }
}

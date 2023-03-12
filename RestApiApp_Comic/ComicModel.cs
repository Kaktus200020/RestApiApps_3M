using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiApp_Comic
{
    public class ComicModel
    {
        public string Img { get; set; }
        public string Title { get; set; }
        public int Num { get; set; }
        public string Alt { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
     
        public int Year { get; set; }
    }
}

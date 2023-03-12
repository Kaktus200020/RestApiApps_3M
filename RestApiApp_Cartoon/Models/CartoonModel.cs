using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiApp_Cartoon.Models
{
    public class CartoonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image{ get; set; }
        public string Species { get; set; }
        public Location Location { get; set; }
    }
}

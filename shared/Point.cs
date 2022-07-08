using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Shared
{
    public class point
    {
        public int points { get; set; }
        public int ProductId { get; set; }
        public point() { }
        public point(int points, int productId)
        {
            this.points = points;
            this.ProductId = productId;
        }
    }
}

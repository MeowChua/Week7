using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Shared
{
    public class CartItem
    {
        public CartItem(int userID, int ProductID, int ProductTypeId, int Quantity){
            this.ProductId=ProductID;
            this.Quantity=Quantity;
            this.UserId=userID;
            this.ProductTypeId=ProductTypeId;
        }
        public CartItem(){}
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; } = 1;
        
    }
}

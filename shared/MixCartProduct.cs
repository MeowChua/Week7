using System;
using Projects.Shared;

namespace Shared
{
	public class MixCartProduct
	{
		public CartItem cartItem { get; set; }
        public Product product { get; set; }
		public int sum { get; set; }
		public MixCartProduct()
		{
		}
        public MixCartProduct(CartItem cartItem,Product product)
        {
			this.cartItem = cartItem;
			this.product = product;
            this.sum = (int)(cartItem.Quantity * product.Variants[0].Price);
        }
      
	}
}


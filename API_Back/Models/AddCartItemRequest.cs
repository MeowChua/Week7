using System;
namespace API_Back.Models
{
	public class AddCartItemRequest
	{
		public AddCartItemRequest()
		{
		}
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}


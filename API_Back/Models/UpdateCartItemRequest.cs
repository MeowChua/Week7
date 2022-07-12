using System;
namespace API_Back.Models
{
	public class UpdateCartItemRequest
	{
		public UpdateCartItemRequest()
		{
		}
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}


using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week7.Models
{
	public class UpdateProductTypesRequest
	{
		public UpdateProductTypesRequest()
		{
		}
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}


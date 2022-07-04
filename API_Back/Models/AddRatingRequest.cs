using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Back.Models
{
    public class AddRatingRequest
    {
            public AddRatingRequest() { }
        
            public int IdProduct { get; set; }
            public int rating { get; set; }
        public int Id { get; set; }

    }
}

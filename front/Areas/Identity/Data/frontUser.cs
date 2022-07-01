using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using front.Models;
using Microsoft.AspNetCore.Identity;

namespace front.Areas.Identity.Data;

// Add profile data for application users by adding properties to the frontUser class
public class frontUser : IdentityUser
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public Address Address { get; set; }
    public string Role { get; set; } = "Customer";
}


﻿using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string Role { get; set; }
    }
}

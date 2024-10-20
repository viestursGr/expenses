﻿using System.ComponentModel.DataAnnotations;

namespace PersonalExpensesManager.Model
{
    public class Category
    {
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

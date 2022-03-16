using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeApp.Models
{
    public class Incredient
    {
        [Key]
        public int IncredientId { get; set; }
        
        [Required(ErrorMessage = "Incredient name is required")]
        public string IncredientName { get; set; }
        public List<RecipeIncredient> Recipes { get; set; } = new List<RecipeIncredient>();
    }
}
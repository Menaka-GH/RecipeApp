using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecipeApp.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Recipe name is required")]
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public List<RecipeIncredient> RecipeIncredients { get; set; } = new List<RecipeIncredient>();
        public List<RecipeStep> RecipeStep { get; set; } = new List<RecipeStep>();
    }
   
}
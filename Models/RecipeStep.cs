using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeApp.Models
{
    public class RecipeStep
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Instructions required")]
        public string Instructions{ get; set; }
        public string PrepTime { get; set; }
        public string CookTime { get; set; }
        public Recipe Recipe { get; set; }

        public int RecipeId { get; set; }
    }
}
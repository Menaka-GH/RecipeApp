using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeApp.Models
{
    public class RecipeIncredient
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Recipe Incredient name is required")]
        public string RecipeIncredientName { get; set; }

        [Required(ErrorMessage = "Incredient amount is required")]
        public string AmountRequired { get; set; }
        public Recipe Recipe { get; set; }

        public int RecipeId { get; set; }
        public Incredient Incredient { get; set; }
        public int IncredientId { get; set; }


    }
}
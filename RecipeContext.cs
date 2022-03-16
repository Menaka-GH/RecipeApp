using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecipeApp
{
    
        public class RecipeContext : DbContext
        {

            public DbSet<Recipe> Recipes { get; set; }

            public DbSet<RecipeIncredient> Recipeincredients { get; set; }
            public DbSet<RecipeStep> Recipesteps { get; set; }

            public DbSet<Incredient> Incredients { get; set; }

        }
    
    
}
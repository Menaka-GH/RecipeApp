RECIPEAPP
*********
	RecipeApp is a list of recipes from South Indian category.  I have created the following classes.
	1. Recipe class -Includes the name of the recipes and short description
	2. Incredients Class  -  Includes name of the incredients
	3. RecipeIncredients Class - Includes the Incredients needed for specific recipe.
	4. RecipeSteps Class - Includes the instructions for preparing the recipe and cook time and prep time.

	Framework Installed
	-------------------
	1. Entity Framework
	2. Entity Framework.SqlServer

	Features:
	--------
	1. Four classes created namely Recipe, Incredients, RecipeIncredients, RecipeSteps
	2. Objects created for the RecipeContext to do the operations CRUD.
	3. LINQ query used to select the record from the database.
	4. Migrations have been used by the below commands:
		add-migrations "recipe"
		update-database
	

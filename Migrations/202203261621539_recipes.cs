namespace RecipeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RecipeIncredients", "RecipeIncredientName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecipeIncredients", "RecipeIncredientName", c => c.String(nullable: false));
        }
    }
}

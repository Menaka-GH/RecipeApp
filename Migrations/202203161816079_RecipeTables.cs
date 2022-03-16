namespace RecipeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incredients",
                c => new
                    {
                        IncredientId = c.Int(nullable: false, identity: true),
                        IncredientName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IncredientId);
            
            CreateTable(
                "dbo.RecipeIncredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeIncredientName = c.String(nullable: false),
                        AmountRequired = c.String(nullable: false),
                        RecipeId = c.Int(nullable: false),
                        IncredientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Incredients", t => t.IncredientId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.IncredientId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(nullable: false),
                        RecipeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeSteps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Instructions = c.String(nullable: false),
                        PrepTime = c.String(),
                        CookTime = c.String(),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeSteps", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeIncredients", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeIncredients", "IncredientId", "dbo.Incredients");
            DropIndex("dbo.RecipeSteps", new[] { "RecipeId" });
            DropIndex("dbo.RecipeIncredients", new[] { "IncredientId" });
            DropIndex("dbo.RecipeIncredients", new[] { "RecipeId" });
            DropTable("dbo.RecipeSteps");
            DropTable("dbo.Recipes");
            DropTable("dbo.RecipeIncredients");
            DropTable("dbo.Incredients");
        }
    }
}

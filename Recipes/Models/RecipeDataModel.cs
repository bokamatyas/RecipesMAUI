using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class RecipeDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public string Ingredients { get; set; }
        
        public string? InstructionsURL { get; set; }

        [NotNull]
        public string? ImageUrl { get; set; }

        public RecipeDataModel(string _name, string _ingredients, string? _instructionsURL, string? _imageUrl)
        {
            this.Name = _name;
            this.Ingredients = _ingredients;
            this.InstructionsURL = _instructionsURL;
            if (_imageUrl is not null)
                this.ImageUrl = _imageUrl;
            else
                this.ImageUrl = "noimage.png";
        }

        public RecipeDataModel()
        {
            this.Name = "";
            this.Ingredients = "";
            this.ImageUrl = "";
        }

        public RecipeDataModel(RecipeDataModel _recipeData)
        {
            this.Name = _recipeData.Name;
            this.Ingredients = _recipeData.Ingredients;
            this.InstructionsURL = _recipeData.InstructionsURL;
            this.ImageUrl = _recipeData.ImageUrl;
        }
    }
}

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

        public int? Rating { get ; set; }
        
        public string? InstructionsURL { get; set; }

        [NotNull]
        public string? ImageUrl { get; set; }

        public RecipeDataModel(string _name, int _rating, string? _instructionsURL, string? _imageUrl)
        {
            this.Name = _name;
            this.Rating = _rating;
            this.InstructionsURL = _instructionsURL;
            if (_imageUrl is not null)
                this.ImageUrl = _imageUrl;
            else
                this.ImageUrl = "noimage.png";
        }

        public RecipeDataModel()
        {
            this.Name = "";
            this.Rating = 1;
            this.ImageUrl = "";
            this.Rating = 1;
        }

        public RecipeDataModel(RecipeDataModel _recipeData)
        {
            this.Name = _recipeData.Name;
            this.Rating = _recipeData.Rating;
            this.InstructionsURL = _recipeData.InstructionsURL;
            this.ImageUrl = _recipeData.ImageUrl;
        }
    }
}

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
        public List<string> Ingredients { get; set; }
        
        public List<string>? Instructions { get; set; }

        [NotNull]
        public string? ImageUrl { get; set; }

        public RecipeDataModel(string _name, List<string> _ingredients, List<string>? _instructions, string? _imageUrl)
        {
            this.Name = _name;
            this.Ingredients = _ingredients;
            this.Instructions = _instructions;
            if (_imageUrl is not null)
                this.ImageUrl = _imageUrl;
            else
                this.ImageUrl = "noimage.png";
        }

        public RecipeDataModel()
        {
            this.Name = "TEST";
            this.Ingredients = [];
            this.ImageUrl = "noimage.png";
        }
    }
}

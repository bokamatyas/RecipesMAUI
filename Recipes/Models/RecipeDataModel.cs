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

        public string? ImageUrl { get; set; }

        public RecipeDataModel(string _name, List<string> _ingredients, List<string>? _instructions, string? _imageUrl)
        {
            this.Name = _name;
            this.Ingredients = _ingredients;
            this.Instructions = _instructions;
            this.ImageUrl = _imageUrl;
        }

        public RecipeDataModel()
        {
            
        }
    }
}

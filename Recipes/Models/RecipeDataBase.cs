using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class RecipeDataBase
    {
        static SQLiteAsyncConnection? Database;

        async static Task Init()
        {
            try
            {
                if (Database is not null)
                    return;
                Database = new SQLiteAsyncConnection(DataBaseConstants.DatabasePath, DataBaseConstants.Flags);
                var result = await Database.CreateTableAsync<RecipeDataModel>();
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif
                return;
            }
        }

        public static async Task<List<RecipeDataModel>?> GetAllItemsAsync()
        {
            try
            {
                await Init();
                if (Database is not null)
                    return await Database.Table<RecipeDataModel>().ToListAsync();
                return null;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif
                return null;
            }
        }

        public static async Task<RecipeDataModel?> GetItemAsync(int _id)
        {
            try
            {
                await Init();
                if (Database is not null)
                    return await Database.Table<RecipeDataModel>().FirstOrDefaultAsync(m => m.Id == _id);
                return null;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif
                return null;
            }
        }

        public static async Task<int?> SaveItemAsync(RecipeDataModel _recipeData)
        {
            try
            {
                await Init();
                if (Database is not null)
                {
                    if (_recipeData.Id != 0)
                        return await Database.UpdateAsync(_recipeData);
                    return await Database.InsertAsync(_recipeData);
                }
                return null;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif
                return null;
            }
        }

        public static async Task<int?> DeleteItemAsync(RecipeDataModel _recipeData)
        {
            try
            {
                await Init();
                if (Database is not null)
                    return await Database.DeleteAsync(_recipeData);
                return null;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex);
#endif
                return null;
            }
        }

    }
}

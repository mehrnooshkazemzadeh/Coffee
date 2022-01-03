using Coffee.APIProvider;
using Coffee.WebApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Coffee.WebApplication.Services
{
    public class CoffeeStoreService : APIProvider<CoffeeStoreModel>, ICoffeeStoreService
    {


        public async Task<List<CoffeeStoreModel>> GetStoreInventory(Guid? CoffeeTypeId, Guid? storeId)
        {
            var result = await httpService.GetAsync($"GetStoreInventory?coffeTypeId={CoffeeTypeId}&storeId={storeId}");
            if (result.IsSuccessStatusCode)
            {
                var storeList = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<CoffeeStoreModel>>(storeList);
            }
            return new List<CoffeeStoreModel>();
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.WebApplication.Models
{
    public class StoreInventoryModel
    {
        public List<CoffeeStoreModel> StoreInventories { get; set; }
        public List<StoreModel> Stores { get; set; }
        public Guid? StoreId { get; set; }
        public List<CoffeeTypeModel> CoffeeTypes{ get; set; }
        public Guid? CoffeeTypeId { get; set; }
    }
}

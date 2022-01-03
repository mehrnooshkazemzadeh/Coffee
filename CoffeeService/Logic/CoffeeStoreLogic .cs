using CoffeeService.Entities;
using CoffeeService.Models;
using Framework.Core.Logic;
using Framework.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeService.Logic
{
    public class CoffeeStoreLogic : BusinessOperations<CoffeeStoreModel, CoffeeStore, Guid>, ICoffeeStoreLogic
    {
        public CoffeeStoreLogic(IPersistenceService<CoffeeStore> service) : base(service)
        {
        }

        public List<CoffeeStoreModel> GetInventory(Guid? coffeeTypeId, Guid? storeId)
        {
            var result = GetData<CoffeeStoreModel>(x =>
             (!storeId.HasValue || x.StoreId == storeId)
             && (!coffeeTypeId.HasValue || x.Coffee.CoffeeTypeId == coffeeTypeId) && x.Poststatus == Enums.PostStatusEnum.Recieved
             , includes: new List<string> { "Coffee.CoffeeType" });
            if (result.ResultStatus == OperationResultStatus.Successful)
            {
                return result.ResultEntity.GroupBy(x => new { x.StoreId, x.Coffee.CoffeeTypeId, x.Coffee.CoffeeType.Title })
                    .Select(x =>
                  new CoffeeStoreModel
                  {
                      StoreId = x.Key.StoreId,
                      CoffeeTypeName = x.Key.Title,
                      CoffeeTypeId = x.Key.CoffeeTypeId,
                      Quantity = x.Sum(y => y.Quantity)
                  }
                ).ToList();
            }
            return new List<CoffeeStoreModel>();

        }

    }
}

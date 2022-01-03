using CoffeeService.Logic;
using CoffeeService.Models;
using Framework.Core.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeStoreController : ControllerBase
    {
        private readonly ILogger<CoffeeStoreController> logger;

        private ICoffeeStoreLogic coffeeStoreLogic;
        private readonly ILogic<CoffeeTypeModel> coffeeTypeLogic;

        public CoffeeStoreController(ILogger<CoffeeStoreController> logger, ICoffeeStoreLogic coffeeStoreLogic,ILogic<CoffeeTypeModel> coffeeTypeLogic)
        {
            this.logger = logger;
            this.coffeeStoreLogic = coffeeStoreLogic;
            this.coffeeTypeLogic = coffeeTypeLogic;
        }
        // GET: api/<CoffeeStoreController>
        [HttpGet]
        public List<CoffeeStoreModel> Get()
        {
           
            var result = coffeeStoreLogic.GetAll();
            if (result.ResultStatus == OperationResultStatus.Successful)
            {
                var coffeTypes = coffeeTypeLogic.GetAll();
                result.ResultEntity.ForEach(x =>
                {
                    x.CoffeeTypeName = coffeTypes.ResultEntity.Where(y => y.CoffeeTypeId == x.Coffee.CoffeeTypeId).Select(y => y.Title).FirstOrDefault();
                });
                return result.ResultEntity;
            }
            return new List<CoffeeStoreModel>();
        }

        // GET api/<CoffeeStoreController>/5
        //[HttpGet("{id}/{storeId}")]
        //[Route("GetStoreInventory/{id}/{storeId}")]
        //public List<CoffeeStoreModel> Get(Guid id , Guid storeId)
        //{
        //    return coffeeStoreLogic.GetInventory(id, storeId);
        //}

        [HttpGet("GetStoreInventory")]
        public List<CoffeeStoreModel> GetStoreInventory(Guid? coffeTypeId , Guid? storeId)
        {
            return coffeeStoreLogic.GetInventory(coffeTypeId, storeId);
        }


        // POST api/<CoffeeStoreController>
        [HttpPost]
        public CoffeeStoreModel Insert([FromBody] CoffeeStoreModel coffeeStoreModel)
        {
            var result = coffeeStoreLogic.AddNew(coffeeStoreModel);
            if (result.ResultStatus == OperationResultStatus.Successful)
                return result.ResultEntity;
            return null;
        }

        // PUT api/<CoffeeStoreController>/5
        [HttpPut()]
        public bool Update([FromBody] CoffeeStoreModel coffeeStoreModel)
        {
            var result = coffeeStoreLogic.Update(coffeeStoreModel);
            if (result.ResultStatus == OperationResultStatus.Successful)
                return true;
            return false;
        }

        // DELETE api/<CoffeeStoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

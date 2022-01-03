using Coffee.APIProvider;
using Coffee.WebApplication.Models;
using Coffee.WebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICoffeeStoreService coffeeStoreService;
        private readonly IAPIProvider<StoreModel> storeService;
        private readonly IAPIProvider<CoffeeTypeModel> coffeeTypeService;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration,ICoffeeStoreService coffeeStoreService
            , IAPIProvider<StoreModel> storeService,IAPIProvider<CoffeeTypeModel> coffeeTypeService)
        {
            _logger = logger;
            coffeeStoreService.Initialize(configuration.GetSection("ServiceAddresses").GetSection("CoffeeStoreServiceAddress").Value);
            storeService.Initialize(configuration.GetSection("ServiceAddresses").GetSection("StoreService").Value);
            coffeeTypeService.Initialize(configuration.GetSection("ServiceAddresses").GetSection("CoffeeTypeServiceAddress").Value);
            this.coffeeStoreService = coffeeStoreService;
            this.storeService = storeService;
            this.coffeeTypeService = coffeeTypeService;
        }

        public IActionResult Index(Guid? coffeeTypeId, Guid? storeId)
        {
            var coffeToStoreModel = new StoreInventoryModel
            {
                StoreInventories = coffeeStoreService.GetStoreInventory(coffeeTypeId, storeId).Result,
                Stores = storeService.GetAll().Result,
                CoffeeTypes = coffeeTypeService.GetAll().Result
            };
            return View(coffeToStoreModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

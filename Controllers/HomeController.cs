using bulkAction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bulkAction.Data;

namespace bulkAction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<Product> obj = _db.products.ToList();  
            return View(obj);
        }
        public IActionResult bulkDataDelete(List<Product> product)
        {

                foreach (var dataFromArray in product)
                {
                    if (dataFromArray.isChecked)
                    {
                    Product data = _db.products.Find(dataFromArray.Id);
                    _db.products.Remove(data);
                }  
                }
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public IActionResult bulkDataSave(List<Product> product)
        {
           foreach ( var dataFromDB in _db.products)
                {
                    bool flag = false;
                    foreach (var dataFromArray in product)
                    {
                        if(dataFromArray.Id != 0)
                        {
                            if(dataFromArray.Id == dataFromDB.Id)
                            {
                            Product obj = _db.products.Find(dataFromDB.Id);
                            obj.Name = dataFromArray.Name;
                            obj.Type = dataFromArray.Type;
                            obj.price = dataFromArray.price;
                            obj.isChecked = dataFromArray.isChecked;
                            flag = true;
                            break;
                            }
                        }
                    }
                   if(flag == false)
                    {
                        Product data = _db.products.Find(dataFromDB.Id);
                        _db.products.Remove(data);
                    }
                }
            foreach (var dataFromArray in product)
            {
                if (dataFromArray.Id == 0)
                {
                    Product value = new Product();
                    value.Name = dataFromArray.Name;
                    value.Type = dataFromArray.Type;
                    value.price = dataFromArray.price;
                    value.isChecked = dataFromArray.isChecked;
                    _db.products.Add(value);
                }
            }
           _db.SaveChanges();
            return RedirectToAction("Index", "Home");

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
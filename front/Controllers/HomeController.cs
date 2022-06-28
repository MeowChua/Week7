using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using front.Models;
using CustomerSite.Helper;

namespace front.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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
    /*
    APIHelper _api = new APIHelper();

    public async Task<IActionResult> Index()
    {
        ViewBag.Id = 1;
        ViewBag.Name = "";
        ViewBag.Age = 0;
        ViewBag.Role = "";
        //ViewBag.Created = DateTime.Now.AddDays(0).ToString("dd-MM-yyyy");
        ViewBag.Created = DateTime.Now.ToUniversalTime().ToString("s") + "Z";
        ViewBag.PhoneNumber = "";

        Admin list = new Admin();

        List<Admin> data = new List<Admin>();
        HttpClient client = _api.initial();

        HttpResponseMessage res = await client.GetAsync("api/admin/");
        if (res.IsSuccessStatusCode)
        {
            var result = res.Content.ReadAsStringAsync().Result;
            data = JsonConvert.DeserializeObject<List<Admin>>(result);


            data.ForEach(d =>
            {
                list.admin.Add(new Admin
                {
                    Name = d.Name,
                    Id = d.Id,
                    Role = d.Role,
                    Age = d.Age,
                    PhoneNumber = d.PhoneNumber,
                    Created = d.Created
                });
            });
        }

        List<Admin> model = list.admin.ToList();

        return View(model);
    }
    */
}


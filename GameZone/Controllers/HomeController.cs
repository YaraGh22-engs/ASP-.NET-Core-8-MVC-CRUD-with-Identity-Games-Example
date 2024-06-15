using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly ApplicationDbContext _context;


        public HomeController(IGamesService gamesService,ApplicationDbContext context)
        {
            _gamesService = gamesService;
            _context = context;
        }


        public async Task<IActionResult> Index(string? seachName, string? categoryName,int pg=1)
        {
            var games = _gamesService.GetAll();
            //Searching
            if (!string.IsNullOrEmpty(seachName))
            {
                games = games.Where(g => g.Name.ToLower().Contains(seachName.ToLower())
                    || g.Description.ToLower().Contains(seachName.ToLower())).ToList();
            }
            //Filtering
            else if (categoryName != null)
            {
                games = games.Where(g => g.Category.Name.ToLower() == categoryName.ToLower()).ToList();
            }
            ViewBag.seachName = seachName;
            ViewBag.Categories = _context.Categories.ToList();
            //Pagenation
            const int pageSize= 6;
            if(pg<1) { pg = 1; }
            int rescCount = games.Count();
            var pager = new Pager(rescCount,pg,pageSize);
            int recSkip = (pg - 1)*pageSize ;
            var data = games.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(data);
        }
         

        public IActionResult Cascade()
        {
            var categories = _context.Categories.ToList();
            var games = new List<Game>();

            ViewBag.Categories =new SelectList(categories,"Id","Name");
            ViewBag.Games = new SelectList(games, "Id", "Name");
            return View();
        }

        //public IActionResult Search(string seachName)
        //{
        //    var games = _gamesService.GetAll();
        //    if (!string.IsNullOrEmpty(seachName))
        //    {
        //        games = games.Where(g => g.Name.ToLower().Contains(seachName.ToLower())
        //            || g.Description.ToLower().Contains(seachName.ToLower())).ToList();
        //    }
        //    ViewBag.seachName = seachName;
        //    return View("Index", games);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetGameByCategoryId(int categoryId)
        {
            return Json(_context.Games.Where(u=>u.CategoryId== categoryId).ToList());
        }
    }
}

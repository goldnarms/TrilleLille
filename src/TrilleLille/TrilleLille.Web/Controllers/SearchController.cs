using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TrilleLille.Web.Models;

namespace TrilleLille.Web.Controllers{
    public class SearchController: Controller{
        private readonly TrilleLilleContext _trilleLilleContext;

        public SearchController(TrilleLilleContext trilleLilleContext)
        {
            _trilleLilleContext = trilleLilleContext;
        }

        public IActionResult Index(string seachTerm)
        {
            var results = _trilleLilleContext.Groups?.Where(g => g.Location.ZipCode.ToString() == seachTerm);
            return View(results);
        }
        
    }
}
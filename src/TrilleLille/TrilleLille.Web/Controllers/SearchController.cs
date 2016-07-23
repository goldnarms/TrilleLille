namespace TrilleLille.Web.Controllers{
    public class SearchController: Controller{
        public SearchController(){

        }

        public IActionResult Index(){
            return View();
        }

        public IActionResult Search(string seachTerm){
            return View();
        }
        
    }
}
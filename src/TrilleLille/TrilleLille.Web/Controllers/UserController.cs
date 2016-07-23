namespace TrilleLille.Web.Controllers{
    public class UserController: Controller{
        public UserController(){

        }

        public IActionResult Details(string userId){
            return View();
        }

        public IActionResult Edit(string userId){
            return View();
        }
        
    }
}
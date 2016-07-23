namespace TrilleLille.Web.Controllers {
    public class GroupController: Controller {
        private TrilleLilleContext _trilleLilleContext;
        public GroupController(TrilleLilleContext trilleLilleContext){
            _trilleLilleContext = trilleLilleContext;
        }

        public IActionResult Index(){
            return View();
        }

        public IActionResult Details(int groupId){
            
        }

        [Authorize]
        public IActionResult JoinGroup(int groupId){

        }

        [Authorize]
        public IActionResult LeaveGroup(int groupId){

        }
    }
}
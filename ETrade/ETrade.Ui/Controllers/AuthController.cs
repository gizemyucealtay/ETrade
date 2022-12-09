using ETrade.Dto;
using ETrade.Entity.Concretes;
using ETrade.Ui.Models.ViewModels;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.Ui.Controllers
{
    public class AuthController : Controller
    {
        

        UsersModel _model;
        IUow _uow;
        public AuthController(UsersModel model, IUow uow)
        {
            _model = model;
            _uow = uow;

        }
        public IActionResult Register()
        {
            _model.Users = new Users();
            _model.Counties = _uow._countyRep.List();
            return View(_model);
        }
        [HttpPost]
        public IActionResult Register(UsersModel m)
        {
            m.Users = _uow._usersRep.CreateUser(m.Users);
            if (m.Users.Error == false)
            {

                _uow._usersRep.Add(m.Users);
                _uow.Commit();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                m.Counties = _uow._countyRep.List();
                m.Msg = $"{m.Users.Mail} zaten mevcut";
                return View(m);

            }


        }
        public IActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Mail,string Password)//model i olmadıgı icin bu parametreleri atıyoruz
        {
            UserDTO user = _uow._usersRep.Login(Mail, Password);
            if (user.Error==false) //hata var mı yok mu diye bakıyoruz
            {
                HttpContext.Session.SetString("User",JsonConvert.SerializeObject(user));
                if (user.Role=="Admin")
                {
                   return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }
    }
}

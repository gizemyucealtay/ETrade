using ETrade.Dto;
using ETrade.Entity.Concretes;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.Ui.Controllers
{
    public class BasketMasterController : Controller
    {
        IUow _uow;

        BasketMaster _basketMaster;
        public BasketMasterController(IUow uow, BasketMaster basketMaster)
        {
            _uow = uow;
            _basketMaster = basketMaster;
        }
        public IActionResult Create()
        {
            var usr = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User")); //hangi user la login oldugunu burda kontrol ediyoruz
            var selectedBasket = _uow._basketMasterRep.Set().FirstOrDefault(x => x.Completed == false && x.EntityId == usr.Id); //tamamlanmamış bir şey var mı ve hangi user ın 
            if (selectedBasket != null) //null ise sepet boşsa
            {
                return RedirectToAction("Add", "BasketDetail", new { id = selectedBasket.Id });
            }
            else //her şey tamamsa aşağıdakileri yap
            {
                _basketMaster.OrderDate = DateTime.Now;
                _basketMaster.EntityId = usr.Id;  //bunları kullanıcılar giremez 
                _uow._basketMasterRep.Add(_basketMaster);
                _uow.Commit();
                return RedirectToAction("Add", "BasketDetail", new { id = _basketMaster.Id }); //basket master in id sini gönderiyo basketdetail a otomatik artmıyo
            }

            return View();
        }
    }
}

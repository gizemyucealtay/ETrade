using ETrade.Entity.Concretes;
using ETrade.Ui.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Ui.Controllers
{
    public class BasketDetailController : Controller
    {
        BasketDetailModel _detailModel;
        IUow _uow;
        BasketDetail _basketDetail;
        public BasketDetailController(BasketDetailModel detailModel, IUow uow, BasketDetail basketDetail)
        {
            _detailModel = detailModel;
            _uow = uow;
            _basketDetail = basketDetail;
        }

        public IActionResult Add(int Id) //basketmaster dan gelen ıd
        {
            _detailModel.ProductDTO = _uow._productsRep.GetProductsSelect();
            _detailModel.BasketDetailDTOs = _uow._basketDetailRep.BasketDetailDTOs(Id);
            return View(_detailModel);
        }
        [HttpPost]
        public IActionResult Add(BasketDetailModel m, int Id)
        {
            Products products = _uow._productsRep.FindWithVat(m.ProductId);
            _basketDetail.Amount = m.Amount;
            _basketDetail.ProductId=m.ProductId;
            _basketDetail.Id=Id;
            _basketDetail.OrderId =Id;
            _basketDetail.UnitId=products.UnitId;
            _basketDetail.Ratio=products.Vat.Ratio; // Eager Loading den dolayı patlar find yaparsak
            _basketDetail.UnitPrice=products.UnitPrice;
            _uow._basketDetailRep.Add(_basketDetail);
            _uow.Commit();
            
            return RedirectToAction("Add", new {Id});
            
            //_detailModel.ProductDTO = _uow._productsRep.GetProductsSelect();
            //return View(_detailModel);
        }
        public IActionResult Delete(int Id, int productId) //gidip methodlara composite key için uygun olanı ekliyoruz (core da) 
                                                           //burda Id2 dememize gerek yok istediğimiz ismi verebiliriz gidip Id2 ye yerleşicek
        {
            _uow._basketDetailRep.Delete(Id, productId);//burda sadece Id dersek neyi silyeceğini bilemez karıştırır product Id de dememiz gerekiyor (composite key)
            _uow.Commit();
            return RedirectToAction("Add", new { Id }); //redirect de yeni bir Id nesnesi yaratıp göndermek gerekiyor
        }

        public IActionResult Update(int Id, int productId)
        {
            return View(_uow._basketDetailRep.Find(Id, productId));//hangi kaydı update ediceğimizi buluyoruz

        }
        [HttpPost]
        public IActionResult Update(int Amount, int Id, int productId)
        {
            var selectedBasDetail = _uow._basketDetailRep.Find(Id, productId); //hangi kaydı update ediceğimizi buluyoruz ve bir değişkene atıyoruz burda
            selectedBasDetail.Amount = Amount; //sadece amount ı değiştirmek istiyoruz
            _uow._basketDetailRep.Update(selectedBasDetail);
            _uow.Commit();
            return RedirectToAction("Add", new { Id });


        }
    }
}

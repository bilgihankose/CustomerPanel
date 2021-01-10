using CustomerPanel.Repository;
using CustomerPanel.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace CustomerPanel.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICafeRepository _cafeRepository;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(ICafeRepository cafeRepository, ICustomerRepository customerRepository)
        {
            _cafeRepository = cafeRepository;
            _customerRepository = customerRepository;
        }



        public ActionResult Index()
        {
            var model = new CustomerViewModel()
            {
                cafes = _cafeRepository.GetCafes().ToList()
            };

            ViewBag.Title = "Müşteri Kayıt Ekranı";

            return View(model);
        }
        [HttpPost]
        public ActionResult AddCustomer(CustomerViewModel model)
        {
            var ResponseModel = new ResponseViewModel();

            if (ModelState.IsValid)
            {
                if (model.CafeId == 1)
                {

                    bool? durum; 
                    try
                    {
                        using (TcKimlikNoDogrula.KPSPublicSoapClient servis = new TcKimlikNoDogrula.KPSPublicSoapClient())
                        {
                            durum = servis.TCKimlikNoDogrula(model.Tc, model.Name.ToUpper(), model.Surname.ToUpper(), model.Year);
                        }
                    }
                    catch
                    {
                        durum = null;

                    }
                    if (durum == true)
                    {
                        ResponseModel.Response = true;
                        _customerRepository.AddCustomer(model);
                    }
                    else
                        ResponseModel.Response = false;

                }
                if (model.CafeId == 2)
                {
                    _customerRepository.AddCustomer(model);
                    ResponseModel.Response = true;
                }
                
            }

            else
            {
                ResponseModel.Response = false;
            }

            return View("Result",ResponseModel);

        }

    }
}
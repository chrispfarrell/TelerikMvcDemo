using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Telerik.Web.Mvc;
using TelerikMvc.Data;

namespace TelerikMvc.Web.Controllers
{
    public class GridController : Controller
    {
        public ActionResult Index()
        {
            var themes = new List<string>
                             {
                                 "Black",
                                 "Default",
                                 "Forrest",
                                 "Hay",
                                 "Office2007",
                                 "Office2010Black",
                                 "Office2010Blue",
                                 "Office2010Silver",
                                 "Outlook",
                                 "simple",
                                 "Sitefinity",
                                 "Sunset",
                                 "Telerik",
                                 "Transparent",
                                 "Vista",
                                 "Web20",
                                 "WebBlue",
                                 "Windows7"
                             };
            return View(themes);
        }

        #region StaticBindingExample
        public ActionResult StaticBinding()
        {
            var context = new TelerikDemoDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            return View(context.Customers.ToList());
        }
        #endregion

        #region AJAX Binding Example
        public ActionResult AjaxBinding()
        {
            return View();
        }

        [GridAction]
        public ActionResult GetGridDataForAjaxBinding(int someValue)
        {
            var context = new TelerikDemoDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            return View(new GridModel(context.Customers));
        }
        #endregion

        public ActionResult ManualPaging()
        {
            return View();
        }
        [GridAction(EnableCustomBinding = true)]
        public ActionResult GetCustomersManualPaging(int page, int size)
        {
            var context = new TelerikDemoDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var result = context.GetCustomersPaged(page, size).ToList();
            var gridModel = new GridModel{
                Data = result,
                Total = 91
            };
            
            return View(gridModel);
        }
      

    }
}

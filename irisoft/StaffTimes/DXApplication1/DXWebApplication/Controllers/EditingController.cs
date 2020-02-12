using System;
using System.Web.Mvc;
using DevExpress.Web;
using DXWebApplication.Models;
using DevExpress.Web.Mvc;

namespace DXWebApplication.Controllers
{
    public partial class EditingController : Controller
    {
        public string Name { get { return "Editing"; } }


        public ActionResult EditModes()
        {
            return View("EditModes", NorthwindDataProvider.GetEditableProducts());
        }
        [ValidateInput(false)]
        public ActionResult EditModesPartial()
        {
            return PartialView("EditModesPartial", NorthwindDataProvider.GetEditableProducts());
        }
        public ActionResult ChangeEditModePartial(GridViewEditingMode editMode)
        {
            GridViewEditingDemosHelper.EditMode = editMode;
            return PartialView("EditModesPartial", NorthwindDataProvider.GetEditableProducts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditModesAddNewPartial(EditableProduct product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    NorthwindDataProvider.InsertProduct(product);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("EditModesPartial", NorthwindDataProvider.GetEditableProducts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditModesUpdatePartial(EditableProduct product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    NorthwindDataProvider.UpdateProduct(product);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("EditModesPartial", NorthwindDataProvider.GetEditableProducts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditModesDeletePartial(int productID = -1)
        {
            if (productID >= 0)
            {
                try
                {
                    NorthwindDataProvider.DeleteProduct(productID);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("EditModesPartial", NorthwindDataProvider.GetEditableProducts());
        }

        public ActionResult Index()
        {
            return RedirectToAction("EditModes");
        }

        public ActionResult EditModesAddNewPartial()
        {
            return RedirectToAction("EditModes");
        }
        public ActionResult EditModesUpdatePartial()
        {
            return RedirectToAction("EditModes");
        }
        public ActionResult EditModesDeletePartial()
        {
            return RedirectToAction("EditModes");
        }
    }
}
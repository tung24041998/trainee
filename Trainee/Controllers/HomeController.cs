using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trainee.Models;

namespace Trainee.Controllers
{
    public class HomeController : Controller
    {
        db_Trainee db_Trainee = new db_Trainee();
        public ActionResult Index(String name)
        {
            if (name == null)
            {
                return View(db_Trainee.Images);
            }
            else
            {
                return View(db_Trainee.Images.Where(x => x.Theme == name));
            }
        }
        public ActionResult Header()
        {
            return PartialView(db_Trainee.ThemeImages);
        }
        public ActionResult AddTheme()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTheme(ThemeImage ThemeImage)
        {
            if (ThemeImage.Theme == null)
            {
                ViewBag.ex = "Bạn chưa nhập chủ đề";
                return View();
            }
            else
            {
                var theme1 = db_Trainee.ThemeImages.FirstOrDefault(x => x.Theme == ThemeImage.Theme);
                if (theme1 == null)
                {
                    db_Trainee.ThemeImages.Add(ThemeImage);
                    db_Trainee.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.ex = "Đã có chủ đề này !";
                    return View();
                }
            }

        }
        public ActionResult uploadImage()
        {
            return View(db_Trainee.ThemeImages);
        }
        [HttpPost]
        public ActionResult uploadImage(HttpPostedFileBase file, Image image)
        {
            if (file != null && file.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Image"),
                                           Path.GetFileName(file.FileName));

                file.SaveAs(path);
                if (image.Theme == null)
                {
                    ViewBag.ex = "Bạn chưa nhập chủ đề !";
                    return View();
                }
                else
                {
                    image.Link = "/Content/Image/" + file.FileName;
                    image.Imagename = file.FileName;
                    db_Trainee.Images.Add(image);
                    db_Trainee.SaveChanges();
                    ViewBag.Message = "Tải thành công !";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Message = "Bạn chưa chọn ảnh !";
                return View();
            }
        }

    }
}
using ComparaçãoDeFicheirosExcel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComparaçãoDeFicheirosExcel.Controllers
{
    public class FicheirosController : Controller
    {
        // GET: Ficheiros
        public ActionResult FicheirosExcel()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult FicheirosExcel(PathFiles file)
        {

            string[] f1 = file.path_ficheiro1.Split('.');
            string[] f2 = file.path_ficheiro2.Split('.');
            if(f1[1] != "xlsx" || f2[1] != "xlsx")
            {
                Response.Write($"<script>alert('Extensão inválida!');</script>");
            }
            else
            
            {
                if(CompararFicheiros.CompareExcelSheets(file.path_ficheiro1, file.path_ficheiro2) == true)
                {
                    Response.Write($"<script>alert('Não houve alteração!');</script>");
                }
                else
                {
                    Response.Write($"<script>alert('Houve alteração!');</script>");
                }
            }
            return View();
        }

    }
}
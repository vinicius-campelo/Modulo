using MVC.MODULO.UI.Data;
using MVC.MODULO.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.MODULO.UI.Controllers
{
    public class HomeController : Controller
    {

        ///Acesso e Fazendo IDisposable da base de dados (garbage collector)
        private readonly MVCModuloDataContext db = new MVCModuloDataContext();
       

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// AtividadesController
        /// </summary>
        /// <returns> retona uma Lista de Atividades</returns>
        [HttpGet]
        public JsonResult RetornoJson()
        {
            var json = db.Atividades.ToList();
            return Json(json, JsonRequestBehavior.AllowGet);        
        }


     
        [HttpGet]
        public ActionResult Remove(int? id)
        {

            if (id != 0 || id != null)
            {
               
                var atividade = db.Atividades.Find(id);
                this.db.Atividades.Remove(atividade);
                this.db.SaveChanges();
                
            }
            else
            {
                return HttpNotFound();
            }
            return null;
        }


       


        /// <summary>
        /// Exibe os dados em Views Atividades Metodo Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult AddEdit(int? id)
        {
            Atividade atividade = new Atividade();

            if (id != null)
            {
                atividade = db.Atividades.Find(id);

                var selectList =
                    from c in ListaPrioridade()
                    select new SelectListItem
                    {
                        Selected = (c.Value == atividade.Prioridade),
                        Text = c.Text,
                        Value = c.Value
                    };
                    ViewBag.Prioridade = selectList.Distinct();

            }
            else
            {
                ViewBag.Prioridade = ListaPrioridade();
            }

            return View(atividade);
        }




        /// <summary>
        /// Cadastra os Dados da Lista de Atividades
        /// faz uma Action e retorna para Index.
        /// </summary>
        /// <param name="atividade"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddEdit(Atividade item)
        {

            if (ModelState.IsValid)
            {
                if (item.Id == 0)
                {
                    db.Atividades.Add(item);
                }
                else
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
                ///Atualiza o dropdownlist de prioridades
                ViewBag.Prioridade = ListaPrioridade();
                return RedirectToAction(".././");
            }

                ViewBag.Prioridade = ListaPrioridade();
                 return View(item);
        }


        /// <summary>
        /// Edita os dados da Lista de Atividades
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Atividades.Find(id));
        }


        /// <summary>
        /// Lista de Itens da propriedade
        /// </summary>
        /// <returns>Lista de Itens (SelectListItem)</returns>
        public List<SelectListItem> ListaPrioridade()
        {

            var tipoPrioridade = new List<SelectListItem>();
            tipoPrioridade.Add(new SelectListItem { Text = "Selecione", Value = "", Selected = true, Disabled=true  });
            tipoPrioridade.Add(new SelectListItem { Text = "ALTA", Value = "1" });
            tipoPrioridade.Add(new SelectListItem { Text = "MEDIA", Value = "2" });
            tipoPrioridade.Add(new SelectListItem { Text = "BAIXA", Value = "3" });

            return tipoPrioridade;

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

    }

}

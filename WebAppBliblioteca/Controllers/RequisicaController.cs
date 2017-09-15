using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppBliblioteca.Models;

namespace WebAppBliblioteca.Controllers
{
    public class RequisicaController : Controller
    {
        private BibliotecaContext db = new BibliotecaContext();

        // GET: Requisica
        public ActionResult Index()
        {
            var requisicaos = db.Requisicaos.Include(r => r.Livro);
            return View(requisicaos.ToList());
        }

        // GET: Requisica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisicao requisicao = db.Requisicaos.Find(id);
            if (requisicao == null)
            {
                return HttpNotFound();
            }
            return View(requisicao);
        }

        // GET: Requisica/Create
        public ActionResult Create()
        {
            ViewBag.LivroId = new SelectList(db.Livroes, "LivroId", "Isbn");
            return View();
        }

        // POST: Requisica/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequisicaoId,LivroId,AlunoId,DataRequisicao,DataEntrada")] Requisicao requisicao)
        {
            if (ModelState.IsValid)
            {
                db.Requisicaos.Add(requisicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LivroId = new SelectList(db.Livroes, "LivroId", "Isbn", requisicao.LivroId);
            return View(requisicao);
        }

        // GET: Requisica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisicao requisicao = db.Requisicaos.Find(id);
            if (requisicao == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivroId = new SelectList(db.Livroes, "LivroId", "Isbn", requisicao.LivroId);
            return View(requisicao);
        }

        // POST: Requisica/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequisicaoId,LivroId,AlunoId,DataRequisicao,DataEntrada")] Requisicao requisicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LivroId = new SelectList(db.Livroes, "LivroId", "Isbn", requisicao.LivroId);
            return View(requisicao);
        }

        // GET: Requisica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisicao requisicao = db.Requisicaos.Find(id);
            if (requisicao == null)
            {
                return HttpNotFound();
            }
            return View(requisicao);
        }

        // POST: Requisica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requisicao requisicao = db.Requisicaos.Find(id);
            db.Requisicaos.Remove(requisicao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

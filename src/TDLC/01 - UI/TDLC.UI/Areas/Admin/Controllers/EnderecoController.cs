using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TDLC.Infra.Entities;
using TDLC.Infra.Repository;
using TDLC.UI.Areas.Admin.Models.ViewModels;
using System.IO;
using TDLC.UI.Areas.Admin.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using bie.mvc.datatables;

namespace TDLC.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class EnderecoController : Controller
    {

        /* Repository<Endereco>*/
        RepositoryEndereco _Repo = new RepositoryEndereco();
        Repository<Linguagem> _RepoLng = new RepositoryLinguagem();



        // GET: Admin/Publicacao
        public ActionResult Index()
        {
            return View();

        }

        #region CRIAR 

        [HttpGet]
        public ActionResult Criar(string tipo)
        {

            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();

            //retorna a view
            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Criar(EnderecoViewmodel model)
        {
            #region preparacao 
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();

            var strCaminhobase = Server.MapPath("~/Content/Uploads");

            #endregion

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

                //Mapeia o conteúdo principal
                Endereco objEnt = Mapper.Map<EnderecoViewmodel, Endereco>(model);


                _Repo.Insert(objEnt);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }


        #endregion

        #region Editar
        [HttpGet]
        public ActionResult Editar(int id)
        {
            //carrega o item a ser editado
            var ent = _Repo.Find(id);
            var model = Mapper.Map<Endereco, EnderecoViewmodel>(ent);

            #region preparacao

            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            #endregion

            // retorna a view
            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(EnderecoViewmodel model)
        {

            #region PREPARACAO             
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            #endregion




            //TODO: Verificar porque o Automapper não está mapeando direito e remover esse mapeamento manual

            //Atualiza a publicação
            var entidade = _Repo.Find(model.id_endereco);

            //recupera o login do usuario atual
            var mgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = mgr.FindById(User.Identity.GetUserId());

            Mapper.Map(model, entidade, typeof(EnderecoViewmodel), typeof(Endereco));

            _Repo.Edit(entidade);
            _Repo.Save();
            return RedirectToAction("Index");

        }


        #endregion

        #region DELETAR 
        public JsonResult Deletar(int id)
        {
            //carrega a publicação do repositório

            var objEndereco = _Repo.Find(id);
            if (objEndereco == null) throw new HttpException(404, "Endereço não encontrado");
            _Repo.Delete(objEndereco);
            _Repo.Save();


            return Json("Comando executado com sucesso. Endereço ID: " + id.ToString() + " deletado! ", JsonRequestBehavior.AllowGet);

        }

        #endregion







    }//controller
}//namespace
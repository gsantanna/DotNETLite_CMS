using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDLC.Infra;
using TDLC.Infra.Entities;
using TDLC.Infra.Repository;
using TDLC.UI.Areas.Admin.Models.ViewModels;

namespace TDLC.UI.Controllers
{
    public class ComunicacaoController : Controller
    {





        public ActionResult Index(string cultura, string tipo, string item)
        {

            #region LOCALIZATION 
            //se a cultura veio preenchida atualiza a sessão para a cultura atual          
            if (cultura == "en_US" || cultura == "pt_BR")
            {
                HttpContext.Session["cultura"] = cultura;

            }
            else if (string.IsNullOrWhiteSpace(cultura) && string.IsNullOrWhiteSpace(Convert.ToString(Session["cultura"]))) //cultura não veio, carrega a cultura da sessão
            {
                HttpContext.Session["cultura"] = "pt_BR";
                cultura = "pt_BR";
            }
            else
            {
                cultura = Convert.ToString(Session["cultura"]);
            }
            #endregion

            #region TIPO DE PUBLICAÇÃO 

            IRepository<TipoPublicacao> _rep = new RepositoryTipoPublicacao();
            var objTpRepositorio = _rep.Query().FirstOrDefault(f => f.Nome_Tipo.ToLower().Contains(tipo.ToLower()));
            if (objTpRepositorio == null) return new HttpStatusCodeResult(404);
            ViewBag.imgheader = objTpRepositorio.CaminhoImagemHeader;
            ViewBag.Tipo = objTpRepositorio.Nome_Tipo.Split(',')[0];


            #endregion


            IRepository<Publicacao> _repPublicacao = new RepositoryPublicacao();


            //Exibir um item 
            if (!string.IsNullOrEmpty(item))
            {
                //carrega a publicação pelo ID 
                var publicacao = _repPublicacao.Query().First(f => f.URL.ToLower() == item.ToLower() || f.id_publicacao.ToString() == item);
                if (publicacao != null)
                {


                    publicacao.Conteudos = new List<ConteudoPublicacao> { publicacao.GetConteudo(cultura) };
                    var mdl = AutoMapper.Mapper.Map<Publicacao, PublicacaoViewmodel>(publicacao);
                    return View("Publicacao", mdl);
                }

            }


            //cria a viewmodel
            Models.PublicacoesSiteViewmodel model = new Models.PublicacoesSiteViewmodel();


            //carrega todas as publicações ( limite 30 por questão de performance) 
            var publicacoes = _repPublicacao.AllIncluding(x => x.Conteudos).Where(f => f.DataPublicacao <= DateTime.Now &&  f.id_tipopublicacao == objTpRepositorio.id_tipoPublicacao).OrderByDescending(o => o.DataPublicacao).Take(100).ToList();

            //mantém somente os itens da linguagem atual 
            foreach (var publicacao in publicacoes)
            {
                publicacao.Conteudos = new List<ConteudoPublicacao> { publicacao.GetConteudo(cultura) };
            }

            model.Publicacoes = AutoMapper.Mapper.Map<IEnumerable<Publicacao>, IEnumerable<PublicacaoViewmodel>>(publicacoes).ToList();


            //SACA o mais novo item com destaque topo 
            model.DestaqueTopo = model.Publicacoes.OrderByDescending(f => f.DataPublicacao).FirstOrDefault();
            model.Publicacoes.Remove(model.DestaqueTopo);

            //SACA as 3 mais reventes 
            model.DestaqueMedio = model.Publicacoes.OrderByDescending(f => f.DataPublicacao).Take(3).ToList();
            foreach (var dm in model.DestaqueMedio)
            {
                model.Publicacoes.Remove(dm);
            }


            


            return View(model);


        }


    }
}
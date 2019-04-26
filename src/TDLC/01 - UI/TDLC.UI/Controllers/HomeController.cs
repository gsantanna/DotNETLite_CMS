using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TDLC.Infra.Entities;
using TDLC.Infra.Repository;
using TDLC.UI.Areas.Admin.Models.ViewModels;
using TDLC.UI.Models;
using TDLC.UI.Utility;

namespace TDLC.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        public ActionResult SetCulture(string c, string a, string co)
        {
            HttpContext.Session["cultura"] = c;
            return RedirectToAction(a, co, new { cultura = c });

        }


        Repository<Publicacao> _RepoPublicacao = new RepositoryPublicacao();

        Repository<Equipe> _RepoEquipe = new RepositoryEquipe();
        Repository<AreaAtuacao> _RepoAreaAtuacao = new RepositoryAreaAtuacao();
        Repository<Endereco> _RepoEnderecos = new RepositoryEndereco();




        #region HOME 

        public ActionResult Index(string cultura)
        {



            #region localization 
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

            //carrega as publicações que serão exibidas na home  
            HomeViewmodel vm = new HomeViewmodel();



            //Pega 2 destaques superiores
            var ent_destaquestop = _RepoPublicacao.AllIncluding(x => x.Conteudos).Where(f => f.DataPublicacao <= DateTime.Now && f.DestaqueTopo).OrderByDescending(f => f.DataPublicacao).Take(2).ToList();
            List<ConteudoPublicacao> conteudos = new List<ConteudoPublicacao>();


            //ent_destaquestop.ForEach(f => conteudos.AddRange(f.Conteudos.Where(g => g.Linguagem.Cultura == cultura)));
            ent_destaquestop.ForEach(f => conteudos.Add(f.GetConteudo(cultura)));
            vm.Destaques_topo = Mapper.Map<IEnumerable<ConteudoPublicacao>, IEnumerable<ConteudoPublicacaoViewmodel>>(conteudos).OrderByDescending(f => f.DataPublicacao).ToList();


            //pega 3 destaques home 
            var ent_destaqueshome = _RepoPublicacao.AllIncluding(x => x.Conteudos).Where(f => f.DataPublicacao <= DateTime.Now && f.Destaque).OrderByDescending(f => f.DataPublicacao).Take(3).ToList();

            List<ConteudoPublicacao> conteudos_destaque = new List<ConteudoPublicacao>();

            ent_destaqueshome.ForEach(f => conteudos_destaque.Add(f.GetConteudo(cultura)));



            vm.Destaques_home = Mapper.Map<IEnumerable<ConteudoPublicacao>, IEnumerable<ConteudoPublicacaoViewmodel>>(conteudos_destaque).OrderByDescending(f => f.DataPublicacao).ToList();


            return View(vm);
        }

        #endregion












        #region EQUIPE

        public ActionResult Equipe(string cultura)
        {

            #region localization 
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

            EquipeSiteViewmodel vm = new EquipeSiteViewmodel();

            #region SOCIO_FUNDADOR 

            //Pega 
            var sociofundador = _RepoEquipe.AllIncluding(x => x.Conteudos).FirstOrDefault(f => f.Tipo == Tipo_Equipe.FUNDADOR);
            if (sociofundador != null)
            {
                sociofundador.Conteudos = sociofundador.Conteudos.Where(f => f.Linguagem.Cultura == cultura).ToList();
                vm.SocioFundador = Mapper.Map<Equipe, EquipeViewmodel>(sociofundador);
            }
            else //n tem registro de fundados
            {
                vm.SocioFundador = new EquipeViewmodel
                {
                    Nome = "Fundador não cadastrado",
                    Tipo = Tipo_Equipe.FUNDADOR,
                    Conteudos = new List<ConteudoEquipeViewmodel> { new ConteudoEquipeViewmodel { Chamada = "Não Cadastrado", Descricao = "Não Cadastrado" } }

                };
            }


            #endregion



            #region SOCIOS 



            //Pega 
            var socios = _RepoEquipe.AllIncluding(x => x.Conteudos).Where(f => f.Tipo == Tipo_Equipe.SOCIO).OrderBy(f => f.Ordem).ToList();

            foreach (var item in socios) //deixa só o conteúdo referente a linguagem utilizada            
            {
                item.Conteudos = item.Conteudos.Where(f => f.Linguagem.Cultura == cultura).ToList();
            }

            vm.Socios = (socios == null) ? null : Mapper.Map<IEnumerable<Equipe>, IEnumerable<EquipeViewmodel>>(socios).ToList();


            #endregion


            #region Advogados 

            //Pega 
            var advogados = _RepoEquipe.AllIncluding(x => x.Conteudos).Where(f => f.Tipo == Tipo_Equipe.ADVOGADO).OrderBy(f => f.Ordem).ToList();

            foreach (var item in advogados) //deixa só o conteúdo referente a linguagem utilizada            
            {
                item.Conteudos = item.Conteudos.Where(f => f.Linguagem.Cultura == cultura).ToList();
            }

            vm.Advogados = (advogados == null) ? null : Mapper.Map<IEnumerable<Equipe>, IEnumerable<EquipeViewmodel>>(advogados).ToList();


            #endregion





            #region Equipe 
            //Pega 
            var equipe = _RepoEquipe.AllIncluding(x => x.Conteudos).Where(f => f.Tipo == Tipo_Equipe.EQUIPE).OrderBy(f => f.Ordem).ToList();

            foreach (var item in equipe) //deixa só o conteúdo referente a linguagem utilizada            
            {
                item.Conteudos = item.Conteudos.Where(f => f.Linguagem.Cultura == cultura).ToList();
            }

            vm.Equipes = (equipe == null) ? null : Mapper.Map<IEnumerable<Equipe>, IEnumerable<EquipeViewmodel>>(equipe).ToList();

            #endregion




            return View(vm);


        }//Equipe

        #endregion

        #region ESCRITORIO

        public ActionResult Escritorio()
        {
            return View();
        }


        #endregion


        #region ATUACAO
        public ActionResult Atuacao(string cultura)
        {
            #region localization 
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


            AreaAtuacaoSiteViewmodel vm = new AreaAtuacaoSiteViewmodel();


            #region Areas de Atuação 

            //Pega 
            var areas = _RepoAreaAtuacao.AllIncluding(x => x.Conteudos).Where(f => f.Pai == null).ToList();

            foreach (var item in areas) //deixa só o conteúdo referente a linguagem utilizada            
            {
                item.Conteudos = item.Conteudos.Where(f => f.Linguagem.Cultura == cultura).ToList();

                foreach (var filho in item.Filhos)
                {
                    filho.Conteudos = filho.Conteudos.Where(f => f.Linguagem.Cultura == cultura).ToList();
                }

            }


            vm.Areas = (areas == null) ? null : Mapper.Map<IEnumerable<AreaAtuacao>, IEnumerable<AreaAtuacaoViewmodel>>(areas).ToList();
            #endregion


            return View(vm);

        }

        #endregion



        #region Contato 
        [HttpGet]
        public ActionResult Contato()
        {
            var enderecos = _RepoEnderecos.QueryFast().Where(x => x.VisivelContato).OrderBy(x => x.Ordem);
            ViewBag.Enderecos = Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewmodel>>(enderecos);
            return View();
        }
        #endregion

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Contato(ContatoFormViewmodel model)
        {
            var enderecos = _RepoEnderecos.QueryFast().Where(x => x.VisivelContato).OrderBy(x => x.Ordem);
            ViewBag.Enderecos = Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewmodel>>(enderecos);

            if (ModelState.IsValid)
            {

                var qtdEnvios = (int?)Session["qtd_envios"];
                if (qtdEnvios.HasValue)
                {
                    qtdEnvios++;

                    if (qtdEnvios > 5) throw new HttpException(403, "Você já enviou muitos emails hoje");
                }
                else
                {
                    qtdEnvios = 1;
                }

                Session["qtd_envios"] = qtdEnvios;

                StringBuilder strCorpo = new StringBuilder();
                strCorpo.AppendLine("<html><body>");
                strCorpo.AppendLine("<h3>Detalhes da mensagem</h3>");
                strCorpo.AppendLine("<hr><table border='1'>");
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Nome", model.Nome);
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Email", model.Email);
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Telefone", model.Telefone);
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Assunto", model.Assunto);
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Mensagem", model.Mensagem);
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1} ({2:dd/MM/yyyy HH:mm})</td></tr>", "IP", model.IP, model.DataHora);
                strCorpo.AppendLine("</table>");
                strCorpo.AppendLine("</body></html>");

                var m = new EmailSVC();
                m.SendAsync(
                    System.Configuration.ConfigurationManager.AppSettings["FALE_CONOSCO_DESTINO"]
                    , "Site Antonelli", "Mensagem enviada através do fale conosco", strCorpo.ToString());
                //verifica se ele já enviou a quantidade máxima de items por sessão ( evitar DoS ) 


                ViewBag.status = "OK";
            }
            else
            {
                ViewBag.status = "FALHA";
            }
            return View();

        }


    }
}
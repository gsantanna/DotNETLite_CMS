
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TDLC.Infra.Entities;
using TDLC.Infra.Repository;
using TDLC.UI.Areas.Admin.Models.ViewModels;
using TDLC.UI.Models;

namespace TDLC.UI.Controllers
{

    public class ApiController : Controller
    {
        public class _retorno
        {
            public object data { get; set; }
        }

        [HttpGet]
        public JsonResult publicacoes(string metodo, string parametro)
        {
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();


            RepositoryPublicacao _Repo = new RepositoryPublicacao();
            _retorno objRet = new _retorno();

            //GET ALL
            if (string.IsNullOrWhiteSpace(metodo))
            {
                var _mdl = _Repo.GetPublicacoesApi();
                objRet.data = Mapper.Map<IEnumerable<PublicacaoApi>, IEnumerable<PublicacaoApiViewmodel>>(_mdl);

            }

            //retorna o objeto 
            return new JsonResult2 { Data = objRet };

        }

        [HttpGet]
        public JsonResult equipe(string metodo, string parametro)
        {
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();


            Repository<Equipe> _Repo = new RepositoryEquipe();
            _retorno objRet = new _retorno();

            //GET ALL
            if (string.IsNullOrWhiteSpace(metodo))
            {
                var _mdl = _Repo.Query().ToArray();
                objRet.data = Mapper.Map<IEnumerable<Equipe>, IEnumerable<EquipeViewmodel>>(_mdl);

            }

            //retorna o objeto 
            return new JsonResult2 { Data = objRet };

        }



        [HttpGet]
        public JsonResult areaatuacao(string metodo, string parametro)
        {
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();


            Repository<AreaAtuacao> _Repo = new RepositoryAreaAtuacao();
            _retorno objRet = new _retorno();

            //GET ALL
            if (string.IsNullOrWhiteSpace(metodo))
            {
                var _mdl = _Repo.Query().ToArray();
                objRet.data = Mapper.Map<IEnumerable<AreaAtuacao>, IEnumerable<AreaAtuacaoViewmodel>>(_mdl);

            }

            //retorna o objeto 
            return new JsonResult2 { Data = objRet };

        }

        [HttpGet]
        public JsonResult institucional(string metodo, string parametro)
        {
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();


            Repository<Institucional> _Repo = new RepositoryInstitucional();
            _retorno objRet = new _retorno();

            //GET ALL
            if (string.IsNullOrWhiteSpace(metodo))
            {
                var _mdl = _Repo.Query().ToArray();
                objRet.data = Mapper.Map<IEnumerable<Institucional>, IEnumerable<InstitucionalViewmodel>>(_mdl);

            }

            //retorna o objeto 
            return new JsonResult2 { Data = objRet };

        }






        [HttpGet]
        public JsonResult enderecos(string metodo, string parametro)
        {
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();


            Repository<Endereco> _Repo = new RepositoryEndereco();
            _retorno objRet = new _retorno();

            

            //GET ALL
            if (string.IsNullOrWhiteSpace(metodo))
            {
                var _mdl = _Repo.Query().OrderBy(x => x.Ordem).ToArray();
                objRet.data = Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewmodel>>(_mdl);

            }
            else if(metodo.Equals("h", System.StringComparison.InvariantCultureIgnoreCase))
            {
                var _mdl = _Repo.Query().Where(x=> x.VisivelHome).OrderBy(x => x.Ordem).ToArray();
                objRet.data = Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewmodel>>(_mdl);
            }

            //retorna o objeto 
            return new JsonResult2 { Data = objRet };

        }








    }
}
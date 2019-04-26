using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDLC.UI.Areas.Admin.Models.ViewModels;

namespace TDLC.UI.Models
{
    public class PublicacoesSiteViewmodel
    {
        public List<PublicacaoViewmodel> Publicacoes { get; set; }
        
        public PublicacaoViewmodel DestaqueTopo { get; set; }

        public List<PublicacaoViewmodel> DestaqueMedio { get; set; }


        public PublicacoesSiteViewmodel()
        {
            Publicacoes = new List<PublicacaoViewmodel>();

            DestaqueTopo = new PublicacaoViewmodel();
            DestaqueMedio = new List<PublicacaoViewmodel>();





        }


    }
}
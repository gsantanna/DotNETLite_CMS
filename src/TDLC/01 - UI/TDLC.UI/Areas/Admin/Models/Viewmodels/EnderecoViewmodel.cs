using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using TDLC.Infra.Entities;
using System.Linq;

namespace TDLC.UI.Areas.Admin.Models.ViewModels
{
    public class EnderecoViewmodel
    {


        public int id_endereco { get; set; }




        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }

        [Required]
        public string Numero { get; set; }


        public string Complemento { get; set; }

        [Required]
        public string UF { get; set; }

        public string CEP { get; set; }

        public string Mapa { get; set; }


        [Display(Name = "É Sede?")]
        public bool ESede { get; set; }

        [Display(Name = "Exibir na home")]
        public bool VisivelHome { get; set; }

        [Display(Name = "Exibir na pg de contatos")]
        public bool VisivelContato { get; set; }

        [Required]
        public int Ordem { get; set; }

        public string Telefone { get; set; }

    


        public string Nome => $"{this.Cidade} - {this.Logradouro} {this.Numero}";


    }


}

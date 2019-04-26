

namespace TDLC.Infra.Entities
{
    
    public class Endereco
    {        
        public int id_endereco { get; set; }

        public string Cidade { get; set; }
        public string Bairro { get; set; }

        public string Logradouro  { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public string Telefone { get; set; }

        public string UF { get; set; }
        
        public string CEP { get; set; }
        
        public string Mapa { get; set; }

        public bool ESede { get; set; }

        public bool VisivelHome { get; set; }
        public bool VisivelContato { get; set; }

        public int Ordem { get; set; }

                
    }
}

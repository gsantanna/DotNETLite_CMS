
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{
    // Product
    internal class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {

        public EnderecoConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_endereco");
            HasKey(x => x.id_endereco);

            Property(x => x.Cidade).HasColumnName("cidade").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Bairro).HasColumnName("bairro").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Logradouro).HasColumnName("logradouro").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Numero).HasColumnName("numero").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Mapa).HasColumnName("mapa").IsOptional().IsUnicode(false).HasMaxLength(4000);

        }

    }
}


using System.Data.Entity;

namespace TDLC.Infra.Repository
{
    public class RepositoryEndereco : Repository<Entities.Endereco>
    {
        public RepositoryEndereco() { }
        public RepositoryEndereco(DbContext Context) : base(Context) { }

    }


}

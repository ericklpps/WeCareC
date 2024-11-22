using WeCare.Data;
using WeCare.Models;

namespace WeCare.Repositories
{
    public class MetaUsuarioRepository : Repository<MetaUsuario>, IMetaUsuarioRepository
    {
        public MetaUsuarioRepository(WeCareDbContext context) : base(context) { }

        // Adicione métodos específicos para `MetaUsuario`, se necessário
    }
}

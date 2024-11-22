using System.Collections.Generic;
using System.Threading.Tasks;
using WeCare.Models;

namespace WeCare.Repositories
{
    public interface IMetaRepository : IRepository<Meta>
    {
        Task<IEnumerable<Meta>> ObterMetasPorCategoria(string categoria); // Exemplo de método específico
    }
}

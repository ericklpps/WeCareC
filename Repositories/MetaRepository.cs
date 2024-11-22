using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCare.Data;
using WeCare.Models;

namespace WeCare.Repositories
{
    public class MetaRepository : Repository<Meta>, IMetaRepository
    {
        public MetaRepository(WeCareDbContext context) : base(context) { }

        public async Task<IEnumerable<Meta>> ObterMetasPorCategoria(string categoria)
        {
            return await _context.Metas.Where(m => m.Categoria == categoria).ToListAsync();
        }

        public override async Task AddAsync(Meta entity)
        {
            try
            {
                await base.AddAsync(entity);
                Console.WriteLine($"Meta adicionada: {entity.Descricao}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar meta: {ex.Message}");
                throw;
            }
        }

        public override async Task UpdateAsync(Meta entity)
        {
            try
            {
                await base.UpdateAsync(entity);
                Console.WriteLine($"Meta atualizada: {entity.Descricao}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar meta: {ex.Message}");
                throw;
            }
        }
    }
}

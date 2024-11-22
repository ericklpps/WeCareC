using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeCare.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(); // Obter todos os registros
        Task<T?> GetByIdAsync(int id); // Obter registro por ID
        Task AddAsync(T entity); // Adicionar um novo registro
        Task UpdateAsync(T entity); // Atualizar um registro existente
        Task DeleteAsync(int id); // Deletar um registro por ID
    }
}

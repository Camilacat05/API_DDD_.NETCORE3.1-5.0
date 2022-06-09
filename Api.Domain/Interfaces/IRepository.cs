using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T:BaseEntity // vai ser injentado nesse T que tenha herança de baseentity
    { //o CRUD         
        Task<T> InsertAsync(T item); // é um metodo assyncrono, a entidade é T 
        Task<T> UpdateAsync(T item);// uma tarefa que vai maanipular a entidade, o retorno é a entidade
        Task<bool> DeleteAsync(Guid id); // o retorno é booleano
        // o id do tipo guid, fica nessa representação fc072692-d322-448b-9b1b-ba3443943579
        Task<T> SelectAsync(Guid id);

        Task<IEnumerable<T>> SelectAsync() ; //aqui o retorno vai ser uma lista do tipo entidade, manipulação de dados que correpondem a 1 entidade

    }
}

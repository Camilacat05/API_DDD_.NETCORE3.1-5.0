using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity // significa que a classe BaseREPOSITORY VAI RECEBER UMA ENTIDAADE T  que vai herdar os metodos da interface IRepository que tambem recebe uma entidade T onde T pertence e see origina de BaseEntity 
    {
        // a classe vai receber a minha entidade através ddo mycontext

        protected readonly MyContext _context;// precisa inicializar uma variavel do tipo contexto para   recer o contexto no constructor da classe

        private DbSet<T> _dataset;
        //nunca esquecer de colocar o constructor da classe

        public BaseRepository(MyContext context) //inserindo o contexto por injenção de dependencia 
        {
            _context = context;
            _dataset = _context.Set<T>();

        }
        //metodos que a interface construiu 
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null) 
                    return false; // depois que retorna, ele n percorre o resto da função, apenas para a execução, pq ele ja retornou false, se n tiver o id pra deletar 

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
     
        }

        public async Task<T> InsertAsync(T item)
        {
         try
            {
                if (item.Id == Guid.Empty)// verificando de o Id ta vazio, se sim,ele vai criar um guid para aquele id
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreateAt = DateTime.UtcNow;// a entidade vai ser salva no banco de dados com a data atual
                _dataset.Add(item);//o dataset recebeu o obj item e vai salvar no banco, pq o db set ja vem do context, entao só salvar as mudanças desse metodo assync

              await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
          
            }
                return item;
        }
        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));// esse AnySync ja retorna true ou false se o id existe ou não no banco
        }
        public async Task<T> SelectAsync(Guid id) //tipo pesquisar o item com o id, retorna o item que buscou
        {
            try
            {
               return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync(); //aqui ta retornando todos os items do banco numa lista assincrona 

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));// vai receber uma entidade e vai procurar o objeto no banco de n, vai retornar nulo e se encontrar por Id ser igual ao do item.Id result vai receber o objeto item
                if (result == null) //aqui só diz que se ele não encontrar o item, o item não vai ser atualizado, vai retornar aapenas null, sem erro
                    return null;

                item.UpdateAt = DateTime.UtcNow; //Atualizando com a data de agora 
                item.CreateAt = result.CreateAt; //deixando com a msm data que o obj ja continha quando foi criado, apeenas esta atribuindo novamente na atualização

                _context.Entry(result).CurrentValues.SetValues(item); // depois da atualização, aqui mostra que o dataset(banco) vai entrar novas alterações de valores recorrentes no obj item

                await _context.SaveChangesAsync(); //depoiss de setado esses valores, é salvo as modificações no banco 
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return item;
        }
    }
}

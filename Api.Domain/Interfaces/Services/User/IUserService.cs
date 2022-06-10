using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll();// vai retornar uma lista de usuários

        Task<UserEntity> Post(UserEntity user);

        Task<UserEntity> Put (UserEntity user);// quem vai trabalhar cm esses metodo será a aplicação

        Task<bool> Delete(Guid id);
    }
}

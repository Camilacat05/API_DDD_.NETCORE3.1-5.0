using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace Api.Data.Context
{
    //essa interface é derivada do Design que ffoi intalada na classLib como pacote Nuget
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        //aqui é a implementação da interface
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações e é criado o banco com essas configurações e seta também o tipo de banco que será usado 
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString);
            return new MyContext(optionsBuilder.Options);//retorna o contexto conectado com o bando de dados 
        }
    }
}


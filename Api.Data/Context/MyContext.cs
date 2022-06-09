using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Context
{
 public   class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        //passando o contexto como opção para a base
        public MyContext (DbContextOptions<MyContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);// a reescrita do modelo
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);// Aqui ele recebe a entidade do domain e pega o mapeamento no UserrMap na interface Configure da entidade
        }
    }
}

using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Api.Data.Mapping
{

    //criada para mapear a entidade antes de ser criada no banco
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");// aqui estou definindo o nome da tabela desta entidade
            builder.HasKey(u => u.Id); //definindo que nesta entidade a chave primaria é o id                             
            builder.HasIndex(u => u.Email)//Cria um index para o email quee é um campo unico
                .IsUnique();
            builder.Property(u => u.Nome) //indica qque são propriedades da classe UserEntity
                .IsRequired()//nome obrigatorio de tamanho maximo 60
                .HasMaxLength(60);
            builder.Property(u => u.Email)
                .HasMaxLength(100);
        
        
        
        }
    }
}

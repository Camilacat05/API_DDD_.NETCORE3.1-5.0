using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //importar 
using System.Text;

namespace Api.Domain.Entities
{
 public abstract class BaseEntity //como ela vai ser uma herança de outra classe, ela vai ser abstract
    {
      [Key]//Aqui defini que o Id vai ser uma chave primaria
      public Guid Id { get; set; }
      private DateTime? _createAt; // o ? indica que a propriedade pode ou não receber um valor nulo 
      public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }//caso receba um valor nulo, irá pegar o tempo de agora e setar como value, se n, vai apenas setar o value recebido msm             


        public DateTime? UpdateAt { get; set; }


        //aqui é a base de todas ass entidades que serão criadas posteriormente, utilizando herança
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.Enuns;
using TutorialEcommerce.Domain.ValueObject;

namespace TutotrialEcommerce.Repositories.Seeds
{
    public class UsuarioSeed
    {
        public static void Seed(EfDbContext context)
        {
            var endereco = new Endereco("Rua teste", "teste","teste", "teste2356666", "teste2356666",Uf.AC, new Cep("03126-021"));

            context.Usuarios.AddOrUpdate(x=>x.Login, 
                new Usuario("adminMaster", new Cpf("40914294830"), new Email("teste@teste.com"),"testetesteteste", "testetesteteste", endereco  ));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.ValueObject;

namespace TutorialEcommerce.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        bool CpfCadastrado(Cpf cpf, int usuarioId);
        bool LoginJaCadastrado(string login, int usuarioId);
        Usuario Get(Email email);
        Usuario Get(int id);
        void Salvar(Usuario usuario);
    }
}

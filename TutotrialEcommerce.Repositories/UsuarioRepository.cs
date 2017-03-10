using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.IRepositories;
using TutorialEcommerce.Domain.ValueObject;

namespace TutotrialEcommerce.Repositories
{
    public class UsuarioRepository:IUsuarioRepository
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioRepository(IRepository<Usuario> usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public bool CpfCadastrado(Cpf cpf, int usuarioId)
        {
            return _usuarioRepository.Get().Any(x => x.Cpf.Codigo == cpf.Codigo
                                                     && x.Id != usuarioId);
        }

        public bool LoginJaCadastrado(string login, int usuarioId)
        {
            return _usuarioRepository.Get().Any(x => x.Login == login
                                                     && x.Id != usuarioId);
        }

        public Usuario Get(Email email)
        {
            return _usuarioRepository.Get().FirstOrDefault(x => x.Email.Endereco == email.Endereco);
        }

        public Usuario Get(int id)
        {
            return _usuarioRepository.Get(id);
        }

        public void Salvar(Usuario usuario)
        {
            _usuarioRepository.AddOrUpdate(usuario);
            _usuarioRepository.Commit();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.ValueObject;

namespace TutorialEcommerce.Domain.IApp
{
    public interface IUsuarioApp
    {
        Usuario Get(string login);
        Usuario Get(Email email);
        Usuario Get(int id);
        void Salvar(Usuario usuario);
    }
}

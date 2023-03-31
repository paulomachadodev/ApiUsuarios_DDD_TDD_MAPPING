using ApiUsuarios.Application.Models;
using ApiUsuarios.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Application.Mappings
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            //Usuario => UsuarioModel
            CreateMap<Usuario, UsuarioModel>();
        }
    }
}

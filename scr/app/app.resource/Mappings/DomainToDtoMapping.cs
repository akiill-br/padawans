using ApiResource.Application.DTOs;
using ApiResource.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Resource, ResourceDTO>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDotNet6.Application.DTOs;
using ApiDotNet6.Domain.Entities;
using AutoMapper;

namespace ApiDotNet6.Application.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<TableA, TableADTO>();
        }
    }
}

using ApiDotNet6.Application.DTOs;
using ApiDotNet6.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Application.Mappings
{
    public class DTOToDomainMapping : Profile
    {
        public DTOToDomainMapping()
        {
            CreateMap<TableADTO, TableA>();
        }
    }
}

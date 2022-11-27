using ApiDotNet6.Application.DTOs;
using ApiDotNet6.Application.DTOs.Validations;
using ApiDotNet6.Application.Services.Interfaces;
using ApiDotNet6.Domain.Entities;
using ApiDotNet6.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Application.Services
{
    public class TableAService : ITableAServices
    {
        private readonly ITableARepository _tableARepository;
        private readonly IMapper _mapper;

        public TableAService(ITableARepository tableARepository, IMapper mapper)
        {
            _tableARepository = tableARepository;
            _mapper = mapper;
        }

        public async Task<ResultService<TableADTO>> CreateAsync(TableADTO tableADTO)
        {
            if (tableADTO == null)
            {
                return ResultService.Fail<TableADTO>("O objeto deve ser informado");
            }
            if (tableADTO.IdAgency != 0)
            {
                return ResultService.Fail<TableADTO>("Campo não deve ser informado");
            }
            var result = new TableADTOValidator().Validate(tableADTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<TableADTO>("Problemas de validação", result);
            }
            var tableA = _mapper.Map<TableA>(tableADTO);
            var data = await _tableARepository.CreateAsync(tableA);
            return ResultService.Ok<TableADTO>(_mapper.Map<TableADTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var tableA = await _tableARepository.GetByIdAsync(id); 
            if(tableA == null) 
            {
                return ResultService.Fail("Registro não encontrado");
            }
            await _tableARepository.DeleteAsync(tableA);
            return ResultService.Ok("Registro foi deletado com sucesso");
        }
        
        public async Task<ResultService<ICollection<TableADTO>>> GetAllAsync()
        {
            var tableA = await _tableARepository.GetTableAAsync();
            return ResultService.Ok<ICollection<TableADTO>>(_mapper.Map<ICollection<TableADTO>>(tableA));
        }

        public async Task<ResultService<TableADTO>> GetByIdAsync(int id)
        {
            var tableA = await _tableARepository.GetByIdAsync(id);
            if (tableA == null)
            {
                return ResultService.Fail<TableADTO>("Registro não encontrado");
            }
            return ResultService.Ok(_mapper.Map<TableADTO>(tableA));
        }

        public async Task<ResultService> UpdateAsync(TableADTO tableADTO)
        {
            if (tableADTO == null)
            {
                return ResultService.Fail<TableADTO>("O objeto deve ser informado");
            }
            var result = new TableADTOValidator().Validate(tableADTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<TableADTO>("Problemas de validação", result);
            }
            var tableA = await _tableARepository.GetByIdAsync(tableADTO.IdAgency);
            if(tableA == null)
            {
                return ResultService.Fail("Registro não encontrado");
            }
            tableA = _mapper.Map<TableADTO, TableA>(tableADTO, tableA);
            await _tableARepository.UpdateAsync(tableA);
            return ResultService.Ok("Atualização feita com sucesso!");
        }
    }
}

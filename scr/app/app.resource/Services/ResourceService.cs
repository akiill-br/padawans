using ApiResource.Application.DTOs;
using ApiResource.Application.DTOs.Validations;
using ApiResource.Application.Services.Interfaces;
using ApiResource.Domain.Entities;
using ApiResource.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Application.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IMapper _mapper;

        public ResourceService(IResourceRepository resourceRepository, IMapper mapper)
        {
            _resourceRepository = resourceRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ResourceDTO>> CreateAsync(ResourceDTO resourceDTO)
        {
            if(resourceDTO == null)
            {
                return ResultService.Fail<ResourceDTO>("Objeto deve ser informado!");
            }
            if(resourceDTO.ID_RESOURCES != 0)
            {
                return ResultService.Fail<ResourceDTO>("ID_Resource não deve ser informado!");

            }
            var result = new ResourceDTOValidator().Validate(resourceDTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<ResourceDTO>("Problemas de validação!", result);
            }
            var resource = _mapper.Map<Resource>(resourceDTO);
            var data = await _resourceRepository.CreateAsync(resource);

            return ResultService.Ok<ResourceDTO>(_mapper.Map<ResourceDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var resource = await _resourceRepository.GetByIdAsync(id);
            if(resource == null)
            {
                return ResultService.Fail<ResourceDTO>("Registro não encontrado!");
            }

            await _resourceRepository.DeleteAsync(resource);
            return ResultService.Ok($"O ID: {resource.ID_RESOURCES} foi deletado!");
            
        }
        public async Task<ResultService> UpdateAsync(ResourceDTO resourceDTO)
        {
            if (resourceDTO == null)
            {
                ResultService.Fail("Objeto não informado!");
            }
            var validation = new ResourceDTOValidator().Validate(resourceDTO);
            if (!validation.IsValid)
            {
                return ResultService.RequestError("Problemas de validação dos campos!", validation);
            }
            var resource = await _resourceRepository.GetByIdAsync((int)resourceDTO.ID_RESOURCES);
            if(resource == null)
            {
                return ResultService.Fail("Registro não encontrado!");
            }
            resource = _mapper.Map<ResourceDTO, Resource>(resourceDTO, resource);
            await _resourceRepository.UpdateAsync(resource);
            return ResultService.Ok("Resource editado!");
        }
        public async Task<ResultService<ICollection<ResourceDTO>>> GetAsync()
        {
            var resource = await _resourceRepository.GetResourcesAsync();
            return ResultService.Ok<ICollection<ResourceDTO>>(_mapper.Map<ICollection<ResourceDTO>>(resource));

        }
        public async Task<ResultService<ResourceDTO>> GetByIdAsync(int id)
        {
            var resource = await _resourceRepository.GetByIdAsync(id);
            if(resource == null)
            {
                return ResultService.Fail<ResourceDTO>("Registro não encontrado!");
            }
            return ResultService.Ok(_mapper.Map<ResourceDTO>(resource));
        }
    }
}

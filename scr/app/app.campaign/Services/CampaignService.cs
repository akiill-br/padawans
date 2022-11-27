using AutoMapper;
using Frwk.Api.DotNet6.Application.DTOs;
using Frwk.Api.DotNet6.Application.DTOs.Validations;
using Frwk.Api.DotNet6.Application.Services.Interfaces;
using Frwk.ApiDotNet6.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frwk.Api.DotNet6.Application.Services
{
    public class CampaignService : ICampaignService
    {
        //private readonly ICampaignRepository _campaignRepository;
        //private readonly IMapper _mapper;

        //public CampaignService(ICampaignRepository campaignRepository, IMapper mapper)
        //{
        //    _campaignRepository = campaignRepository;
        //    _mapper = mapper;
        //}

        //public async Task<ResultService<CampaignDTO>> CreateAsync(CampaignDTO campaignDTO)
        //{
        //    if(campaignDTO == null)
        //    {
        //        return ResultService.Fail<CampaignDTO>("O objeto deve ser informado");

        //    }
        //    if(campaignDTO.IdCampaign !=0)
        //    {
        //        return ResultService.Fail<CampaignDTO>("O idCampaign não deve ser informado");

        //    }
        //    var result = new CampaignDTOValidator().Validate(campaignDTO);
        //    if (!result.IsValid)
        //    {
        //        return ResultService.ResquestError<CampaignDTO>("Problemas de validação", result);

        //    }
        //    //var campaign = _Map
        //}

        //public Task<ResultService> DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResultService<ICollection<CampaignDTO>>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResultService<CampaignDTO>> GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ResultService> UpdateAsync(CampaignDTO campaignDTO)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

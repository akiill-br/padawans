using ApiResource.Application;
using ApiResource.Application.DTOs;
using ApiResource.Application.Services;
using ApiResource.Domain.Repositories;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiResource.TDD
{
    public class ResourceServiceTestsValues
    {
        private ResourceService resourceService;
        public ResourceServiceTestsValues()
        {
            resourceService = new ResourceService(new Mock<IResourceRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingIdResource()
        {
            var result = resourceService.CreateAsync(new ResourceDTO { ID_RESOURCES = 999 });
            Assert.True(result.Result.Message == "ID_Resource não deve ser informado!");
        }
        [Fact]
        public void Put_SendingIdResourceNotExist()
        {
            var result = resourceService.UpdateAsync(new ResourceDTO
            {
                ID_RESOURCES = 999999999,
                ID_CAMPAIGN = 10,
                FULL_PATH = "string",
                RELATIVE_PATH = "string",
                FILENAME = "string",
                ID_RES_TYPE = 10,
                PRIORITY = 10,
                ID_IMG = 10,
                MESSAGE = "string",
                TIME_SECONDS = 10,
                URL = "string",
                ID_TRANSACTION = 10,
                ID_CAMPAIGN_PARENT = 10,
                CRC = "string"
            });
            Assert.True(result.Result.Message == "Registro não encontrado!");
        }

        [Fact]
        public void Delete_SendingIdResourceNotExist()
        {
            var result = resourceService.DeleteAsync(-1);
            Assert.True(result.Result.Message == "Registro não encontrado!");
            result = resourceService.DeleteAsync(999999999);
            Assert.True(result.Result.Message == "Registro não encontrado!");
        }

        [Fact]
        public void Get_SendingIdResourceNotExist()
        {
            var result = resourceService.GetByIdAsync(-1);
            Assert.True(result.Result.Message == "Registro não encontrado!");
            result = resourceService.GetByIdAsync(999999999);
            Assert.True(result.Result.Message == "Registro não encontrado!");
        }
    }
}

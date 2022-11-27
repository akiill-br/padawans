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
    public class ResourceServiceTestsBufferOverflow
    {
        private ResourceService resourceService;

        private string buffer = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"; //101 Chars

        public ResourceServiceTestsBufferOverflow()
        {
            resourceService = new ResourceService(new Mock<IResourceRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingBufferOverflow()
        {
            var result = resourceService.CreateAsync(new ResourceDTO
            {
                FULL_PATH = buffer,
                FILENAME = buffer,
                RELATIVE_PATH= buffer,
                URL= buffer,
                CRC = buffer

            });
            Assert.True(result.Result.Errors.Count == 7);
        }

        [Fact]
        public void Put_SendingBufferOverflow() 
        {
            var result = resourceService.UpdateAsync(new ResourceDTO
            {
                FULL_PATH = buffer,
                FILENAME = buffer,
                RELATIVE_PATH = buffer,
                URL = buffer,
                CRC = buffer

            });
            Assert.True(result.Result.Errors.Count == 7);

        }
    }
}

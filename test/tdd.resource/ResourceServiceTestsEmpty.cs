using ApiResource.Application;
using ApiResource.Application.DTOs;
using ApiResource.Application.Services;
using ApiResource.Domain.Repositories;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiResource.TDD
{
    public class ResourceServiceTestsEmpty
    {
        private ResourceService resourceService;

        public ResourceServiceTestsEmpty()
        {
            resourceService = new ResourceService(new Mock<IResourceRepository>().Object, new Mock<IMapper>().Object);
        }

        // Empty Test
        [Fact]
        public void Post_SendingEmptyResource()
        {
            
            var result = resourceService.CreateAsync(new ResourceDTO {});
            Assert.True(result.Result.Errors.Count == 2);
        }
        [Fact]
        public void Put_SendingEmptyResource()
        {
            
            var result = resourceService.UpdateAsync(new ResourceDTO {});
            Assert.True(result.Result.Errors.Count == 2);
        }
        [Fact]
        public void Get_SendingEmptyResourceID()
        {
            
            var result = resourceService.GetByIdAsync(0);
            Assert.False(result.Result.IsSuccess);
        }
        [Fact]
        public void Delete_SendingEmptyID()
        {
            var result = resourceService.DeleteAsync(0);
            Assert.False(result.Result.IsSuccess);
        }

        // Values Test
        


        //
    }
}

using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frwk.Api.DotNet6.Application.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        //public ICollection<ErrorValidation> Errors { get; set; }
        public static ResultService ResultError(string message,ValidationResult validationResult) 
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message
                //Errors = validationResult.Errors.Select(x => new ErrorValidation
                //{ Field = x.PropertyName, Message = x.ErrorMessage, IsError = true }).ToList()
            };
        }
    }
}

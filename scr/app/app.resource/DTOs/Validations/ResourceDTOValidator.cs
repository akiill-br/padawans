using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Application.DTOs.Validations
{
    public class ResourceDTOValidator : AbstractValidator<ResourceDTO>
    {
        public ResourceDTOValidator()
        {
            RuleFor(x => x.FILENAME)
                .MaximumLength(100)
                .WithMessage("Filename deve ser informado!");

            RuleFor(x => x.FULL_PATH)
                .MaximumLength(100)
                .WithMessage("FullPath deve ser válido!");

            RuleFor(x => x.ID_CAMPAIGN)
                .GreaterThan(0)
                .WithMessage("idCampaign deve ser válido!");

            RuleFor(x => x.MESSAGE)
                .MaximumLength(100)
                .WithMessage("Message deve ser informado!");

            RuleFor(x => x.RELATIVE_PATH)
                .MaximumLength(100)
                .WithMessage("Relative_Path deve ser informado!");

            RuleFor(x => x.ID_RES_TYPE)
                 .GreaterThan(-1)
                .WithMessage("Id_Res_Type deve ser válido!");

            RuleFor(x => x.PRIORITY)
                 .GreaterThan((short)0)
                .WithMessage("Priority deve ser válido!");
            
            RuleFor(x => x.ID_IMG)
                 .GreaterThan(-1)
                .WithMessage("ID_Img deve ser válido!");
            
            RuleFor(x => x.ID_CAMPAIGN_PARENT)
                 .GreaterThan(-1)
                .WithMessage("ID_Campaign_Parent deve válido!");
            
            RuleFor(x => x.ID_TRANSACTION)
                 .GreaterThan(-1)
                .WithMessage("ID_Transaction deve ser válido!"); 

            RuleFor(x => x.TIME_SECONDS)
                 .GreaterThan(-1)
                .WithMessage("Time_Seconds deve válido!");

            RuleFor(x => x.URL)
                .MaximumLength(100)
                .WithMessage("URL deve ser informado!");
            
            RuleFor(x => x.CRC)
                .MaximumLength(100)
                .WithMessage("CRC deve ser informado!");
        }
    }
}

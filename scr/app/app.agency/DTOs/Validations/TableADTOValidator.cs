using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Application.DTOs.Validations
{
    public class TableADTOValidator : AbstractValidator<TableADTO>
    {
        public TableADTOValidator()
        {
            RuleFor(x => x.AgencyCode)
                .GreaterThan((short)-1)
                .WithMessage("Agency Code erro de validação");

            RuleFor(x => x.IdData)
                .GreaterThan(0)
                .WithMessage("Id Data erro de validação");

            RuleFor(x => x.IdIf)
                .GreaterThan(0)
                .WithMessage("Id Iferro de validação");

            RuleFor(x => x.IdAgencyParent)
                .GreaterThan(-1)
                .WithMessage("Id Agency Parent erro de validação");

            RuleFor(x => x.StatusQueue)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1)
                .WithMessage("Status Quene erro de validação");

            RuleFor(x => x.NsuAttention)
                .GreaterThan(0)
                .WithMessage("Nsu Attention erro de validação");

           // RuleFor(x => x.BussinesDate) 

            RuleFor(x => x.Status)
                .MaximumLength(1)
                .NotEmpty()
                .NotNull()
                .WithMessage("Status erro de validação");

            RuleFor(x => x.IdSegment)
                .GreaterThan((short)-1)
                .WithMessage("Id Segment erro de validação");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Name erro de validação"); 

            RuleFor(x => x.PreviousBalance)
                .GreaterThan(0)
                .WithMessage("Previous Balance erro de validação");

            RuleFor(x => x.CurrentBalance)
                .GreaterThan(0)
                .WithMessage("Current Balance erro de validação");

            RuleFor(x => x.WorkedBalance)
                .GreaterThan(0)
                .WithMessage("Worked Balance erro de validação");

            RuleFor(x => x.Emails)
                .MaximumLength(8000)
                .WithMessage("Emails erro de validação");

            RuleFor(x => x.AttendenceDisable)
                .MaximumLength(1)
                .WithMessage("Attendence Disable erro de validação");

            RuleFor(x => x.QueueData)
                .MaximumLength(8000)
                .WithMessage("Queue Data erro de validação");

            RuleFor(x => x.EmailsTreasure)
                .MaximumLength(8000)
                .WithMessage("Emails Treasure erro de validação");

            RuleFor(x => x.EmailTreasure)
                .MaximumLength(8000)
                .WithMessage("Email Treasure erro de validação");

            RuleFor(x => x.TimezoneDifference)
                .GreaterThan((short)0)
                .WithMessage("Timezone Difference erro de validação");

        }
    }
}

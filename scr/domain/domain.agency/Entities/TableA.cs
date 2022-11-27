using ApiDotNet6.Domain.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDotNet6.Domain.Entities
{
    public sealed class TableA
    {
        public int IdAgency { get; private set; }
        public short AgencyCode { get; private set; }  
        public int IdData { get; private set; }
        public int IdIf { get; private set; }  
        public int? IdAgencyParent { get; private set; }
        [StringLength(1, ErrorMessage = "Status Queue inválido")]
        public string StatusQueue { get; private set; }
        public long NsuAttention { get; private set; } 
        public DateTime? BusinessDate { get; private set; }
        [StringLength(1, ErrorMessage = "Status inválido")]
        public string Status { get; private set; }
        public short IdSegment { get; private set; }
        [StringLength(100, ErrorMessage = "Nome inválido")]
        public string? Name { get; private set; }
        public decimal PreviousBalance { get; private set; }
        public decimal CurrentBalance { get; private set; }
        public decimal WorkedBalance { get; private set; } 
        public string? Emails { get; private set; }
        [StringLength(1, ErrorMessage = "Error: desativar presença")]
        public string? AttendenceDisable { get; private set; }
        public string? QueueData { get; private set; }
        public string? EmailsTreasure { get; private set; }
        public string? EmailTreasure { get; private set; }
        public short? TimezoneDifference { get; private set; }

        public TableA(
            short agencyCode, 
            string statusQueue, 
            long nsuAttention,
            string status, 
            short idSegment,  
            decimal previousBalance,
            decimal currentBalance,
            decimal workedBalance) 
        {
            Validation(agencyCode, statusQueue, nsuAttention, status, idSegment, previousBalance, currentBalance, workedBalance);
        }

        public TableA(int idAgency, 
            short agencyCode, 
            int idData, 
            int idIf, 
            int? idAgencyParent, 
            string statusQueue, 
            long nsuAttention, 
            string status, 
            short idSegment, 
            decimal previousBalance, 
            decimal currentBalance, 
            decimal workedBalance)
        {
            DomainValidationException.When(idAgency < 0, "Id da agência inválido");
            DomainValidationException.When(idData < 0, "Id data inválido");
            DomainValidationException.When(idIf < 0, "Id if inválido");
            DomainValidationException.When(idAgencyParent < 0, "Id agencia mãe inválido");
            DomainValidationException.When(idSegment < 0, "Segmento de id inválido");

            IdAgency = idAgency;
            IdData = idData;
            IdIf = idIf;
            IdAgencyParent = idAgencyParent;
            IdSegment = idSegment;
            
            Validation(agencyCode,statusQueue,nsuAttention,status,idSegment,previousBalance,currentBalance,workedBalance);
        }   

        private void Validation(
            short agencyCode,
            string statusQueue,
            long nsuAttention,
            string status,
            short idSegment,
            decimal previousBalance,
            decimal currentBalance,
            decimal workedBalance)
        {
            DomainValidationException.When(agencyCode < 0, "Agência inválido");
            DomainValidationException.When(string.IsNullOrEmpty(statusQueue), "Fila status inválido");
            DomainValidationException.When(nsuAttention < 0, "Inválido");
            DomainValidationException.When(string.IsNullOrEmpty(status), "Status inválido");
            DomainValidationException.When(idSegment < 0, "Identificação inválida");
            DomainValidationException.When(previousBalance < 0, "Saldo prévio inválido" );
            DomainValidationException.When(currentBalance < 0, "Saldo atual inválido");
            DomainValidationException.When(workedBalance < 0, "Saldo trabalhado inválido");


            AgencyCode = agencyCode;
            StatusQueue = statusQueue;
            NsuAttention = nsuAttention;
            Status = status;
            IdSegment = idSegment;
            PreviousBalance = previousBalance;
            CurrentBalance = currentBalance;
            WorkedBalance = workedBalance;
            
        }
    }
}

using Frwk.ApiDotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Frwk.ApiDotNet6.Domain.Entities
{
    public class Campaign
    {
        public int IdCampaign { get; private set; }
        public string? Name { get; private set; }
        public string? Status { get; private set; }
        public string StorageType { get; private set; }
        public DateTime? InitialDate { get; private set; }
        public DateTime? FinalDate { get; private set; }
        public short IdCampaignType { get; private set; }
        public int IdIf { get; private set; }
        public short IdChannel { get; private set; }
        public int? IdComponent { get; private set; }
        public string? ExecutionType { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public string? Messages { get; private set; }


        public Campaign(string storagetype,DateTime lastupdate)
        { }

        private void Validation(
            int idCampaign, 
            string? name,
            string? status,
            string storageType,
            DateTime? initialDate,
            DateTime? finalDate,
            short idCampaignType,
            int idIf,
            short idChannel,
            int? idComponent,
            string? executionType,
            DateTime lastUpdate,
            string? messages
            )
        {
            DomainValidationException.When(idCampaign <0, "idCampaign deve ser valido");
            DomainValidationException.When(name.Length >100, "name deve ser valido");
            DomainValidationException.When(status.Length >1, "status deve ser valido");
            DomainValidationException.When(string.IsNullOrEmpty(storageType) || storageType.Length > 1, "storageType deve ser valido");
            DomainValidationException.When(idCampaignType <0, "idCampaignType deve ser valido");
            DomainValidationException.When(idIf <0, "idIf deve ser valido");
            DomainValidationException.When(idChannel <0, "idChannel deve ser valido");
            DomainValidationException.When(idComponent <-1, "idComponent deve ser valido");
            DomainValidationException.When(string.IsNullOrEmpty(executionType) || executionType.Length > 1, "executionType deve ser valido");
            DomainValidationException.When(DateTime.Compare(lastUpdate,DateTime.MinValue) <=-1, "lastUpdate deve ser valido");
            DomainValidationException.When(string.IsNullOrEmpty(messages) || messages.Length > 1, "messages deve ser valido");

        }
    }

}

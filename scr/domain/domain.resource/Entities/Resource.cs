using ApiResource.Domain.Validations;

namespace ApiResource.Domain.Entities
{
    public sealed class Resource
    {

        public long ID_RESOURCES { get; private set; }
        public int ID_CAMPAIGN { get; private set; }
        public string? FULL_PATH { get; private set; }
        public string? RELATIVE_PATH { get; private set; }
        public string? FILENAME { get; private set; }
        public int? ID_RES_TYPE { get; private set; }
        public short PRIORITY { get; private set; }
        public long? ID_IMG { get; private set; }
        public string? MESSAGE { get; private set; }
        public int? TIME_SECONDS { get; private set; }
        public string? URL { get; private set; }
        public int? ID_TRANSACTION { get; private set; }
        public int? ID_CAMPAIGN_PARENT { get; private set; }
        public string? CRC { get; private set; }


        public Resource(
            int ID_CAMPAIGN, 
            string? FULL_PATH, 
            string? FILENAME, 
            string? MESSAGE,
            string? RELATIVE_PATH, 
            int? ID_RES_TYPE, 
            short PRIORITY,
            long? ID_IMG, 
            int? TIME_SECONDS, 
            string? URL, 
            int? ID_TRANSACTION, 
            int? ID_CAMPAIGN_PARENT, 
            string? CRC)
        {
            Validation(ID_CAMPAIGN, FULL_PATH, FILENAME, MESSAGE, RELATIVE_PATH, ID_RES_TYPE, PRIORITY, ID_IMG,
                TIME_SECONDS, URL, ID_TRANSACTION, ID_CAMPAIGN_PARENT, CRC);
        }

        public Resource(long id_Resource,
            int id_Campaign, 
            string? full_Path, 
            string? filename, 
            string? message, 
            string? relative_Path, 
            int? id_Res_Type, 
            short priority,
            long? id_Img, 
            int? time_Seconds, 
            string url, 
            int? id_Transaction, 
            int? id_Campaign_Parent, 
            string crc
            )
        {
            DomainValidationException.When(id_Resource < 0, "IdResource deve ser válido!");
            Validation(id_Campaign, full_Path, filename, message, relative_Path, id_Res_Type, priority, id_Img,
                time_Seconds, url, id_Transaction, id_Campaign_Parent, crc);

            this.ID_RESOURCES = id_Resource;
        }

        private void Validation(
            int id_Campaign, 
            string? full_Path, 
            string? filename, 
            string? message, 
            string? relative_Path, 
            int? id_Res_Type, 
            short priority,
            long? id_Img, 
            int? time_Seconds, 
            string? url, 
            int? id_Transaction, 
            int? id_Campaign_Parent, 
            string? crc)
        {
            DomainValidationException.When(id_Campaign < 0, "ID_Campaign deve ser válido!");

            DomainValidationException.When(full_Path == null ? false : full_Path.Length > 100, "fullPath deve ser válido!");
            DomainValidationException.When(filename == null ? false : filename.Length > 100, "filename deve ser válido!");
            DomainValidationException.When(relative_Path == null ? false : relative_Path.Length > 100, "Relative_Path deve ser válido!");

            DomainValidationException.When(id_Res_Type < -1, "ID_Res_Type deve ser válido!");
            DomainValidationException.When(priority < 0, "Priority deve ser válido!");
            DomainValidationException.When(id_Img < -1, "ID_Img deve ser válido!");
            DomainValidationException.When(time_Seconds < -1, "Time_Seconds deve ser válido!");
            DomainValidationException.When(url == null ? false : url.Length > 200, "URL deve ser válido!");
            DomainValidationException.When(crc == null ? false : crc.Length > 100, "CRC deve ser válido!");
            DomainValidationException.When(id_Transaction < -1, "ID_Trasaction deve ser válido!");
            DomainValidationException.When(id_Campaign_Parent < -1, "ID_Campaign_Parent deve ser válido!");

            this.ID_CAMPAIGN = id_Campaign;
            this.FULL_PATH = full_Path;
            this.FILENAME = filename;
            this.MESSAGE = message;
            this.RELATIVE_PATH = relative_Path;
            this.ID_RES_TYPE = id_Res_Type;
            this.PRIORITY = priority;
            this.ID_IMG = id_Img;
            this.TIME_SECONDS = time_Seconds;
            this.URL = url;
            this.CRC = crc;
            this.ID_TRANSACTION = id_Transaction;
            this.ID_CAMPAIGN_PARENT = id_Campaign_Parent;

        }


    }
}

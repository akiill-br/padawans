using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Application.DTOs
{
    public class TableADTO
    {
        public int IdAgency { get; set; }
        public short AgencyCode { get; set; }
        public int IdData { get; set; }
        public int IdIf { get; set; }
        public int? IdAgencyParent { get; set; }
        public string StatusQueue { get; set; }
        public long NsuAttention { get; set; }
        public DateTime? BussinesDate { get; set; }
        public string Status { get; set; }
        public short IdSegment { get; set; }
        public string? Name { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal WorkedBalance { get; set; }
        public string? Emails { get; set; }
        public string? AttendenceDisable { get; set; }
        public string? QueueData { get; set; }
        public string? EmailsTreasure { get; set; }
        public string? EmailTreasure { get; set; }
        public short? TimezoneDifference { get; set; }
    }
}

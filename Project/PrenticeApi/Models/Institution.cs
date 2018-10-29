
using System.ComponentModel.DataAnnotations.Schema;

namespace PrenticeApi.Models
{
    public class Institution
    {
        public short InstitutionId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSite { get; set; }
        public string ContactEmail { get; set; }
    }
}
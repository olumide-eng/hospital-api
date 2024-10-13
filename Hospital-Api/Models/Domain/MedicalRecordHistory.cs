using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Api.Models.Domain
{
    public class MedicalRecordHistory
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public int Version { get; set; }
        public int CreatedByUserId { get; set; }
        public Staff Staff { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}

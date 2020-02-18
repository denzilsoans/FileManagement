using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class FileData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string FileName { get; set; }

        [Required]
        public string Location { get; set; }

        public DateTime UploadedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service
{

    [Table("document")]
    public partial class Document
    {

        [Column("id"), Key]
        public long Id { get; set; }

        [Column("title"), MaxLength(255), Required]
        public string Title { get; set; } = "";

        [Column("ocr_text"), Required]
        public string OcrText { get; set; } = "";
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service {

    [Table("document")]
    public partial class Document {

        [Column("id"), Key]
        public long Id { get; set; }

        [Column("ocr_text")]
        public string Text { get; set; } = "";
    }
}


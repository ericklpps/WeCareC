using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeCare.Models
{
    [Table("GS_META")]
    public class Meta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("META_ID")]
        public int MetaId { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [MaxLength(50)]
        [Column("CATEGORIA")]
        public string Categoria { get; set; }

        [Column("ECONOMIA_ESTIMATIVA", TypeName = "NUMBER")]
        public decimal? EconomiaEstimativa { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("PRAZO")]
        public string Prazo { get; set; } = "Médio";
    }
}

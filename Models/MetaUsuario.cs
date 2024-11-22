using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeCare.Models
{
    [Table("GS_METAUSUARIO")]
    public class MetaUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("META_USUARIO_ID")]
        public int MetaUsuarioId { get; set; }

        [Required]
        [Column("USUARIO_ID")]
        public int UsuarioId { get; set; } // Relacionamento com GS_USUARIO, pode ser mantido ou ignorado.

        [Required]
        [Column("META_ID")]
        public int MetaId { get; set; }

        [MaxLength(20)]
        [Column("STATUS")]
        public string Status { get; set; } = "Ativa";

        [Column("DATA_CONCLUSAO", TypeName = "DATE")]
        public DateTime? DataConclusao { get; set; }

        [MaxLength(255)]
        [Column("DESCRICAO_PERSONALIZADA")]
        public string DescricaoPersonalizada { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("PRAZO")]
        public string Prazo { get; set; } = "Médio";

        [ForeignKey("MetaId")]
        public Meta Meta { get; set; }
    }
}

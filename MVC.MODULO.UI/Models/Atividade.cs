using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.MODULO.UI.Models
{

    /// <summary>
    /// Propriedades da classe  (Atividade)
    /// </summary>

   [Table("atividade", Schema ="dbo")]
    public partial class Atividade
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("tarefa")]
        [Required(ErrorMessage = "O campo tarefa não pode esta vazio!", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "O campo tarefa não deve exceder {1} caracteres.")]
        public string Tarefa { get; set; }
        
        [Column("descricao")]
        [Required(ErrorMessage = "O campo descrição não pode esta vazio!", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "O campo descrição não deve exceder {1} caracteres.")]
        public string Descricao { get; set; }

        [Column("data")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "O campo data deve ser preenchido!", AllowEmptyStrings = false)]
        public DateTime? Data { get; set; }

        [Column("prioridade")]
        [Required(ErrorMessage = "O campo prioridade deve esta selecionado!")]
        public string Prioridade { get; set; }

        [Column("status")]
        public bool? Status { get; set; }

   
        public Atividade() { }

    }
}

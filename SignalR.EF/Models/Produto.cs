using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SignalR.EF.Models
{
    [Table("T_PRODUTO")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracters.")]
        [Display(Name = "Nome do produto")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Valor obrigatório")]
        [Display(Name = "Valor do produto")]
        [DataType(DataType.Currency)]
        [Range(0, 9999999999999999.99, ErrorMessage = "Valor inválido")]
        public decimal Valor { get; set; }
    }
}
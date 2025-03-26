using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class Cadastro
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Senha")]
        public string Senha { get; set; }
        [Required]        
        [DisplayName("Imagem")]
        public Image Imagem { get; set; }
        [Required]        
        [DisplayName("DataNascimento")]
        public DateTime DataNasc { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EP.CursoMvc.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ClienteId = Guid.NewGuid();
            Enderecos = new List<EnderecoViewModel>();
        }

        [Key]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string DataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public string DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public ValidationResult ValidationResult { get; set; }

        public ICollection<EnderecoViewModel> Enderecos { get; set; }
    }
}
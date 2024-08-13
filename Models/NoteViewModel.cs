using CheckBox.Core.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CheckBox.Web.Models
{
    public class NoteViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Nome")]
        [MaxLength(64)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Name { get; set; }
        [DisplayName("Conteudo da Note")]
        [MaxLength(256, ErrorMessage = "Limite ultrapassado")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Content { get; set; }
        [DisplayName("Data de criação")]
        [DisplayFormat(DataFormatString="{0:D}")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Born { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }


    }
}

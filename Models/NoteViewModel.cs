using CheckBox.Core.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CheckBox.Web.Models
{
    public class NoteViewModel
    {
        public uint Id { get; set; }
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
        public string BornFormatted => Born.ToString("dddd, dd MMMM yyyy", new CultureInfo("pt-BR"));
        public uint UserId { get; set; }
        public bool Inactive { get; set; }
        public User User { get; set; }


    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace CheckBox.Core.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Note> Notes { get; set; }

    }
}

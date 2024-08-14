using System;
using System.Collections.Generic;
using System.Text;

namespace CheckBox.Core.Entities
{
    public class Note : EntityBase
    {
        public string Name {  get; set; }
        public string Content { get; set; }
        public DateTime Born { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

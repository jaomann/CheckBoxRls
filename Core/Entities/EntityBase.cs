
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CheckBox.Core.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
    }
}

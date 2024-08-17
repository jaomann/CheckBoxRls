using System;
using System.Collections.Generic;
using System.Text;
using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Contracts.repositories;
using CheckBox.Core.Entities;

namespace CheckBox.Services
{
    public class NoteService : BaseService<Note>, INoteService
    {
        public NoteService(INoteRepository noteRepository) : base(noteRepository)
        {
        }
    }
}

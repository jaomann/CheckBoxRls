using CheckBox.Core.Contracts.repositories;
using CheckBox.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckBox.Data.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(Context context) : base(context)
        {

        }
    }
}

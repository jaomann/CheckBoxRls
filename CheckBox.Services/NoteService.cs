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
        private readonly INoteRepository _noteRepository;
        private readonly IUserService _userService;
        public NoteService(INoteRepository noteRepository, IUserService userService) : base(noteRepository)
        {
            this._noteRepository = noteRepository;
            _userService = userService;
        }
        public override void Create(Note entity)
        {
            entity.User = _userService.GetbyID(entity.UserId);
            base.Create(entity);
        }
    }
}

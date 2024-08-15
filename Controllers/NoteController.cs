﻿using AutoMapper;
using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Entities;
using CheckBox.Web.Helper;
using CheckBox.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckBox.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly IUserService _userServices;
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;
        private readonly ISession _session;
        public NoteController(IUserService userService, IMapper mapper, INoteService noteService, ISession session)
        {
            _mapper = mapper;
            _userServices = userService;
            _noteService = noteService;
            _session = session;
        }
        public IActionResult Index()
       {
            uint id = _session.FindUserSession().Id;
            var user = _mapper.Map<UserViewModel>(_userServices.GetbyID(id));
            ViewData["user"] = user;
            ViewBag.Notes = new List<NoteViewModel>();
            var notes = _mapper.Map<IEnumerable<NoteViewModel>>(_noteService.GetAll().Where(x => x.UserId == user.Id ));
            if(notes is not null)
            {
                user.Notes = _mapper.Map<IEnumerable<Note>>(notes);
                ViewBag.Notes = notes;
            }
            return View();
        }
        public IActionResult Create(uint id)
        {
            TempData["user_id"] = id;
            return View(new NoteViewModel() { UserId = id, Born = DateTime.Now});
        }
        [HttpPost]
        public IActionResult Create(NoteViewModel entity)
        {
            TempData["user_id"] = entity.UserId;
            var note = _mapper.Map<Note>(entity);
            note.Id = new uint();
            _noteService.Create(note);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(uint id, uint userid)
        {
            TempData["user_id"] = userid;
            _noteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Editar(uint id, uint userid)
        {
            TempData["user_id"] = userid;
            var note = _mapper.Map<NoteViewModel>(_noteService.GetbyID(id));
            TempData["note_id"] = note.Id;
            note.UserId = userid;
            note.Id = id;
            note.Born = DateTime.Now;
            return View(note);
        }
        [HttpPost]
        public IActionResult Editar(NoteViewModel entity, uint userid)
        {
            var note = _mapper.Map<Note>(entity);
            _noteService.Update(note);
            TempData["user_id"] = userid;
            return RedirectToAction(nameof(Index));
        }

    }
}

using AutoMapper;
using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Entities;
using CheckBox.Data;
using CheckBox.Web.Helper;
using CheckBox.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckBox.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly IUserService _userServices;
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;
        private readonly ISession _session;
        private readonly Context _context;
        public NoteController(IUserService userService, IMapper mapper, INoteService noteService, ISession session, Context context)
        {
            _mapper = mapper;
            _userServices = userService;
            _noteService = noteService;
            _session = session;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            uint id = uint.Parse(Request.Cookies["user_id"]);
            var user = _mapper.Map<UserViewModel>(await _userServices.GetbyID(id));
            ViewData["user"] = new UserViewModel(){ Id = user.Id, Name = user.Name, Surname = user.Surname };
            ViewBag.Notes = new List<NoteViewModel>();
            var notes = _mapper.Map<IEnumerable<NoteViewModel>>(_noteService.GetAll().Where(x => x.UserId == user.Id ));
            if(notes is not null)
            {
                user.Notes = _mapper.Map<IEnumerable<Note>>(notes);
                ViewBag.Notes = notes;
            }
            return View();
        }
        #region CRUD
        public IActionResult Create()
        {
            var id = uint.Parse(Request.Cookies["user_id"]);
            TempData["user_id"] = id;
            return View(new NoteViewModel() { UserId = id, Born = DateTime.Now});
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Content, Born, UserId")] NoteViewModel entity)
        {
            if(entity is not null)
            {
                var note = _mapper.Map<Note>(entity);
                await _noteService.Create(note);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(uint id)
        {
            await _noteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Editar(uint id)
        { 
            ViewData["user_id"] = uint.Parse(Request.Cookies["user_id"]);
            ViewData["note_id"] = id;
            var note = _mapper.Map<NoteViewModel>(await _noteService.GetbyID(id));
            return View(note);
        }
        [HttpPost]
        public async Task<IActionResult> Editar([Bind("Id, Name, Content, Born, UserId")] NoteViewModel entity)
        {
            if(entity is not null)
            {
                var note = _mapper.Map<Note>(entity);
                await _noteService.Update(note);
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}

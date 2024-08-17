using AutoMapper;
using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Entities;
using CheckBox.Data;
using CheckBox.Web.Helper;
using CheckBox.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
namespace CheckBox.Web.Controllers
{
    public class AuthController : Controller
    {
        private IUserService _userService { get; set; }
        private INoteService _noteService { get; set; }
        private IMapper _mapper { get; set; }
        private ISession _session { get; set; }
        private Context _context {  get; set; }
        public AuthController(ISession session,IUserService userService, IMapper mapper, INoteService noteService, Context context)
        {
            _userService = userService;
            _mapper = mapper;
            _noteService = noteService;
            _session = session;
            _context = context;
        }
        public IActionResult Index()
        {
            if(_session.FindUserSession() != null){
                return RedirectToAction("Index","Note"); 
            }
            return View();
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> Login([FromBody] UserViewModel entity)
        {
            var valid_user = await _userService.ValidateUser(_mapper.Map<User>(entity));
            if(valid_user is not null) { 
                var current_user = _mapper.Map<UserViewModel>(valid_user);
                _session.MakeSession(current_user);
                Response.Cookies.Append("user_id", current_user.Id.ToString()) ;
                return Ok();
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("api/auth/register")]
        public async Task<IActionResult> Register([FromBody] UserViewModel entity)
        {
            if(entity is not null)
            {
                if (await _userService.Exists(entity.Email))
                    return Unauthorized("Endereço de email já sendo usado");
                
                var entityUser = _mapper.Map<User>(entity);
                try
                {
                    entityUser.Password = _userService.GenerateHashCode(entity.Password);
                    _context.Set<User>().Add(entityUser);
                    await _context.SaveChangesAsync(); 
                    return Ok();
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                };
            }
            return NotFound("Formulário vazio");
        }
        [Route("api/auth/logout")]
        public IActionResult Logout()
        {
            _session.RemoveSession();
            return RedirectToAction(nameof(Index));
        }
    }
}

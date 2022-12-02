using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NoteSystemApi.Models;
using NoteSystemApi.Repositories;
using NoteSystemApi.Services;
using System.Net;

namespace NoteSystemApi.Controllers
{

    public class HomeController : Controller
    {
        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Name, model.Code);
            if (user == null)
                return NotFound(new {message = "usuario/senha incorretos"});



            var token = TokenService.GenerateToken(user);
            user.Code = "";
            return new
            {
                user,
                token
            };
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}

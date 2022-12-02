using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NoteSystemApi.Models;
using NoteSystemApi.Repositories;
using NoteSystemApi.Services;
using System.Net;
using System.Text.Json;


namespace NoteSystemApi.Controllers
{

    public class HomeController : Controller
    {

        [HttpGet]
        [Route("/users")]
        [Authorize]
        public ActionResult<dynamic> GetUsers()
        {
            UserRepository.initUsers();
            var aux = UserRepository.userList;
            return JsonSerializer.Serialize(aux);
        }


        [HttpGet]
        [Route("/results")]
        [Authorize]
        public ActionResult<dynamic> GetResults()
        {
            var aux = new List<Note>();
            foreach(var x in NoteRepository.notes)
            {
                aux.Add(new Note(x.Key, x.Value / UserRepository.userList.Count, (6033 / UserRepository.userList.Count) * x.Value / UserRepository.userList.Count));
            }

            return JsonSerializer.Serialize(aux);
        }
        [HttpPost]
        [Route("/results")]
        [Authorize]
        public ActionResult<dynamic> AddResults([FromBody]Result result)
        {
            foreach(var x in result.users)
            {
                NoteRepository.SetNote(x.Name, x.Note);
            }
            return JsonSerializer.Serialize(NoteRepository.notes);
        }



        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Name, model.Code);
            if (user == null)
                return NotFound(new {message = "usuario/senha incorretos"});



            var token = TokenService.GenerateToken(user);
            var axUser = new User(user.Name, user.Note, "");
            return new
            {
                axUser,
                token
            };
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}

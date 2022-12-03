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
        public ActionResult<dynamic> GetResults()
        {
            NoteRepository.InitNotes();
            var aux = new List<Note>();
            foreach(var x in NoteRepository.notes)
            {
               int totalUsers = UserRepository.userList.Count;
               double totalNotas = NoteRepository.notes.Sum(x => x.Value) / UserRepository.votted;
               double totalValue = 6033;
               double indvValue = 0;
               if(totalNotas > 0){
                indvValue = (x.Value / UserRepository.votted) * (totalValue /totalNotas);
               }
               
               aux.Add(new Note(x.Key, x.Value / UserRepository.votted, indvValue));
            }
            if(UserRepository.votted <= 0){
                return new List<Note>();
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
            UserRepository.votted++;
            return JsonSerializer.Serialize(NoteRepository.notes);
        }



        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Name, model.Code);
            if (user == null)
                return NotFound(new {message = "Código inexistente"});
            if(user.CodeStatus == 1){
                return NotFound(new {message = "Código já foi usado"});
            }



            var token = TokenService.GenerateToken(user);
            user.CodeStatus = 1;
            return new
            {
                user.Name,
                token
            };
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}

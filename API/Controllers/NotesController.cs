 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService service;

        public NotesController(INoteService noteService)
        {
            service = noteService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.GetAllNotes());
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.OK, service.GetAllNotes());
            }
        }

        [HttpGet]
        [Route("{NoteId}")]
        public IActionResult Get(int NoteId)
        {
            try
            {
                return Ok(service.GetNotesByID(NoteId));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public IActionResult Post([FromBody]Note note)
        {
            try
            {
                return Ok(service.CreateNotes(note));
            }
            catch (NoteAlreadyExistsException naee)
            {
                return Conflict(naee.Message);
            }
            catch(Exception n)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{NoteId}")]

        public IActionResult Delete(int NoteId)
        {
            try
            {
                return Ok(service.RemoveNotes(NoteId));
            }
            catch(NoteNotFoundException nnfe)
            {
                return NotFound(nnfe.Message);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


    }
}
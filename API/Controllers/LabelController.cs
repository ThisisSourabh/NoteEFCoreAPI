using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Exceptions;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class NotesController : ControllerBase
        {
            private readonly ILabelService service;

            public NotesController(ILabelService labelService)
            {
                service = labelService;
            }
            [HttpGet]
            public IActionResult Get()
            {
                try
                {
                    return Ok(service.GetAllLables());
                }
                catch (Exception)
                {
                    return StatusCode((int)HttpStatusCode.OK, service.GetAllLables());
                }
            }

            [HttpGet]
            [Route("{labelId}")]
            public IActionResult Get(int labelId)
            {
                try
                {
                    return Ok(service.GetLabelsByID(labelId));
                }
                catch (Exception)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }

            public IActionResult Post([FromBody]Label label)
            {
                try
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
                catch (LabelAlreadyExistException laae)
                {
                    return Conflict(laae.Message);
                }
                catch
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }

            [HttpDelete]
            [Route("{LabelId}")]

            public IActionResult Delete(int LabelId)
            {
                try
                {
                    return Ok(service.RemoveLabel(LabelId));
                }
                catch (LabelNotFoundException lnfe)
                {
                    return NotFound(lnfe.Message);
                }
                catch
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }


        }
    }
}
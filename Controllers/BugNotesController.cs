using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bugbox.Models;
using bugbox.Services;
using Microsoft.AspNetCore.Mvc;
using bugbox.Data;

namespace BugBox.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BugNotesController : ControllerBase
  {
    private readonly BugNotesServices _bn;

    // GET api/bugs


    // GET api/bugs/#
    [HttpGet("{id}")]
    public ActionResult<BugNote> Get(string id)
    {
      try
      {
        BugNote note = _bn.GetBugNotebyId(id);
        return Ok(note);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/bugs
    [HttpPost]
    public ActionResult Post([FromBody]BugNote noteData)
    {
      try
      {
        BugNote newNote = _bn.AddNote(noteData);
        return Ok(newNote);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // PUT api/bugs/5
    [HttpPut("{id}")]
    public ActionResult Put(string id, [FromBody]BugNote noteData)
    {
      try
      {
        noteData.Id = id;
        var note = _bn.EditNote(noteData);
        return Ok(note);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    public BugNotesController(BugNotesServices bn)
    {
      _bn = bn;
    }
  }
}





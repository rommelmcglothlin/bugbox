using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bugbox.Models;
using bugbox.Services;
using Microsoft.AspNetCore.Mvc;
using bugbox.Data;

namespace BugBox.Controllers //NOTE not showing 
{
  [Route("api/[controller]")]
  [ApiController]
  public class BugsController : ControllerBase
  {
    private readonly BugsServices _bs;

    // GET api/bugs
    [HttpGet]
    public ActionResult<IEnumerable<Bug>> Get()
    {
      return _bs.GetBugs();
    }

    // GET api/bugs/5
    [HttpGet("{id}")]
    public ActionResult<Bug> Get(string id)
    {
      try
      {
        Bug bug = _bs.GetBugById(id);
        return Ok(bug);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/notes")]
    public ActionResult<IEnumerable<BugNote>> GetNotes(string id)
    {
      try
      {
        var allNotes = _bs.GetNotes(id);
        return Ok(allNotes);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    // POST api/bugs
    [HttpPost]
    public ActionResult Post([FromBody] Bug bugData)
    {
      try
      {
        Bug newBug = _bs.AddBug(bugData);
        return Ok(newBug);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // PUT api/bugs/5
    [HttpPut("{id}")]
    public ActionResult Put(string id, [FromBody] Bug bugData)
    {
      try
      {
        bugData.Id = id;
        var bug = _bs.EditBug(bugData);
        return Ok(bug);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // DELETE api/bugs/5
    [HttpDelete("{id}")]
    public ActionResult<Bug> CompleteTicket(string id)
    {
      try
      {
        Bug bug = _bs.CompleteTicket(id);
        return Ok(bug);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    public BugsController(BugsServices bs)
    {
      _bs = bs;
    }
  }
}




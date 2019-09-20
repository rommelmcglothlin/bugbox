using System;
using System.Collections.Generic;
using bugbox.Data;
using bugbox.Models;

namespace bugbox.Services
{
  public class BugsServices
  {
    private readonly FakeDb _repo;

    public Bug AddBug(Bug bugData)
    {
      bugData.Id = Guid.NewGuid().ToString();
      _repo.Bugs.Add(bugData);
      bugData.ReportedDate = DateTime.Now;
      bugData.LastModified = DateTime.Now;
      return bugData;
    }

    public Bug GetBugById(string id)
    {
      var bug = _repo.Bugs.Find(b => b.Id == id);
      if (bug == null)
      {
        throw new Exception("Not a valid ID");
      }
      return bug;
    }

    public Bug EditBug(Bug bugData)
    {
      var bug = GetBugById(bugData.Id);
      if (bug.ClosedTicket == true)
      {
        throw new Exception("You can't modify resolved tickets.");
      }

      bug.Title = bugData.Title;
      bug.Description = bugData.Description;
      bug.LastModified = DateTime.Now;
      return bug;

    }
    internal Bug CompleteTicket(string id)
    {
      var bug = GetBugById(id);
      if (bug.ClosedTicket)
      {
        throw new Exception("Ticket has already been resolved");
      }
      bug.ClosedTicket = true;
      bug.ClosedDate = DateTime.Now;
      return bug;
    }
    public List<Bug> GetBugs()
    {
      return _repo.Bugs;
    }

    public List<BugNote> GetNotes(string id)
    {
      Bug bug = _repo.Bugs.Find(b => b.Id == id);
      if (bug == null)
      {
        throw new Exception("Not a valid ID");
      }
      return _repo.BugNotes.FindAll(n => n.BugId == id);
    }

    public BugsServices(FakeDb repo)
    {
      _repo = repo;
    }

  }
}
using System;
using System.Collections.Generic;
using bugbox.Data;
using bugbox.Models;

namespace bugbox.Services
{
  public class BugNotesServices
  {
    private readonly FakeDb _repo;
    private readonly BugsServices _bs;

    public BugNote AddNote(BugNote noteData)
    {
      Bug bug = _repo.Bugs.Find(b => b.Id == noteData.BugId);
      if (bug == null)
      {
        throw new Exception("Can't find that ticket");
      }

      if (bug.ClosedTicket)
      {
        throw new Exception("You can't add notes to resolved tickets");
      }
      noteData.Timestamp = DateTime.Now;
      noteData.Id = Guid.NewGuid().ToString();
      _repo.BugNotes.Add(noteData);
      return noteData;
    }
    public BugNote GetBugNotebyId(string id)
    {
      var bugNote = _repo.BugNotes.Find(n => n.Id == id);
      if (bugNote == null)
      {
        throw new Exception("That's not a valid Id");
      }
      return bugNote;
    }

    public BugNote EditNote(BugNote noteData)
    {
      var bugNote = GetBugNotebyId(noteData.Id);
      if (bugNote.ClosedTicket == true)
      {
        throw new Exception("You can't add notes to resolved tickets");
      }
      bugNote.Body = noteData.Body;
      bugNote.Timestamp = DateTime.Now;
      return bugNote;
    }

    public BugNotesServices(FakeDb repo)
    {
      _repo = repo;
    }


  }
}
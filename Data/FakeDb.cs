using System.Collections.Generic;
using bugbox.Models;

namespace bugbox.Data
{
  public class FakeDb
  {
    public List<Bug> Bugs { get; set; } = new List<Bug>();
    public List<BugNote> BugNotes { get; set; } = new List<BugNote>();
  }
}
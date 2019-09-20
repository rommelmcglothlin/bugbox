using System;

namespace bugbox.Interfaces
{
  public interface IBugNote
  {
    string Id { get; set; }
    string BugId { get; set; }
    string Body { get; set; }
    bool ClosedTicket { get; set; }
    DateTime Timestamp { get; set; }
  }
}
using System;
using bugbox.Interfaces;

namespace bugbox.Models
{
  public class BugNote : IBugNote
  {
    public string Id { get; set; }
    public string BugId { get; set; }
    public string Body { get; set; }
    public bool ClosedTicket { get; set; }
    public DateTime Timestamp { get; set; }
  }
}
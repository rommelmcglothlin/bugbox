using System;

namespace bugbox.Interfaces
{
  public interface IBug
  {
    string Id { get; set; }
    string Title { get; set; }
    string Description { get; set; }
    bool ClosedTicket { get; set; }
    DateTime ReportedDate { get; set; }
    DateTime? LastModified { get; set; }
    DateTime? ClosedDate { get; set; }
  }
}




using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using bugbox.Interfaces;

namespace bugbox.Models
{
  public class Bug : IBug
  {
    public string Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public bool ClosedTicket { get; set; }
    public DateTime ReportedDate { get; set; }
    public DateTime? LastModified { get; set; }
    public DateTime? ClosedDate { get; set; }
  }
}

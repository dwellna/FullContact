using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class Organization
  {
    [DataMember(Name = "isPrimary")]
    public bool IsPrimary { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "startDate")]
    public string StartDate { get; set; }

    [DataMember(Name = "endDate")]
    public string EndDate { get; set; }

    [DataMember(Name = "title")]
    public string Title { get; set; }

    [DataMember(Name = "current")]
    public bool Current { get; set; }
  }
}

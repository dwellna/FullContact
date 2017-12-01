using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class Website
  {
    [DataMember(Name = "url")]
    public string Url { get; set; }
  }
}

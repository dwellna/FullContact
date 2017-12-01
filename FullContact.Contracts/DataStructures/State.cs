using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class State
  {
    [DataMember(Name = "deduced")]
    public bool Deduced { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "code")]
    public string Code { get; set; }
  }
}

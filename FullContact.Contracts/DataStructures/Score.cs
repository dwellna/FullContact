using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class Score
  {
    [DataMember(Name = "provider")]
    public string Provider { get; set; }

    [DataMember(Name = "type")]
    public string Type { get; set; }

    [DataMember(Name = "value")]
    public int Value { get; set; }
  }
}

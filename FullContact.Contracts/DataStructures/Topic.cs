using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class Topic
  {
    [DataMember(Name = "value")]
    public string Value { get; set; }

    [DataMember(Name = "provider")]
    public string Provider { get; set; }
  }
}

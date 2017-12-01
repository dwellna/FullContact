using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class Continent
  {
    [DataMember(Name = "deduced")]
    public bool Deduced { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }
  }
}

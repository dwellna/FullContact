using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class DigitalFootprint
  {
    [DataMember(Name = "topics")]
    public IEnumerable<Topic> Topics { get; set; }

    [DataMember(Name = "scores")]
    public IEnumerable<Score> Scores { get; set; }
  }
}

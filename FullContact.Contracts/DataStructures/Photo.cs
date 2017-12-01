using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class Photo
  {
    [DataMember(Name = "")]
    public string Url { get; set; }

    [DataMember(Name = "")]
    public string TypeId { get; set; }

    [DataMember(Name = "")]
    public string TypeName { get; set; }
  }
}

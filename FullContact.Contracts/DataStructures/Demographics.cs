using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class Demographics
  {
    [DataMember(Name = "locationGeneral")]
    public string LocationGeneral { get; set; }

    [DataMember(Name = "locationDeduced")]
    public Location LocationDeduced { get; set; }

    [DataMember(Name = "age")]
    public int Age { get; set; }

    [DataMember(Name = "gender")]
    public string Gender { get; set; }

    [DataMember(Name = "ageRange")]
    public string AgeRange { get; set; }
  }
}

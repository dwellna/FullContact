using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class Location
  {
    [DataMember(Name = "normalizedLocation")]
    public string NormalizedLocation { get; set; }

    [DataMember(Name = "deducedLocation")]
    public string DeducedLocation { get; set; }

    [DataMember(Name = "city")]
    public City City { get; set; }

    [DataMember(Name = "state")]
    public State State { get; set; }

    [DataMember(Name = "country")]
    public Country Country { get; set; }

    [DataMember(Name = "continent")]
    public Continent Continent { get; set; }

    [DataMember(Name = "county")]
    public County County { get; set; }

    [DataMember(Name = "likelihood")]
    public double Likelihood { get; set; }
  }
}

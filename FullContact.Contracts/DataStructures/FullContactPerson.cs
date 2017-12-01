using FullContact.Contracts.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class FullContactPerson
  {
    [DataMember(Name = "status")]
    public int Status { get; set; }

    [DataMember(Name = "likelihood")]
    public double Likelihood { get; set; }

    [DataMember(Name = "requestId")]
    public Guid RequestId { get; set; }

    [DataMember(Name = "contactInfo")]
    public ContactInformation ContactInfo { get; set; }

    [DataMember(Name = "demographics")]
    public Demographics DemoGraphics { get; set; }

    [DataMember(Name = "socialProfiles")]
    public IEnumerable<SocialProfile> SocialProfiles { get; set; }

    [DataMember(Name = "organizations")]
    public IEnumerable<Organization> Organizations { get; set; }

    [DataMember(Name = "digitalFootprint")]
    public DigitalFootprint DigitalFootprint { get; set; }

    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.AppendLine(this.PrintProperty(() => Likelihood));
      stringBuilder.AppendLine(this.PrintProperty(() => ContactInfo));
      stringBuilder.AppendLine(this.PrintProperty(() => SocialProfiles));

      return stringBuilder.ToString();
    }
  }
}

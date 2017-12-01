using FullContact.Contracts.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class ContactInformation
  {
    [DataMember(Name = "familyName")]
    public string FamilyName { get; set; }

    [DataMember(Name = "givenName")]
    public string GivenName { get; set; }

    [DataMember(Name = "fullName")]
    public string FullName { get; set; }

    [DataMember(Name = "websites")]
    IEnumerable<Website> WebSites { get; set; }

    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.AppendLine(this.PrintProperty(() => FamilyName));
      stringBuilder.AppendLine(this.PrintProperty(() => GivenName));
      stringBuilder.AppendLine(this.PrintProperty(() => FullName));
      stringBuilder.AppendLine(this.PrintProperty(() => WebSites));

      return $"{Environment.NewLine}{stringBuilder}";
    }
  }
}

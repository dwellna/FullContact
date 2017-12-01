using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FullContact.Contracts.DataStructures
{
  [DataContract]
  public class SocialProfile
  {
    [DataMember(Name = "typeId")]
    public string TypeId { get; set; }

    [DataMember(Name = "typeName")]
    public string TypeName { get; set; }

    [DataMember(Name = "url")]
    public string Url { get; set; }

    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "userName")]
    public string UserName { get; set; }

    [DataMember(Name = "bio")]
    public string Bio { get; set; }

    [DataMember(Name = "followers")]
    public int Followers { get; set; }

    [DataMember(Name = "following")]
    public int Following { get; set; }

    [DataMember(Name = "rss")]
    public string Rss { get; set; }
  }
}

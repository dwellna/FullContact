using FullContact.Contracts;
using FullContact.Contracts.DataStructures;
using System;
using System.Composition;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Api
{
  /// <summary>
  /// This class implements the IFullContactApi interface and provides the functionality to use the full contact api
  /// to query person information by their email address.
  /// </summary>
  [Export(typeof(IFullContactApi))]
  public class FullContactApi : IFullContactApi
  {
    #region Constants
    /// <summary>
    /// The api key for authentication.
    /// </summary>
    private const string API_KEY = "8cb2f80eb7222e6f";

    /// <summary>
    /// The header name to be used with the api key.
    /// </summary>
    private const string API_KEY_HEADER_NAME = "X-FullContact-APIKey";

    /// <summary>
    /// The api root url.
    /// </summary>
    private const string API_ROOT = "https://api.fullcontact.com/v2/person";

    /// <summary>
    /// The person request specific url suffix.
    /// </summary>
    private const string API_REQUEST = ".json?email=";
    #endregion

    #region Private Variables
    /// <summary>
    /// The http client to be used.
    /// </summary>
    private HttpClient _client = new HttpClient() { BaseAddress = new Uri(API_ROOT) };
    #endregion

    #region Public Methods
    /// <summary>
    /// Uses the FullContact REST service to look up the specified email address.
    /// </summary>
    /// <param name="email">The email address of the person to be looked up.</param>
    /// <returns>A new instance of the FullContactPerson class, repesenting the persons profile.</returns>
    public async Task<FullContactPerson> LookupPersonByEmailAsync(string email)
    {
      _client.DefaultRequestHeaders.Add(API_KEY_HEADER_NAME, API_KEY);

      HttpResponseMessage response = await _client.GetAsync($"{API_ROOT}{API_REQUEST}{email}");
      response.EnsureSuccessStatusCode();
      return DeserializeResponse(await response.Content.ReadAsStringAsync());
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Deserialises the http response string, assuming its format to be json serialized.
    /// </summary>
    /// <param name="response">The http response in json format.</param>
    /// <returns>A new instance of the FullContactPerson class filled with data from the http response.</returns>
    private FullContactPerson DeserializeResponse(string response)
    {
      var serializer = new DataContractJsonSerializer(typeof(FullContactPerson));
      var stream = new MemoryStream(Encoding.UTF8.GetBytes(response));
      return serializer.ReadObject(stream) as FullContactPerson;
    }
    #endregion
  }
}

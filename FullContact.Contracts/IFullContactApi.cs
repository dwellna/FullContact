using FullContact.Contracts.DataStructures;
using System.Threading.Tasks;

namespace FullContact.Contracts
{
  /// <summary>
  /// Defines a behavior which allows querying a personal profile using the persons email address.
  /// </summary>
  public interface IFullContactApi
  {
    /// <summary>
    /// Looks up the specified email address and returns the related persons profile.
    /// </summary>
    /// <param name="email">The email address of the person to be looked up.</param>
    /// <returns>A new instance of the FullContactPerson class, repesenting the persons profile.</returns>
    Task<FullContactPerson> LookupPersonByEmailAsync(string email);
  }
}

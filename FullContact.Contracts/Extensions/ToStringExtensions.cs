using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FullContact.Contracts.Extensions
{
  /// <summary>
  /// This class contains some extension methods to create human readable strings from any object.
  /// </summary>
  public static class ToStringExtensions
  {
    /// <summary>
    /// Prints the specified property on the current object.
    /// </summary>
    /// <typeparam name="TValue">The type of object for which the specified property shall be printed.</typeparam>
    /// <typeparam name="TProperty">The property type.</typeparam>
    /// <param name="value">The object instance for which the specified property shall be printed.</param>
    /// <param name="propertyExpression">The expression identifying the property to be printed.</param>
    /// <returns>A string representation of the specified property and its value.</returns>
    public static string PrintProperty<TValue, TProperty>(this TValue value, Expression<Func<TProperty>> propertyExpression) where TValue : class
    {
      if (propertyExpression == null)
        throw new ArgumentNullException(nameof(propertyExpression));

      var memberExpression = propertyExpression.Body as MemberExpression;
      if (memberExpression == null)
        throw new ArgumentException("The provided expression is not a member access expression!", nameof(propertyExpression));

      var property = memberExpression.Member as PropertyInfo;
      if (property == null)
        throw new ArgumentException("The provided expression is not a property expression!", nameof(propertyExpression));

      var propertyName = memberExpression.Member.Name;
      var propertyValue = propertyExpression.Compile().Invoke();

      if (propertyValue is IEnumerable && propertyValue is string == false)
      {
        var result = $"{propertyName}:{Environment.NewLine}";
        var collectionValue = ((IEnumerable)propertyValue).OfType<object>();
        result += string.Join(Environment.NewLine, collectionValue.Select(v => v.PrintAllProperties()));
        return $"{result}{Environment.NewLine}";
      }

      return $"{propertyName}: {propertyValue}";
    }

    /// <summary>
    /// Prints all properties of the given object.
    /// </summary>
    /// <param name="value">The object instance to be used for printing.</param>
    /// <returns>A string listing all properties of the given object instance including théir values.</returns>
    public static string PrintAllProperties(this object value)
    {
      var properties = value.GetType().GetTypeInfo().GetProperties();
      var result = string.Join(Environment.NewLine, properties.Select(p => $"{p.Name}: {p.GetValue(value)}"));
      return $"{result}{Environment.NewLine}";
    }
  }
}

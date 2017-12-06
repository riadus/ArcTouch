using System;
namespace IMDB.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterInterfaceAsLazySingletonAttribute : Attribute
    {
    }
}

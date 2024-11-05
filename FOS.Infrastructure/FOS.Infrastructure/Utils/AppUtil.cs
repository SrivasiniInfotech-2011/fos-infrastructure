using System.Runtime.CompilerServices;

namespace FOS.Infrastructure.Services.Utils;

/// <summary>Common helper methods</summary>
public static class AppUtil
{
    /// <summary>Returns the name of the caller</summary>
    /// <param name="methodName">Caller method name</param>
    /// <returns><see cref="string"/></returns>
    public static string GetCurrentMethodName([CallerMemberName] string methodName = "") => methodName;
}
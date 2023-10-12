using System.Runtime.CompilerServices;

namespace VasaCSharp.Random.Utilities;

public static class Caller
{
    // Using UnsafeAccessor to access EndMessage private method in .net 8 
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "EndMessage")]
    public static extern string GetMethod(RandomPasswordGenerator randomPasswordGenerator);
}
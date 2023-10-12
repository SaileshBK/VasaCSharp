using System.Runtime.CompilerServices;

namespace VasaCSharp.Random.Utilities;

public static class Accessor
{
    // Using UnsafeAccessor to access EndMessage private method in .net 8 
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "EndMessage")]
    public static extern string GetEndMessageMethod(RandomPasswordGenerator randomPasswordGenerator);
}
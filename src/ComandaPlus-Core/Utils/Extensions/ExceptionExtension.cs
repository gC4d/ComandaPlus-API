namespace ComandaPlus_Core.Utils.Extensions;

public static class ExceptionExtension
{
    public static void When<T>(this T exception, bool hasError, string errorMessage) where T : Exception
    {
        if (hasError)
            throw (T)Activator.CreateInstance(typeof(T), errorMessage)!;
    }
}

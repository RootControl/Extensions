using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Extensions;

public static class DictionaryExtension
{
    public static TValue? GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        where TKey : notnull
    {
        ref var referenceValue = ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, key, out bool exists);

        if (exists)
            return referenceValue;
        
        referenceValue = value;
        return value;
    }
    
    public static bool TryUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        where TKey : notnull
    {
        ref var referenceValue = ref CollectionsMarshal.GetValueRefOrNullRef(dictionary, key);

        if (Unsafe.IsNullRef(ref referenceValue))
            return false;
        
        referenceValue = value;
        return true;
    }
}
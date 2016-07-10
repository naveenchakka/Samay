using System;
using System.Web;


public static class ProxyCache
{
    private static object getObject(string keyName)
    {
        // verify key in cache
        if (HttpContext.Current.Cache[keyName] == null) return null;

        // get object from cache
        return HttpContext.Current.Cache[keyName];
    }

    /// <summary>
    /// Get Cache Object
    /// </summary>
    /// <typeparam name="T">Return Object Type</typeparam>
    /// <param name="keyName">Cache Key Name</param>
    /// <param name="fun">Callback Function</param>
    /// <returns>Object T</returns>
    public static T Get<T>(string keyName, Func<object> fun)
    {
        // get cache object
        var obj = ProxyCache.getObject(keyName);
        if (obj != null) return (T)obj;

        // call function
        obj = fun();

        // set cache
        HttpContext.Current.Cache[keyName] = obj;
        return (T)obj;
    }

    /// <summary>
    /// Reset Cache
    /// </summary>
    /// <param name="keyName">Cache Key Name</param>
    public static void Reset(string keyName)
    {
        if (HttpContext.Current.Cache[keyName] != null)
        {
            HttpContext.Current.Cache.Remove(keyName);
        }
    }

    public static void ResetAll()
    {
        var item = HttpContext.Current.Cache.GetEnumerator();
        while (item.MoveNext())
        {
            HttpContext.Current.Cache.Remove(item.Key.ToString());
        }
    }
}


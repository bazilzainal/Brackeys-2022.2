using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;
    protected bool applicationIsQuitting;

    public virtual void OnDestroy()
    {
        applicationIsQuitting = true;
    }

    public virtual void OnApplicationQuit()
    {
        applicationIsQuitting = true;
    }

    protected virtual void Awake()
    {
        InitSingleton();
    }

    public static bool InitSingleton()
    {
        if (instance == null)
        {
            var objects = FindObjectsOfType<T>();
            if (objects.Length > 1)
            {
                throw new Exception("More than one singleton: " + typeof(T).Name);
            }
            else if (objects.Length == 0)
            {
                return false;
            }
            else
            {
                instance = objects[0];
            }
        }
        return true;
    }

    public static void EnsureExists()
    {
        var objects = FindObjectsOfType<T>();
        if (objects.Length == 0)
        {
            GameObject singleton = new GameObject { name = "(singleton) " + typeof(T) };
            instance = singleton.AddComponent<T>();
        }
    }
}
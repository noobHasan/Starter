using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Singleton<T> : MonoBehaviour where T : Component
{

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject g = new GameObject(typeof(T).ToString());
                    instance = g.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad (gameObject);
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}

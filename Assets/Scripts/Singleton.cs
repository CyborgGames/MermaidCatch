﻿using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;
    public bool _persist;

    /// <summary>
    /// Returns the instance of this singleton.
    /// </summary>
    /// <value>The instance.</value>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));

                if (_instance == null)
                {
                    GameObject g = new GameObject();
                    g.name = typeof(T).Name;
                    g.AddComponent<T>();

                    _instance = g.GetComponent<T>();

                    if (Instance == null)
                        Debug.LogError("Something is severely wrong when trying to use " + typeof(T) +
                            " as a singleton. Please check the class for what might be wrong.");
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        _instance = GetComponent<T>();

        if (_persist)
            DontDestroyOnLoad(this);
    }

}

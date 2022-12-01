using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMono<T> : MonoBehaviour where
     T : Component
{
    public static T Instance { get; set; }

    protected virtual void Awake()
    {
        Instance = this as T;
    }
}

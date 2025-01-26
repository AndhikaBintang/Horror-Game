using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSoundManager : MonoBehaviour
{
    private static BackSoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}

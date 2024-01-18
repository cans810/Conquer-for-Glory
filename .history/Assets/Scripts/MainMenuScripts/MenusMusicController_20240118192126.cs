using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusMusicController : MonoBehaviour
{
    public static MenusMusicController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}

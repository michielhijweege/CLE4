using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Donotdestroy : MonoBehaviour
{
    static Donotdestroy instance = null;
    // Use this for initialization

    private void Awake()
    {
        if (instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
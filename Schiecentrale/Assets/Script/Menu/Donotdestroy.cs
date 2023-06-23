using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Donotdestroy : MonoBehaviour
{
    static Donotdestroy instance = null;

    // zorg er voor dat dit game object niet vernietigt word tussen scenes en als deze bestaat verwijder die dan
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
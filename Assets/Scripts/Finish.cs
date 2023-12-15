using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField]float loadDelay = 0.5f;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player"){
            Invoke("ReloadScene", loadDelay);
        }
    }
    void ReloadScene() 
    {
        SceneManager.LoadScene(0);
    }
}
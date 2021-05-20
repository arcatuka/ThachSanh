using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spike : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Spike"))
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
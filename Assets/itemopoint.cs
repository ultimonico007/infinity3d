using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class itemopoint : MonoBehaviour
{
    private AudioSource audioSource;
    private bool collected = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (collected) return; 
        if (other.CompareTag("Player"))
        {
            collected = true;
            ScoreManager.instance.AddPoint();

            
            audioSource.Play();
            GetComponent<Collider>().enabled = false; 
            GetComponent<MeshRenderer>().enabled = false; 

            Destroy(gameObject, audioSource.clip.length); 
        }
    }
}

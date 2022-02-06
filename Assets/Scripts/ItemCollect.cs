using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class ItemCollect : MonoBehaviour
{
    GameObject gameLoseUI;
    bool gameIsOver;
    public AudioSource collectSound;




    private void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        ScoringSystem.theScore += 50;
        Destroy(gameObject);
        
    }


}



    
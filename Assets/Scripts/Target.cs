using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] int pointValue;
    [Header("Audio")]
    [SerializeField] AudioSource damageAudio;

    
    public void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Bullet")) // ensures object colliding is a player
        {
            playerInputHandler.IncrementPoint(pointValue);

            damageAudio.Play();

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void SetPlayerInputHandler(PlayerInputHandler playerInputHandler)
    {
        this.playerInputHandler = playerInputHandler;
    }

    public void SetDamageAudio(AudioSource audio)
    {
        damageAudio = audio;
    }
}

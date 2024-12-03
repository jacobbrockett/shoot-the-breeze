using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] int pointValue;
    [SerializeField] int ammoValue;
    [Header("Audio")]
    [SerializeField] AudioSource damageAudio;

    
    public void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Bullet")) // ensures object colliding is a player
        {
            if (this.CompareTag("Target"))
            {
                playerInputHandler.IncrementPoint(pointValue);
            }
            else if(this.CompareTag("Ammo"))
            {
                playerInputHandler.AddAmmo(ammoValue);
            }
            else if(this.CompareTag("Health"))
            {
                playerInputHandler.IncrementHealth();
            }
            

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

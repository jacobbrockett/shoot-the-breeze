using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] PlayerInputHandler playerInputHandler;
    [Header("Audio")]
    [SerializeField] AudioSource damageAudio;
    public void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Enemy")) // ensures object colliding is a bullet
        {
            playerInputHandler.DecrementHealth();

            damageAudio.Play();

            Destroy(other.gameObject);
        }
    }
}

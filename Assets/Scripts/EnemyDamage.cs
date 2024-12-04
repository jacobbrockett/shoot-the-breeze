using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] PlayerInputHandler playerInputHandler;
    public void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Enemy")) // ensures object colliding is a bullet
        {
            playerInputHandler.DecrementHealth();

            Destroy(other.gameObject);
        }
    }
}

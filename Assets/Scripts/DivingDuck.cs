using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingDuck : MonoBehaviour
{
    [SerializeField] GameObject baseObject;
    public void OnTriggerExit2D(Collider2D other){

        if (other.CompareTag("Bullet")) // ensures object colliding is a bullet
        {
            if (this.CompareTag("Diver"))
            {
                Debug.Log("Miss!");
            }
        }
    }
}

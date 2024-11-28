using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using UnityEngine.SceneManagement;


/**
* class: PlayerInputHandler
* description: Class is responsible for handling player inputs, tracking points, and passing the coin
* audio source to Point objects
*/
public class PlayerInputHandler : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] Player player;

    [Header("Points")]
    [SerializeField] int currentPoints = 0;
    [Header("Health")]
    [SerializeField] int currentHealth = 5;
    [SerializeField] int maxHealth = 5;

    /**
    * function: FixedUpdate()
    * args: None
    * description: Grabs player input and moves the spaceship accordingly
    */
    void FixedUpdate(){
        // Initialize Vector3:
        Vector3 movement = Vector3.zero;

        // Move Left:
        if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(-1, 0, 0);
        }

        // Move Right:
        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(1, 0, 0);
        }

    }

    public void Update()
    {
        // Fire Weapon:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.GetProjectileLauncher().Launch();
        }

        player.AimGun(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }


    /**
    * function: IncrementPoint()
    * args: None
    * description: Increments the current points field and plays the coin audio source
    */
    public void IncrementPoint(int addPoints)
    {
        currentPoints = currentPoints + addPoints;
    }

    public void DecrementHealth()
    {
        currentHealth = currentHealth - 1;
    }

    public void IncrementHealth()
    {
        if (currentHealth == maxHealth)
        {
            return;
        }
        else
        {
            currentHealth = currentHealth + 1;
        }
    }


    /**
    * function: GetCurrentPoints()
    * args: None
    * description: Getter for current points field
    */
    public int GetCurrentPoints()
    {
        return currentPoints;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }


    
}

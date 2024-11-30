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

    [Header("Ammo")]
    [SerializeField] int currentAmmo;
    [SerializeField] int availableAmmo;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource; // or GetComponent<AudioSource>()
    [SerializeField] AudioClip audioClip;

    
    public void Update()
    {
        // Fire Weapon:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentAmmo > 0)
            {
                player.GetProjectileLauncher().Launch();
                DecrementAmmo();
            }
        }

        // TODO: Reload Weapon:

        // Aim Weapon to where cursor is:
        player.AimGun(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }


    // -------
    // Points:
    // -------
    public void IncrementPoint(int addPoints)
    {
        currentPoints = currentPoints + addPoints;
    }

    public int GetCurrentPoints()
    {
        return currentPoints;
    }

    // -------
    // Health:
    // -------
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

    public void DecrementHealth()
    {
        currentHealth = currentHealth - 1;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    // -----
    // Ammo:
    // -----
    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public int GetAvailableAmmo()
    {
        return availableAmmo;
    }

    public void DecrementAmmo()
    {
        if(currentAmmo > 0)
        {
            currentAmmo = currentAmmo - 1;
        }
    }
    
}

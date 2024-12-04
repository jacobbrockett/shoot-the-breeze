using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using UnityEngine.SceneManagement;

// Must Include:
using UnityEngine.UI;
using TMPro;


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
    [SerializeField] int currentAmmo = 5;
    [SerializeField] int maxAmmo = 5;
    [SerializeField] int availableAmmo = 10;
    [SerializeField] float reloadTime = 2f;

    [Header("Audio")]
    [SerializeField] AudioSource gunshot;
    [SerializeField] AudioSource gunReload;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI reloadText;
    
    public void Update()
    {
        // Fire Weapon:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentAmmo > 0 && currentlyReloading == false)
            {
                if(player.GetProjectileLauncher().Launch() != null)
                {
                    DecrementAmmo();
                    gunshot.Play();
                }
            }
        }

        // Reload Weapon:
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

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

    public void AddAmmo(int amount)
    {
        availableAmmo = availableAmmo + amount;
    }

    bool currentlyReloading = false;
    public void Reload()
    {
        if (currentlyReloading){
            return;
        }
        if (currentAmmo == maxAmmo)
        {
            return;
        }
        if (availableAmmo <= 0)
        {
            return;
        }

        currentlyReloading = true;
        StartCoroutine(ReloadRoutine());
        gunReload.Play();
        reloadText.text = "Reloading...";

        IEnumerator ReloadRoutine()
        {
            Debug.Log("Reload routine active!");

            yield return new WaitForSeconds(reloadTime);

            int ammoNeeded = maxAmmo - currentAmmo;

            if (ammoNeeded <= availableAmmo) // Enough available ammo for a full reload
            {
                Debug.Log("Full Reload");
                currentAmmo += ammoNeeded; // Reload to max
                availableAmmo -= ammoNeeded; // Reduce available ammo
            }
            else // Not enough available ammo for a full reload
            {
                Debug.Log("Partial Reload");
                currentAmmo += availableAmmo; // Add whatever is left to current ammo
                availableAmmo = 0; // No ammo left
            }

            currentlyReloading = false;
            reloadText.text = "";
            Debug.Log("Reload routine done!");
        }
    }
    
}

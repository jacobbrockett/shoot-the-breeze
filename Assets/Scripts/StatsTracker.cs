using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Must Include:
using UnityEngine.UI;
using TMPro;

public class StatsTracker : MonoBehaviour
{
    [SerializeField] PlayerInputHandler playerInputHandler; // always connected to what player is controlling

    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI ammoText;

    /**
    * function: Update()
    * args: none
    * description: Update the point counter text with current points
    */
    public void Update()
    {
        // Update Points:
        int currentPoints = playerInputHandler.GetCurrentPoints();
        pointText.text = "Points: " + currentPoints.ToString();

        // Update Health:
        int currentHealth = playerInputHandler.GetCurrentHealth();
        int maxHealth = playerInputHandler.GetMaxHealth();

        healthText.text = "Health: " + currentHealth.ToString() + "/" + maxHealth.ToString();

        // Update Ammo:
        int currentAmmo = playerInputHandler.GetCurrentAmmo();
        int availableAmmo = playerInputHandler.GetAvailableAmmo();

        ammoText.text = "Ammo: " + currentAmmo.ToString() + "/" + availableAmmo.ToString();
        
    }
}

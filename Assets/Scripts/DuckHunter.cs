using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Must Include:
using UnityEngine.UI;
using TMPro;

public class DuckHunter : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] TargetLauncher targetLauncher;
    [SerializeField] PlayerInputHandler playerInputHandler;
    [Header("Text")]
    [SerializeField] TextMeshProUGUI levelText;

    bool hasAmmo = true;

    public void Start()
    {
        levelText.text = "";
        // Start Launching Targets:
        targetLauncher.StartTargets();
    }
    public void Update()
    {
        // Check if out of ammo:
        if (hasAmmo && playerInputHandler.GetAvailableAmmo() == 0 && playerInputHandler.GetCurrentAmmo() == 0)
        {
            // Stop Launching Targets:
            targetLauncher.StopTargets();
            levelText.text = "Out of Ammo!!!";
            hasAmmo = false;
        }
    }
}

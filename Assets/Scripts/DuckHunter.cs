using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Must Include:
using UnityEngine.UI;
using TMPro;

public class DuckHunter : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] TargetLauncher targetLauncher_1;
    [SerializeField] TargetLauncher targetLauncher_2;
    [SerializeField] TargetLauncher targetLauncher_3;
    [SerializeField] TargetLauncher ammoLauncher;
    [SerializeField] PlayerInputHandler playerInputHandler;
    [Header("Text")]
    [SerializeField] TextMeshProUGUI levelText;

    bool hasAmmo = true;

    public void Start()
    {
        levelText.text = "";
        // Start Launching Targets:
        targetLauncher_1.StartTargets();
        targetLauncher_2.StartTargets();
        targetLauncher_3.StartTargets();

        // Start Launching Ammo:
        ammoLauncher.StartTargets();
    }
    public void Update()
    {
        // Check if out of ammo:
        if (hasAmmo && playerInputHandler.GetAvailableAmmo() == 0 && playerInputHandler.GetCurrentAmmo() == 0)
        {
            // Stop Launching Targets:
            targetLauncher_1.StopTargets();
            levelText.text = "Out of Ammo!!!";
            hasAmmo = false;
        }
    }
}

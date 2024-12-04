using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


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
    [SerializeField] TargetLauncher healthLauncher;
    [SerializeField] PlayerInputHandler playerInputHandler;
    [Header("Text")]
    [SerializeField] TextMeshProUGUI levelText;
    [Header("Level Management")]
    [SerializeField] string nextLevel;

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

        // Start Launching Health:
        healthLauncher.StartTargets();
    }
    public void Update()
    {
        // Check if out of ammo:
        if (hasAmmo && playerInputHandler.GetAvailableAmmo() == 0 && playerInputHandler.GetCurrentAmmo() == 0)
        {
            // Stop Launching Targets:
            targetLauncher_1.StopTargets();
            targetLauncher_2.StopTargets();
            targetLauncher_3.StopTargets();

            // Stop Launching Ammo:
            ammoLauncher.StopTargets();

            // Stop Launching Health:
            healthLauncher.StopTargets();

            // Message to End Level:
            levelText.text = "Out of Ammo!!!\nPress Enter to go to next level...";
            hasAmmo = false;
        }

        if (!hasAmmo && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}

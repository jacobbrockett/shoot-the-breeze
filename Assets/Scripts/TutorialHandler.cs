using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Must Include:
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class TutorialHandler : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] TargetLauncher targetLauncher;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI tutorialText;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI ammoText;
    int tutorialIndex = 0;
    

    public void Start()
    {
        // Clear all text:
        tutorialText.text = "";
        pointsText.text = "";
        healthText.text = "";
        ammoText.text = "";

        // Set Tutorial Text to Opening Message:
        tutorialText.text = "Welcome! This tutorial will walk you through the basic elements of the game. Press enter to continue...";
    }

    public void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Return))
        {
            tutorialIndex = tutorialIndex + 1;

            switch(tutorialIndex)
            {
                case 1:
                    tutorialText.text = "At the top left of the screen, you will find your stats menu. Press enter to continue...";
                    break;
                case 2:
                    pointsText.text = "<-";
                    tutorialText.text = "For every target you successfully destroy, you gain 1 point. Press enter to continue...";
                    break;
                case 3:
                    pointsText.text = "";
                    healthText.text = "<-";
                    tutorialText.text = "Watch out for enemies! Each successful attack will remove 1 health point. Press enter to continue...";
                    break;
                case 4:
                    pointsText.text = "";
                    healthText.text = "";
                    ammoText.text = "<-";
                    tutorialText.text = "Keep a close eye on your ammunition! The left number indicates ammo currently loaded, and the right indicates how much ammo you have available to reload. Press enter to continue...";
                    break;
                case 5:
                    pointsText.text = "";
                    healthText.text = "";
                    ammoText.text = "";
                    tutorialText.text = "Now, let's try some skeet shooting! Move your cursor to aim, press space to fire, and press R to reload. Press enter to continue...";
                    targetLauncher.StartTargets();
                    break;
                case 6:
                    tutorialText.text = "All done? Then let's do some duck hunting!";
                    targetLauncher.StopTargets();
                    break;
                default:
                    // TODO: Add Fade away
                    SceneManager.LoadScene("Level_1");
                    break;
            }
        }
    }
}

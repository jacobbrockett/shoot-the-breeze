using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Must Include:
using UnityEngine.UI;
using TMPro;

public class TutorialHandler : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] TargetLauncher targetLauncher;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI tutorialText;

    // Update is called once per frame
    public void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Return))
        {
            targetLauncher.StartTargets();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            targetLauncher.StopTargets();
        }
        
    }
}

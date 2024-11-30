using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLauncher : MonoBehaviour
{
    [SerializeField] ProjectileLauncher projectileLauncher;
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] int launchInterval;

    IEnumerator LaunchTargetsCoroutine = null;

    public void StartTargets()
    {
        if (LaunchTargetsCoroutine == null)
        {
            LaunchTargetsCoroutine = LaunchTargetsRoutine();
            StartCoroutine(LaunchTargetsCoroutine);
        }
    }

    public void StopTargets()
    {
        if(LaunchTargetsCoroutine != null)
        {
            StopCoroutine(LaunchTargetsCoroutine);
            LaunchTargetsCoroutine = null;
        }
    }

    IEnumerator LaunchTargetsRoutine() // coroutine that launches skeets over a time interval
        {
            while(true)
            {
                GameObject newObject = projectileLauncher.Launch();

                if(newObject != null)
                {
                    Target newTarget = newObject.GetComponent<Target>();

                    if(newTarget != null)
                    {
                        newTarget.SetPlayerInputHandler(playerInputHandler);
                    }
                }
                yield return new WaitForSeconds(launchInterval);
            }
            
        }
}

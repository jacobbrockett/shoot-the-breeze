using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLauncher : MonoBehaviour
{
    [SerializeField] ProjectileLauncher projectileLauncher;
    [SerializeField] int launchInterval;

    // Start is called before the first frame update
    void Start()
    {
        LaunchTargets(); // coroutine that launches skeets over a time interval
    }

    void LaunchTargets()
    {
        StartCoroutine(LaunchTargetsRoutine());

        IEnumerator LaunchTargetsRoutine()
        {
            while(true)
            {
                projectileLauncher.Launch();
                yield return new WaitForSeconds(launchInterval);
            }
            
        }
    }
}

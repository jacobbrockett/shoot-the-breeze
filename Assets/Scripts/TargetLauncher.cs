using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLauncher : MonoBehaviour
{
    [SerializeField] ProjectileLauncher projectileLauncher;
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] int launchInterval;

    // Start is called before the first frame update
    public void Start()
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
}

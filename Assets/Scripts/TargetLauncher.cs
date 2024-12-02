using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLauncher : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] PlayerInputHandler playerInputHandler;
    [Header("Projectile")]
    [SerializeField] ProjectileLauncher projectileLauncher;
    [SerializeField] float launchInterval;
    [SerializeField] float minProjectileSpeed = 10.0f;
    [SerializeField] float maxProjectileSpeed = 10.0f;
    float projectileSpeed;
    [Header("Audio")]
    [SerializeField] AudioSource launchAudio;
    [SerializeField] AudioSource damageAudio;

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
                GameObject newObject;
                // Calculate Projectile Speed:
                if (minProjectileSpeed == maxProjectileSpeed)
                {
                    // Launch Object:
                    newObject = projectileLauncher.Launch();
                }
                else
                {                    
                    // Launch Object with random speed:
                    newObject = projectileLauncher.Launch(Random.Range(minProjectileSpeed, maxProjectileSpeed));
                }

                launchAudio.Play();

                if(newObject != null)
                {
                    Target newTarget = newObject.GetComponent<Target>();

                    if(newTarget != null)
                    {
                        newTarget.SetPlayerInputHandler(playerInputHandler);

                        newTarget.SetDamageAudio(damageAudio);
                    }
                }
                yield return new WaitForSeconds(launchInterval);
            }
            
        }
}

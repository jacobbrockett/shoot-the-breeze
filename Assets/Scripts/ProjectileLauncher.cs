using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float defaultProjectileSpeed = 10.0f;
    
    [Header("Prefab")]
    [SerializeField] GameObject projectilePrefab;

    [Header("Helpers")]
    [SerializeField] Transform spawnTransform;
    
    [Header("Ammo")]
    [SerializeField] float coolDownTime = 0.25f;

    [SerializeField] float ammoDuration = 2f;


    bool coolingDown = false;
    // Launch a projectile Forward
    public GameObject Launch(){

        if(coolingDown)
        {
            return null;
        }
        CoolDown();

        GameObject newProjectile = Instantiate(projectilePrefab, spawnTransform.position, Quaternion.identity); // creates new projectile

        newProjectile.GetComponent<Rigidbody2D>().velocity = transform.up * this.defaultProjectileSpeed;

        Destroy(newProjectile, ammoDuration); // destroy projectile after 30 seconds

        return newProjectile;
    }

    // Launch a projectile Forward with a given speed
    public GameObject Launch(float projectileSpeed){

        if(coolingDown)
        {
            return null;
        }
        CoolDown();

        GameObject newProjectile = Instantiate(projectilePrefab, spawnTransform.position, Quaternion.identity); // creates new projectile

        newProjectile.GetComponent<Rigidbody2D>().velocity = transform.up * projectileSpeed;

        Destroy(newProjectile, ammoDuration); // destroy projectile after 30 seconds

        return newProjectile;
    }

    void CoolDown()
    {
        coolingDown = true;

        StartCoroutine(CoolingDownRoutine());

        IEnumerator CoolingDownRoutine()
        {
            yield return new WaitForSeconds(coolDownTime);
            coolingDown = false;
        }
    }
    
}

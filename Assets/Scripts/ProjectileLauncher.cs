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
    [SerializeField] int maxAmmo = 10;
    [SerializeField] int currentAmmo = 10;
    [SerializeField] float maxReloadTime = 10f;
    [SerializeField] float coolDownTime = 0.25f;

    [SerializeField] float ammoDuration = 2f;

    float currentReloadTime = 0;

    void Awake()
    {
        currentAmmo = maxAmmo;
    }

    bool coolingDown = false;
    // Launch a projectile Forward
    public GameObject Launch(){

        if(coolingDown)
        {
            return null;
        }
        CoolDown();

        currentAmmo -= 1;

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

        currentAmmo -= 1;

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

    bool currentlyReloading = false;
    public void Reload()
    {
        if (currentlyReloading){
            return;
        }
        if (currentAmmo == maxAmmo)
        {
            return;
        }

        currentlyReloading = true;
        currentReloadTime = 0;
        StartCoroutine(ReloadRoutine());

        IEnumerator ReloadRoutine()
        {
            Debug.Log("Reload routine active!");
            // yield return new WaitForSeconds(reloadTime);

            while(currentReloadTime < maxReloadTime)
            {
                yield return null; // wait for a single frame
                currentReloadTime += Time.deltaTime;
            }

            currentReloadTime = 0;

            currentAmmo = maxAmmo;
            currentlyReloading = false;
            Debug.Log("Reload routine done!");
        }
    }

    public float GetReloadPercentage()
    {
        return currentReloadTime / maxReloadTime;
    }

    public int GetAmmo()
    {
        return currentAmmo;
    }

    public int GetMaxAmmo()
    {
        return maxAmmo;
    }

    public void SetProjectileSpeed(float projectileSpeed)
    {
        this.defaultProjectileSpeed = projectileSpeed;
    }
}

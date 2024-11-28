using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ProjectileLauncher projectileLauncher;
    [Header("Rotation")]
    [SerializeField] float rotationSpeed = 10;

    public void AimGun(Transform targetTransform)
    {
        AimGun(targetTransform.position);
    }

    public void AimGun(Vector3 aimPos)
    {
        Quaternion goalRotation = Quaternion.LookRotation(Vector3.forward, aimPos - transform.position);

        Quaternion currentRotation = transform.rotation;

        transform.rotation = Quaternion.Slerp(currentRotation, goalRotation, Time.deltaTime * rotationSpeed); // spherical interpolation
    }

    public ProjectileLauncher GetProjectileLauncher()
    {
        return projectileLauncher;
    }
}

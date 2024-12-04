using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingDuck : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int speed = 20;

    [SerializeField] int rotationSpeed = 20;

    public void Move(Vector3 movement)
    {
        // transform.localPosition += new Vector3(x*1*Time.deltaTime, y*1*Time.deltaTime, 0); // this kind of teleports the object

        rb.velocity = movement * speed;

        // rb.MovePosition(transform.position + (movement * speed) * Time.fixedDeltaTime); // add position to current position

        // rb.AddForce(movement * speed); // adds a force to spaceship, similar to thrusters

        
    }

     public void MoveToward(Vector3 goalPos) // travel towards a position
    {
        goalPos.z = 0;

        Vector3 direction = goalPos - transform.position; // face towards target

        Move(direction.normalized); // vector in same direction, of length 1
    }

    public void AimDuck(Transform targetTransform)
    {
        // transform.rotation = Quaternion.LookRotation(Vector3.forward, targetTransform.position - transform.position);

        AimDuck(targetTransform.position);

    }
    public void AimDuck(Vector3 aimPos)
    {
        Quaternion goalRotation = Quaternion.LookRotation(Vector3.forward, aimPos - transform.position);

        Quaternion currentRotation = transform.rotation;

        transform.rotation = Quaternion.Lerp(currentRotation, goalRotation, Time.deltaTime * rotationSpeed); // interpolation 

        // transform.rotation = Quaternion.Slerp(currentRotation, goalRotation, Time.deltaTime * rotationSpeed); // spherical interpolation
    }
}

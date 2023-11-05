using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAcc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform target;
    public float maxVelocity;
    public float acceleration;
    public float turnSpeed;
    public float stopDistance;
    public float turnAcceleration;
    public float maxTurnSpeed;
    public float movSpeed;
    public float maxSpeed;

    void Seek()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;
        Vector3 movement = direction.normalized * maxVelocity;
        movement = direction.normalized * acceleration;

        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);  // up = y
        rotation = Quaternion.AngleAxis(angle, Vector3.up);

        //turnSpeed += turnAcceleration * Time.deltaTime;
        //turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        movSpeed += acceleration * Time.deltaTime;
        movSpeed = Mathf.Min(movSpeed, maxSpeed);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * movSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <
            stopDistance) return;
        Seek();   // calls to this function should be reduced
        
    }
}

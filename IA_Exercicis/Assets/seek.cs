using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
public class seek : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float turnSpeed;
    void seguir()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;    // (x, z): position in the floor
        Vector3 movement = direction.normalized * speed;

        transform.position += movement * Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seguir();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek : MonoBehaviour
{
 
    public Transform target;
    public float speed;
    public float turnSpeed;
    public float stopDistance;

    void Seek()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;

        Vector3 movement = direction.normalized * speed;

        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);  // up = y

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);

        /*Dependiendo de turnSpeed la capsula girará mas rapido o lento hacia el objetivo
        Parece que esto puede servir para orientar siempre a un enemigo hacia nosotros ya que si no se hace
        el enemigo nos seguirá siempre mirando al mismo sitio, lo que hará que nos siga de espaldas, de lado, etc.

        TurnSpeed es la velocidad con la que la capsula centra al enemigo, es decir, si el valor de turnSpeed es bajo
        hará un recorrido más abierto hasta centrarse (se mueve hacia delante mientras gira), mientras que si 
        turnSpeed tiene un valor alto, hará menos recorrido y se girará más sobre si mismo (si subimos muchisimo
        valor gira sobre si mismo).*/

        //transform.position += transform.forward.normalized * speed * Time.deltaTime;
        //Esto mueve al jugador (no se exactamente el funcionamiento, solo sirve si se hace tambien una rotacion)

        transform.position += movement * Time.deltaTime;
        /*Esto mueve al jugador segun su movement (direccion * velocidad)
        util para cuando no hay rotacion o no se desea*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <
          stopDistance) return;
        Seek();
        //Si el enemigo está a más de 3 metros seguirá al jugador, si no se 
        //quedará quieto ya que la función no se ejecutará
    }
}

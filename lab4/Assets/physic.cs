using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.PlayerLoop;

public class physic : MonoBehaviour
{
    private float minVelocity = 10f;
    private Vector3 lastFrameVelocity;
    public static Boolean used = false;
    private double gravity = 0f;
    private double g = 6.674 * Math.Pow(10, -11);
    private Rigidbody actor;
    public Transform ground;
    private double groundMass = 5.972 * Math.Pow(10, 24);
    private double groundRay = 6371000;
    
    public static void setUsed(Boolean b)
    {
        used = b;
    }
    // Start is called before the first frame update
    void Start()
    {
        actor = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lastFrameVelocity = actor.velocity;
        // utilisation de la gravité
        if (used)
        {
            var fps = Time.deltaTime;
            gravity = -g * (actor.mass * groundMass) / ((groundRay + ground.position.y - actor.position.y) * (groundRay + ground.position.y - actor.position.y));
            actor.AddForce(actor.velocity.x,  (float)gravity, actor.velocity.z, ForceMode.Acceleration);
        }

       /* if (Collider.collision) // en cas de collision, on recupere le coordonnees de la sphere pour les donner en param de la fonction bounce
        {
            Bounce(Collider.contactPoint);
            Debug.Log(Collider.contactPoint);
        }*/
    }
    
  /*  private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
    }*/
  private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude * 10;
        //var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        var direction = collisionNormal;//new Vector3(lastFrameVelocity.normalized* collisionNormal);
        Debug.Log("Out Direction: " + direction);
        actor.AddForce(direction* Mathf.Max(speed, minVelocity),ForceMode.Acceleration);
    }
}

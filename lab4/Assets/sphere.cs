using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    private Vector3 lastFrameVelocity;
    private float minVelocity = 0.01f;
    public Transform fail;
    public Transform arrive;
    public Rigidbody  boule;
    public static Boolean hasGravity = false;
    public static Boolean echec = false;
    public static Boolean win = false;
    public GameObject myPrefab;
    private GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        physic.setUsed(false);
    }
    

    public static void  setGravity(Boolean b)
    {
        hasGravity = b;
    }
    public static void  setWin(Boolean b)
    {
        win = b;
    }
    public static void  setEchec(Boolean b)
    {
        echec = b;
    }
    // Update is called once per frame
   /* private void OnTriggerStay(Collider collide)
    {
        if (collide == arrive.GetComponent<Collider>())
        {
            hasGravity = false;
           // boule.velocity = Vector3.zero;
           physic.setUsed(false);
            win = true;
        }
        if (collide == fail.GetComponent<Collider>()) echec = true;
    } 
*/
    public void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "block"){
            Debug.Log("collision");
            Bounce(col.contacts[0].normal);
        }
    }
    void Update()
    {
        lastFrameVelocity = boule.velocity;
        if(boule.position.y <= 0.8)
        {
            if(boule.position.x < 1 && boule.position.x > -1){
                win = true;
                Debug.Log("win");
            } else {
                echec = true;
            }
        }
        if (hasGravity)
        {
            //boule.useGravity = true;
            physic.setUsed(true);
        }
        else
        {
            physic.setUsed(false);
        }
       
    }
     private void Bounce(Vector3 collisionNormal)
        {
            var speed = lastFrameVelocity.magnitude;
            var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
            Debug.Log("Out Direction: " + direction);
            boule.AddForce(direction* Mathf.Max(speed, minVelocity),ForceMode.Acceleration);
        }
    
}

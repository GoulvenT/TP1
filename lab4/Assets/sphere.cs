using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    public Transform fail;
    public Transform arrive;
    public Rigidbody  boule;
    public static Boolean hasGravity = false;
    public static Boolean echec = false;
    public static Boolean win = false;
    // Start is called before the first frame update
    void Start()
    {
        boule.useGravity = false;
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
    private void OnTriggerStay(Collider collide)
    {
        if (collide == arrive.GetComponent<Collider>())
        {
            hasGravity = false;
            boule.velocity = Vector3.zero;
            win = true;
        }

        if (collide == fail.GetComponent<Collider>())
        {

            echec = true ;
        }
        
    }

    void Update()
    {
        if (hasGravity)
        {
            boule.useGravity = true;
        }
    }
}

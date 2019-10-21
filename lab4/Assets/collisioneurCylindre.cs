using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisioneurCylindre : MonoBehaviour
{
    public Rigidbody actor;
    private GameObject clone;
    public GameObject col;
    // Start is called before the first frame update
    void Start()
    {
        clone = Instantiate(col, new Vector3(-3.66f, 14.09f, -1.87f), Quaternion.identity);
        clone.transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
        actor = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (col)
        {
            Debug.Log(col.transform.position);
            Debug.Log(actor.position);
            if (actor.position.x < col.transform.position.x + 0.5f && actor.position.x > col.transform.position.x - 0.5f)
            {
                if(actor.position.y - 0.25f < col.transform.position.y + 0.5f && actor.position.y + 0.25f > col.transform.position.y - 0.5f) Debug.Log("\n la collision a la main pour le cylindre \n ");   
            }
        }
       

    }
}
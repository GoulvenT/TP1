using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public Transform arrive;
    public Rigidbody actor;
    public static Boolean collision = false;
    private Transform collider;

    public static Vector3 contactPoint;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (actor.position == collider.position)
        {
            Debug.Log("la");
            collision = true;
            var contact = new Vector3(actor.position.x, actor.position.y, actor.position.z);
            contactPoint = Vector3.Cross(contact, arrive.position);
            Debug.Log(contactPoint);
        }

        collision = false;
    }
}

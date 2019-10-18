using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    public Transform theBall;
    private Renderer render;
    SpriteRenderer sr;
   /* public Transform cube;
    public Transform greenCube;
    public Transform blueCube;*/

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        if (transform.position.y > 5 - 0.25)
        {
            render.material.color = new Color(1,1,1);
        }
        if (5 - 0.25 > transform.position.y  && transform.position.y >= 3.25  - 0.25)
        {
            render.material.color = new Color(1,0,0);
        }
        if (transform.position.y < 3.25 - 0.25 && transform.position.y > 2)
        {
            render.material.color = Color.green;
        }
        if (transform.position.y < 1.75)
        {
            render.material.color = Color.blue;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class gameLoop : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public Transform boule;
    public Boolean myturn;
    private GameObject clone;
    private Rigidbody rb;
    public GameObject winThis;
    private Boolean haveToCreate = true;

    public Text winText;
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate(myPrefab, new Vector3(-1.5f, 17, -1.5f), Quaternion.identity);
    }

    private void Update()
    {
        setWinText();
        if (myturn)
        {
            

           // Debug.Log(sphere.echec);
           if (haveToCreate)
            {
                clone = Instantiate(myPrefab, new Vector3(-1.5f, 17, -1.5f), Quaternion.identity);
                haveToCreate = false;
            }

            if (Input.GetKey(KeyCode.LeftArrow) && clone.transform.position.x < 4.5f)
            {
                clone.transform.Translate(0.1f, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow) )
            {
                clone.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            if (Input.GetKey(KeyCode.RightArrow) && clone.transform.position.x > -4.5f)
            {
                clone.transform.Translate(-0.1f, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                sphere.setWin(false);
                sphere.setGravity(true);

                myturn = false;
            }
            clone.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (sphere.echec)
        {
            myturn = true;
            sphere.setGravity(false);
            Destroy(clone, 0.1f);
            haveToCreate = true;
            sphere.setEchec(false);
        }

        if (sphere.win)
        {
            sphere.setEchec(false);
            myturn = false;
        }
    }

    void setWinText()
    {
        if (sphere.win)
        {
            Instantiate(winThis, new Vector3(-1.5f, 7.5f, 0), Quaternion.identity);
        }
    }
}
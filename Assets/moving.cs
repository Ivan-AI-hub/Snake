using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {

    public GameObject Player;

    void Update () {

		if ( Input.GetKey(KeyCode.W) )
        {
            float movespeed = 0.0f;
            movespeed = movespeed + 0.1f;
            Player.transform.position += new Vector3(0,movespeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            float movespeed = 0.0f;
            movespeed = movespeed + 0.1f;
            Player.transform.position -= new Vector3(0, movespeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            float movespeed = 0.0f;
            movespeed = movespeed + 0.1f;
            Player.transform.position -= new Vector3(movespeed,0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            float movespeed = 0.0f;
            movespeed = movespeed + 0.1f;
            Player.transform.position += new Vector3(movespeed, 0);
        }

    }

}

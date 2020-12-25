using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colaider : MonoBehaviour {
    public GameObject wall;

    void OnTriggerEnter3D(Collider other)
    {
        if (other.gameObject.name == "wall")
        Debug.Log("Detected");
    }
}

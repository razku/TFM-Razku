using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentDestroy : MonoBehaviour {
    public Mesh NewMesh;

    void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshFilter>().mesh=NewMesh;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material.color = Color.black;
	}

    // Update is called once per frame
    void OnMouseEnter() => GetComponent<MeshRenderer>().material.color = Color.red;

    void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = Color.black;
    }
}

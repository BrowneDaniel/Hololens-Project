using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickFont : MonoBehaviour {

    public GameObject ColorAndSize;
    public GameObject SliderSize;
    public GameObject DropdownColor;

    // Use this for initialization
    void Start () {

        SliderSize.SetActive(false);
        DropdownColor.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        SliderSize.SetActive(true);
        DropdownColor.SetActive(true);

    }
}

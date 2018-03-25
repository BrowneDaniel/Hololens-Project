using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickLang : MonoBehaviour {

    public GameObject Language;
    public GameObject DropdownLanguage;

    // Use this for initialization
    void Start () {

        DropdownLanguage.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        DropdownLanguage.SetActive(true);

    }
}

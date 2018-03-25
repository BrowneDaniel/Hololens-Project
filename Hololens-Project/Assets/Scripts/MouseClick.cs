using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseClick : MonoBehaviour {

    public GameObject Settings;
    public GameObject Language;
    public GameObject ColorAndSize;
    public GameObject DropdownLanguage;
    public GameObject SliderSize;
    public GameObject DropdownColor;

    // Use this for initialization
    void Start () {
        Settings.SetActive(true);
        Language.SetActive(false);
        ColorAndSize.SetActive(false);
        DropdownLanguage.SetActive(false);
        SliderSize.SetActive(false);
        DropdownColor.SetActive(false);

}
	
	// Update is called once per frame
	void clickThisButton () {

        Language.SetActive(true);
        ColorAndSize.SetActive(true);

    }
}

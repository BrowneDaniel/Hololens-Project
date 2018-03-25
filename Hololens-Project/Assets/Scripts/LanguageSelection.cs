using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSelection : MonoBehaviour {

	public GameObject voiceman;
	public GameObject lang;
	public string language;
	public int val;

	public void changeLanguage()
	{
		val = lang.GetComponent<Dropdown>().value;
		switch(val)
		{
			case 0:
				language = "en";
				break;
			case 1:
				language = "fr";
				break;
			case 2:
				language = "es";
				break;
			default:
				language = "en";
				break;
		}
		voiceman.GetComponent<Voice>().translatingLanguage = language;
	}
}

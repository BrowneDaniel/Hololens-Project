using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFontSize : MonoBehaviour {

	public GameObject text;
	public GameObject slider;
	public int val;

	public void changeFont()
	{
		val = (int) slider.GetComponent<Slider>().value + 10;
		text.GetComponent<Text>().fontSize = val;
	}
}

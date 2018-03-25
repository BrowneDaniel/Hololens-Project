using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontColour : MonoBehaviour {

	public GameObject text;
	public GameObject colour;
	public int colourSelect;
	public Color m_MyColor;

	public void changeColour()
	{
		colourSelect = colour.GetComponent<Dropdown>().value;

		switch(colourSelect)
		{
			case 0:
				m_MyColor = Color.white;
				break;
			case 1:
				m_MyColor = Color.red;
				break;
			case 2:
				m_MyColor = Color.magenta;
				break;
			case 3:
				m_MyColor = Color.green;
				break;
			case 4:
				m_MyColor = Color.yellow;
				break;
			case 5:
				m_MyColor = Color.black;
				break;
			default:
				m_MyColor = Color.white;
				break;
		}

		text.GetComponent<Text>().color = m_MyColor;

	}
}

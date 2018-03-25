using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFont : MonoBehaviour {

	public GameObject text;
	public GameObject thisObject;
	int index;
	public Font normal;
	public Font readable;

	public void changeFont(){
		index = thisObject.GetComponent<Dropdown>().value;
		if(index==0)
		{
			text.GetComponent<Text>().font = normal;
		}
		else
		{
			text.GetComponent<Text>().font = readable;
		}
	}
}

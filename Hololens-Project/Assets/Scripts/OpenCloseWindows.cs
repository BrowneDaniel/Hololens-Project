using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseWindows : MonoBehaviour {
	public void setActive(){
		if(gameObject.activeSelf==true){
			gameObject.SetActive(false);
		}
		else{
			gameObject.SetActive(true);
		}
	}
}

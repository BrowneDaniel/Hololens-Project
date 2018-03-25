using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity.InputModule;
using System.Collections;

public class GetLangs : MonoBehaviour {
	public string apiKey;
	
	// Use this for initialization
	public void Start () {
		StartCoroutine(Translate());
	}

	public IEnumerator Translate(){
		string urlLang = "https://api.microsofttranslator.com/V2/Http.svc/GetLanguagesForTranslate";
		UnityWebRequest translatedLangs = UnityWebRequest.Get(urlLang);
		translatedLangs.SetRequestHeader("Ocp-Apim-Subscription-Key", apiKey);
		yield return translatedLangs.SendWebRequest();
		if (translatedLangs.isNetworkError || translatedLangs.isHttpError)
		{
				Debug.Log(translatedLangs.error);
		}
		else
		{
				string parsed = translatedLangs.downloadHandler.text;
				Debug.Log(parsed);
		}
	}
	// Update is called once per frame
	public void Update () {

	}
}

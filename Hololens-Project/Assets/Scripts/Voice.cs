using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System;

public class Voice : MonoBehaviour
{
    private DictationRecognizer m_DictationRecognizer;
    public GameObject t;
    public GameObject translatedT;
    public GameObject debug;
    public SpeechInputSource keywordRecogiser;
    public string apiKey;
    public string dictatingLanguage;
    public string translatingLanguage;

    public void Awake(){
      Dictate();
    }

    public IEnumerator Translate(string text)
    {
        string urlEncodedText = WWW.EscapeURL(text);
        string url = "https://api.microsofttranslator.com/V2/Http.svc/Translate?to=" + translatingLanguage + "&from=" + dictatingLanguage + "&text=" + urlEncodedText;
        UnityWebRequest translate = UnityWebRequest.Get(url);
        translate.SetRequestHeader("Ocp-Apim-Subscription-Key", apiKey);
        yield return translate.SendWebRequest();
        if (translate.isNetworkError || translate.isHttpError)
        {
            Debug.Log(translate.error);
        }
        else
        {
            string parsedResponse = translate.downloadHandler.text.Split('>')[1].Split('<')[0];
            Debug.Log(parsedResponse);
            t.GetComponent<Text>().text = parsedResponse;
        }
    }
    public void Dictate()
    {
        debug.GetComponent<Text>().text = "Started Dictation";
        PhraseRecognitionSystem.Shutdown();
        m_DictationRecognizer = new DictationRecognizer();
        debug.GetComponent<Text>().text = "Created DictationRecogniser";
        m_DictationRecognizer.DictationResult += (text, confidence) =>
            {
              debug.GetComponent<Text>().text = "Dictation Result";
                Debug.LogFormat("Dictation result: {0}", text);
                //t.GetComponent<Text>().text = text;
                StartCoroutine(Translate(text));

            };

        m_DictationRecognizer.DictationHypothesis += (text) =>
            {
              debug.GetComponent<Text>().text = String.Format("Hypothesis {0}", text);
                Debug.LogFormat("Dictation hypothesis: {0}", text);
                t.GetComponent<Text>().text = text;
            };

        m_DictationRecognizer.DictationComplete += (completionCause) =>
            {
              debug.GetComponent<Text>().text = completionCause.ToString();
                Debug.Log(completionCause.ToString());
                m_DictationRecognizer.Start();
            };

        m_DictationRecognizer.DictationError += (error, hresult) =>
            {
              debug.GetComponent<Text>().text = error.ToString();
                Debug.Log(error.ToString());
            };

        m_DictationRecognizer.Start();
    }
}

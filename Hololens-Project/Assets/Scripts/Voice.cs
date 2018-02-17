using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity.InputModule;
using System.Collections;

public class Voice : MonoBehaviour
{
    private DictationRecognizer m_DictationRecognizer;
    public GameObject t;
    public GameObject translatedT;
    public SpeechInputSource keywordRecogiser;
    public string apiKey;
    public string dictatingLanguage;
    public string translatingLanguage;

    public IEnumerator Translate(string text)
    {
        string urlEncodedText = WWW.EscapeURL(text);
        string url = "https://api.microsofttranslator.com/V2/Http.svc/Translate?to=" + translatingLanguage + "&from=" + dictatingLanguage + "&text=" + urlEncodedText;
        //string url = "http://brianw.netsoc.ie/telecomms.html";
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
            translatedT.GetComponent<Text>().text = parsedResponse;
        }
    }
    public void Dictate()
    {
        Debug.Log("Started Dictation");
        PhraseRecognitionSystem.Shutdown();
        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
            {
                Debug.LogFormat("Dictation result: {0}", text);
                t.GetComponent<Text>().text = text;
                StartCoroutine(Translate(text));
            };

        m_DictationRecognizer.DictationHypothesis += (text) =>
            {
                Debug.LogFormat("Dictation hypothesis: {0}", text);
                t.GetComponent<Text>().text = text;
            };

        m_DictationRecognizer.DictationComplete += (completionCause) =>
            {
                Debug.Log(completionCause.ToString());
                
            };

        m_DictationRecognizer.DictationError += (error, hresult) =>
            {
                Debug.Log(error.ToString());
            };

        m_DictationRecognizer.Start();
    }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity.InputModule;

public class Voice : MonoBehaviour
{
    private DictationRecognizer m_DictationRecognizer;
    public GameObject t;
    public SpeechInputSource keywordRecogiser;
    public void Dictate()
    {
        Debug.Log("Started Dictation");
        PhraseRecognitionSystem.Shutdown();
        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
            {
                Debug.LogFormat("Dictation result: {0}", text);
                t.GetComponent<Text>().text = text;
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
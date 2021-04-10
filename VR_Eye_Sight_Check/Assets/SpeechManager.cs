using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Text.RegularExpressions;

public class SpeechManager : MonoBehaviour
{
    public AudioSource _audio;
    public string[] m_Keywords;
    int n = 0;
    int i = 0;
    private KeywordRecognizer m_Recognizer;

    // Use this for initialization
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(n==0)
        {
            if (i == m_Keywords.Length)
            {
                Debug.Log("Eye Test Completed ; Your Score: " + i);
                StartCoroutine(DownlaodTheAudio("Eye Test Completed ; Your Score: " + i));
                n++;
            }
        }
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if(args.text.ToCharArray()[0]==m_Keywords[i].ToCharArray()[0])
        {
            Debug.Log(m_Keywords[i].ToCharArray()[0]);
            StartCoroutine(DownlaodTheAudio("You can proceed"));
            i++;
        }

        else
        {
            Debug.Log("You failed,Your Score is " + i);
            StartCoroutine(DownlaodTheAudio("You failed,Your Score is " + i));
        }
    }

    IEnumerator DownlaodTheAudio(string s)
    {
        Regex rgx = new Regex("\\s+");
        string result = rgx.Replace(s, "+");
        string url = "http://api.voicerss.org/?key=f2f2734743aa4c319f14efcfde4a81a8&hl=en-us&src=" + result;
        WWW www = new WWW(url);
        yield return www;
        _audio.clip = www.GetAudioClip(false, true, AudioType.WAV);
        _audio.Play();
    }
}

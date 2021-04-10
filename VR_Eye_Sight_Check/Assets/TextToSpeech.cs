using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
public class TextToSpeech : MonoBehaviour
{
    public AudioSource _audio;
    public InputField inputtext;
  
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
    }

   
    void Update()
    {
        
    }
    IEnumerator DownlaodTheAudio()
    {
        Regex rgx = new Regex("\\s+");
        string result = rgx.Replace(inputtext.text,"+");
        string url = "http://api.voicerss.org/?key=f2f2734743aa4c319f14efcfde4a81a8&hl=en-us&src="+result;
        WWW www = new WWW(url);
        yield return www;
        _audio.clip = www.GetAudioClip(false, true, AudioType.WAV);
        _audio.Play();
    }
    public void click()
    {
        StartCoroutine(DownlaodTheAudio());
    }
}

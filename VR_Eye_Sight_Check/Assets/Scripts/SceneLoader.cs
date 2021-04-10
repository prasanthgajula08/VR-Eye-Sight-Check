using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadSnellen()
    {
        Application.LoadLevel(1);
    }

    public void LoadLogMar()
    {
        Application.LoadLevel(2);
    }

    public void LoadGolovin()
    {
        Application.LoadLevel(3);
    }

    public void LoadEchelle()
    {
        Application.LoadLevel(4);
    }

    public void LoadMainMenu()
    {
        Application.LoadLevel(0);
    }
}

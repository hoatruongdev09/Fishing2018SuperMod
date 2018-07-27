﻿using UnityEngine;
using System.Collections;

public class MainStartControl : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 1;
        AudioControl.Instance.Offbg();
        AudioControl.Instance.openbg();
        PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}

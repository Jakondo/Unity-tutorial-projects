﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonX : MonoBehaviour
{
    private Button exitButton;
   
    // Start is called before the first frame update
    void Start()
    {
        exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(ExitFromGame);
    }

    void ExitFromGame()
    {
        Application.Quit();
    }
}

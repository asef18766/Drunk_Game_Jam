﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject endmenu;
    public void ShowEndMenu()
    {
        endmenu.SetActive(true);
    }
    public void RestartGame()
    {
         SceneManager.LoadScene("Fish");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

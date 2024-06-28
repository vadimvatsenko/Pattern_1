using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Синглтон в Unity
public class GameManager : MonoBehaviour // это Синглтон
{
    public static Action onIsCatDead;
    public static GameManager _instance { get; private set; }
    private void Awake() // создаем его в Awake
    {
        if (_instance == null) 
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject); // не уничтожать объект при переходе между сценами
            return;
        }

        Destroy(this.gameObject); // уничтожает дубль, если есть такой
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


        
}

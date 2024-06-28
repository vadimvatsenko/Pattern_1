using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �������� � Unity
public class GameManager : MonoBehaviour // ��� ��������
{
    public static Action onIsCatDead;
    public static GameManager _instance { get; private set; }
    private void Awake() // ������� ��� � Awake
    {
        if (_instance == null) 
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject); // �� ���������� ������ ��� �������� ����� �������
            return;
        }

        Destroy(this.gameObject); // ���������� �����, ���� ���� �����
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


        
}

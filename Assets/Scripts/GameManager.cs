using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������� � Unity
public class GameManager : MonoBehaviour // ��� ��������
{
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
}

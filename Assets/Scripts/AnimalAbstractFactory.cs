using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalAbstractFactory : MonoBehaviour
{
    public abstract GameObject CreateCat(); // Cat ��� ������
    public abstract IAsyncEnumerable<GameObject> CreateDogAsync(int count);
    public abstract IAsyncEnumerable<GameObject> CreateChickensAsync(int count); // ��� �� ������� async, async ������� � ����������


}

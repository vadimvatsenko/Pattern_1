using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalAbstractFactory : MonoBehaviour
{
    public abstract GameObject CreateCat(); 
    public abstract IAsyncEnumerable<GameObject> CreateDogAsync(int count);
    public abstract IAsyncEnumerable<GameObject> CreateChickensAsync(int count); // тут мы убираем async, async добавим в наследнике
}

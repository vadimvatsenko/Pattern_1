using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalAbstractFactory : MonoBehaviour
{
    public abstract GameObject CreateCat(); // Cat это скрипт
    public abstract List<GameObject> CreateDog();
    public abstract List<GameObject> CreateChickens();
    
}

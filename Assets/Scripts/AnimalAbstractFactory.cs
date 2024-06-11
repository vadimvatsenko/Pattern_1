using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalAbstractFactory : MonoBehaviour
{
    public abstract Cat CreateCat();
    public abstract Dog CreateDog();

    /*public abstract GameObject CreateGameObject();*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBuilder : MonoBehaviour
{
    AnimalFactory animalfactory;
    private void Start()
    {
        animalfactory = new AnimalFactory();
        animalfactory.CreateGameObject();
    }
}

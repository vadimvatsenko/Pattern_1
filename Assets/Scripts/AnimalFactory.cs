using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalFactory : AnimalAbstractFactory
{
    

    public override Cat CreateGameObject()
    {
        Cat cat = new Cat();

        return cat;
    }
}

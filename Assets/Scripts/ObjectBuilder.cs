using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ObjectBuilder : MonoBehaviour
{
    private AnimalFactory _factory;
    private FieldObjectFactory _fieldObjectFactory;

    private void Awake()
    {
        _factory = new AnimalFactory();
        _fieldObjectFactory = new FieldObjectFactory();

        _fieldObjectFactory.CreatePlane();
        _factory.CreateCat();
        _factory.CreateDog();
        _factory.CreateChickens();

        //await InitializeFieldObjects();
        _fieldObjectFactory.CreateTrees1();
        _fieldObjectFactory.CreateTrees2();
        
    }

    private void Start()
    {
        _fieldObjectFactory.CreateFlowers();
    }


    /* private async Task InitializeFieldObjects()
     {
         await Task.Run(() => _fieldObjectFactory.CreateTrees1());
     }*/

}

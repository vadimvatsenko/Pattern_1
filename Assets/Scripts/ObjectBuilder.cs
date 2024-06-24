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
       

        _fieldObjectFactory.CreateTrees1();
        _fieldObjectFactory.CreateTrees2();        
    }

    private async void Start()
    {
        await InitializeFieldObjects();
    }

    private async Task InitializeFieldObjects()
    {
        await foreach (var ch in _factory.CreateChickensAsync(200)) ;
        await foreach (var dog in _factory.CreateDogAsync(5)) ;
        await foreach(var flow in _fieldObjectFactory.CreateFlowersAsync(500)) ;        
    }
}

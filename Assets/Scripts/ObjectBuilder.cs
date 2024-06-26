using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ObjectBuilder : MonoBehaviour
{
    private AnimalFactory _factory;
    private FieldObjectFactory _fieldObjectFactory;
    private bool isDestroy = false;

    private void Awake()
    {
        _factory = new AnimalFactory();
        _fieldObjectFactory = new FieldObjectFactory();

        _fieldObjectFactory.CreatePlane();
        _factory.CreateCat();
    }

    private async void Start()
    {
        await InitializeFieldObjects();
    }

    private void OnDisable()
    {
        isDestroy = true;
    }

    private async Task InitializeFieldObjects()
    {
        await foreach (var ch in _factory.CreateChickensAsync(200)) ;

        await foreach (var dog in _factory.CreateDogAsync(5)) ;

        await foreach (var tree1 in _fieldObjectFactory.CreateTrees1Async(Random.Range(20, 30))) ;

        await foreach (var tree2 in _fieldObjectFactory.CreateTrees2Async(Random.Range(20, 30))) ;

        await foreach (var flow in _fieldObjectFactory.CreateFlowersAsync(500)) ;
        
    }
}
    
   


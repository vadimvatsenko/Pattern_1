using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

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
    }

    private async void Start()
    {
        await InitializeFieldObjects();
    }

    private void OnDisable()
    {
       
    }
    private void OnApplicationQuit() // закрытие всех потоков, при выход
    {
        
    }

    private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    private async Task InitializeFieldObjects()
    {
        Application.Quit();

        await foreach (var flow in _fieldObjectFactory.CreateFlowersAsync(500)) ;
        await foreach (var dog in _factory.CreateDogAsync(5)) ;
        await foreach (var ch in _factory.CreateChickensAsync(200)) ;

        await foreach (var tree1 in _fieldObjectFactory.CreateTrees1Async(Random.Range(20, 30))) ;

        await foreach (var tree2 in _fieldObjectFactory.CreateTrees2Async(Random.Range(20, 30))) ;

        
    }
}
    
   


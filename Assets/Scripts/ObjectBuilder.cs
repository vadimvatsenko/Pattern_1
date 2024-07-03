using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;



public class ObjectBuilder : MonoBehaviour
{
    CancellationTokenSource cancelTokenSource;
    CancellationToken token;
    Task task;

    private bool isAppQuit = false;
    private AnimalFactory _factory;
    private FieldObjectFactory _fieldObjectFactory;

    private async void Awake()
    {
        _factory = new AnimalFactory();
        _fieldObjectFactory = new FieldObjectFactory();

        _fieldObjectFactory.CreatePlane();
        _factory.CreateCat();

        cancelTokenSource = new CancellationTokenSource();
        token = cancelTokenSource.Token;
        task = ReadAsyncEnumerable(InitializeFieldObjects(cancelTokenSource.Token), cancelTokenSource.Token);

        try
        {
            await task;

        }
        catch 
        {
            //Debug.Log("Поток окончен");
        }
    }
  

    private void OnApplicationQuit() // закрытие всех потоков, при выход
    {
        cancelTokenSource.Cancel();
        cancelTokenSource.CancelAfter(0);
        cancelTokenSource.Dispose();
    }

    private async IAsyncEnumerable<GameObject> InitializeFieldObjects(CancellationToken cancellationToken)
    {

        await foreach (var flow in _fieldObjectFactory.CreateFlowersAsync(500))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return flow.gameObject;
        }
        await foreach (var dog in _factory.CreateDogAsync(5))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return dog.gameObject;
        }
        await foreach (var ch in _factory.CreateChickensAsync(200))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return ch.gameObject;
        }
        await foreach (var tree1 in _fieldObjectFactory.CreateTrees1Async(Random.Range(20, 30)))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return tree1.gameObject;
        }
        await foreach (var tree2 in _fieldObjectFactory.CreateTrees2Async(Random.Range(20, 30)))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return tree2.gameObject;
        }

        await Task.Delay(0, cancellationToken);

    }

    static async Task ReadAsyncEnumerable(IAsyncEnumerable<GameObject> asyncEnumerable, CancellationToken cancellationToken)
    {
        await foreach (var item in asyncEnumerable.WithCancellation(cancellationToken))
        {
            //Debug.Log($"Получено: {item}");
        }
    }
}
    
   


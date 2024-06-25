using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ObjectBuilder : MonoBehaviour
{
    private AnimalFactory _factory;
    private FieldObjectFactory _fieldObjectFactory;
    private List<GameObject> _createdObjects = new List<GameObject>(); // список который будет хранить все объекты которые нужно создать; 

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

    private void OnDisable()
    {
        DestroyGameObject();
    }

    private async Task InitializeFieldObjects()
    {
        /*await foreach (var ch in _factory.CreateChickensAsync(200)) ;
        await foreach (var dog in _factory.CreateDogAsync(5)) ;
        await foreach (var flow in _fieldObjectFactory.CreateFlowersAsync(500)) ;    */
        await foreach (var ch in _factory.CreateChickensAsync(200))
        {
            AddCreatedObject(ch);
        }
        await foreach (var dog in _factory.CreateDogAsync(5))
        {
            AddCreatedObject(dog);
        }
        await foreach (var flow in _fieldObjectFactory.CreateFlowersAsync(500))
        {
            AddCreatedObject(flow);
        }       
    }

    private void AddCreatedObject(GameObject gameObject)
    {
        if (gameObject == null)
        {
            _createdObjects.Add(gameObject);
        }
    }

    private void DestroyGameObject()
    {
        foreach (var obj in _createdObjects)
        {
            if(obj != null)
            {
                Destroy(obj);
            }
        }

        _createdObjects.Clear();
    }
}

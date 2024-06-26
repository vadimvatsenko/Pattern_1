using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldObjectAbstractFactory : MonoBehaviour
{   
    public abstract GameObject CreatePlane();
    public abstract IAsyncEnumerable<GameObject> CreateTrees1Async(int numb);
    public abstract IAsyncEnumerable<GameObject> CreateTrees2Async(int numb);
    public abstract IAsyncEnumerable<GameObject> CreateFlowersAsync(int numb);
}

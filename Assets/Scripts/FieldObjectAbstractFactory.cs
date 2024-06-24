using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldObjectAbstractFactory : MonoBehaviour
{   
    public abstract GameObject CreatePlane();
    public abstract List<GameObject> CreateTrees1();
    public abstract List<GameObject> CreateTrees2();
    public abstract IAsyncEnumerable<GameObject> CreateFlowersAsync(int numb);
}

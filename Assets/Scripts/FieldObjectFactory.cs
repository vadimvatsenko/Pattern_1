using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;


public class FieldObjectFactory : FieldObjectAbstractFactory
{
    public override GameObject CreatePlane()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane); // создание примитивной фигуры
        plane.AddComponent<Plane>();
        return plane;
    }

    public override async IAsyncEnumerable<GameObject> CreateFlowersAsync(int numb)
    {       
        GameObject flowerPrefab = Resources.Load<GameObject>(StaticFields.FlowersPath);        
        Transform flowersHolder = FindObjectOfType<Plane>().transform.Find(StaticFields.FlowersHolder).transform;
      
        for (int i = 0; i < numb; i++)
        {        
            GameObject newFlower = GameObject.Instantiate(flowerPrefab);
            newFlower.transform.position = new Vector3(Random.Range(StaticFields.LeftBoard, StaticFields.RightBoard), 0, Random.Range(StaticFields.TopBoard, StaticFields.BottomBoard));

            newFlower.transform.SetParent(flowersHolder);
            
            await Task.Yield();
            yield return newFlower;
        }
    }

    public override async IAsyncEnumerable<GameObject> CreateTrees1Async(int numb)
    {
        GameObject tree1Prefab = Resources.Load<GameObject>(StaticFields.Trees1Path);
        Transform trees1Holder = GameObject.FindGameObjectWithTag("Map").transform.Find(StaticFields.Trees1Holder);

        for (int i = 0; i < numb; i++)
        {
            GameObject newTree1 = GameObject.Instantiate(tree1Prefab);
            newTree1.transform.position = new Vector3(Random.Range(StaticFields.LeftBoard, StaticFields.RightBoard), 0, Random.Range(StaticFields.TopBoard, StaticFields.BottomBoard));
            newTree1.transform.SetParent(trees1Holder);

            await Task.Yield();
            yield return newTree1;
        }
    }
    public override async IAsyncEnumerable<GameObject> CreateTrees2Async(int numb)
    {
        GameObject tree2Prefab = Resources.Load<GameObject>(StaticFields.Trees2Path);
        Transform trees2Holder = GameObject.FindGameObjectWithTag("Map").transform.Find(StaticFields.Trees2Holder);
        //await Task.Yield();
        
        await foreach(var t in CreateObjects(tree2Prefab, trees2Holder, numb))
        {
            yield return t;
        }       
    }

    public async IAsyncEnumerable<GameObject> CreateObjects(GameObject prefab, Transform objectHolder, int count) 
    {
        for (int i = 0; i < count; i++) 
        {
            GameObject newObject = GameObject.Instantiate(prefab);
            newObject.transform.position = new Vector3(Random.Range(StaticFields.LeftBoard, StaticFields.RightBoard), 0, Random.Range(StaticFields.TopBoard, StaticFields.BottomBoard));
            newObject.transform.SetParent(objectHolder);
            await Task.Yield();
            yield return newObject;
        }
    }
}

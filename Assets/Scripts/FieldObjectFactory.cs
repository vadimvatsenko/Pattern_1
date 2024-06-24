using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;


public class FieldObjectFactory : FieldObjectAbstractFactory
{
    Plane _plane;

    private void Start()
    {
        _plane = new Plane();
    }
    public override GameObject CreatePlane()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane); // создание примитивной фигуры
        plane.AddComponent<Plane>();
        return plane;
    }

    public override async IAsyncEnumerable<GameObject> CreateFlowersAsync(int numb)
    {       
        GameObject flowerPrefab = Resources.Load<GameObject>("Prefabs/Flower");
        
        Transform flowersHolder = FindObjectOfType<Plane>().transform.Find("Flowers").transform;

        

        for (int i = 0; i < numb; i++)
        {        
            GameObject newFlower = GameObject.Instantiate(flowerPrefab);
            newFlower.transform.position = new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));

            newFlower.transform.SetParent(flowersHolder);
            
            await Task.Yield();
            yield return newFlower;
        }
    }
    public override List<GameObject> CreateTrees2()
    {
        Transform trees2Holder = GameObject.FindGameObjectWithTag("Map").transform.Find("Trees2");
        Transform plane = GameObject.FindGameObjectWithTag("Map").transform;
        GameObject tree2Prefab = Resources.Load<GameObject>("Prefabs/Tree2");
        int randomCountTrees2 = Random.Range(20, 30);

        Vector3 planeSize = plane.GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 planeWorldSize = Vector3.Scale(planeSize, plane.transform.localScale);

        List<GameObject> trees2List = new List<GameObject>();

        for (int i = 0; i < randomCountTrees2; i++)
        {
            GameObject newTree1 = GameObject.Instantiate(tree2Prefab);
            newTree1.transform.localPosition = new Vector3(Random.Range(-planeWorldSize.x / 2 + 1, planeWorldSize.x / 2 - 1), 0, Random.Range(-planeWorldSize.z / 2 + 1, planeWorldSize.z / 2 - 1));
            newTree1.transform.SetParent(trees2Holder);
            trees2List.Add(newTree1);
        }

        return trees2List;
    }

    public override List<GameObject> CreateTrees1()
    {
        Transform trees1Holder = GameObject.FindGameObjectWithTag("Map").transform.Find("Trees1");
        Transform plane = GameObject.FindGameObjectWithTag("Map").transform;
        GameObject tree1Prefab = Resources.Load<GameObject>("Prefabs/Tree1");
        int randomCountTrees1 = Random.Range(20, 30);

        Vector3 planeSize = plane.GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 planeWorldSize = Vector3.Scale(planeSize, plane.transform.localScale);

        List<GameObject> trees1List = new List<GameObject>();

        for (int i = 0; i < randomCountTrees1; i++)
        {
            GameObject newTree1 = GameObject.Instantiate(tree1Prefab);
            newTree1.transform.localPosition = new Vector3(Random.Range(-planeWorldSize.x / 2 + 1, planeWorldSize.x / 2 - 1), 0, Random.Range(-planeWorldSize.z / 2 + 1, planeWorldSize.z / 2 - 1));
            newTree1.transform.SetParent(trees1Holder);
            trees1List.Add(newTree1);
        }

        return trees1List;
    }
}

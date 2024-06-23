using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;


public class FieldObjectFactory : FieldObjectAbstractFactory
{
    Plane _plane;
    /*Transform _plane;
    Transform _flowersHolder;
    Transform _trees1Holder;*/

    private void Start()
    {
        _plane = new Plane();
        //Debug.Log(_plane._flowersChildren);
    }
    public override GameObject CreatePlane()
    {
        Debug.Log("Plane");
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane); // создание примитивной фигуры
        plane.AddComponent<Plane>();
        return plane;
    }

    /*public override async IAsyncEnumerable<GameObject> CreateTrees1()
    {
        Debug.Log("Tree");
        Transform _plane = GameObject.FindWithTag("Map").transform.Find("Flowers");
        await foreach (var t in ReturnTree1())
        {
            t.transform.SetParent(_plane);
            t.transform.localPosition = new Vector3(Random.Range(0, 30), 0, Random.Range(0, 30));
            Debug.Log(t);
            yield return t;
        }
    }*/

    public override List<GameObject> CreateFlowers()
    {
        
        Debug.Log("Flowers");
        GameObject flowerPrefab = Resources.Load<GameObject>("Prefabs/Flower");
        int randomCoutFlowers = Random.Range(500, 1000);
        List<GameObject> flowers = new List<GameObject>();

        Transform flowersHolder = FindObjectOfType<Plane>().transform.Find("Flowers").transform;

        for (int i = 0; i < randomCoutFlowers; i++)
        {        
            GameObject newFlower = GameObject.Instantiate(flowerPrefab);
            //newFlower.transform.position = new Vector3(Random.Range(-_plane._planeWorldSize.x / 2 + 1, _plane._planeWorldSize.x / 2 - 1), 0, Random.Range(-_plane._planeWorldSize.z / 2 + 1, _plane._planeWorldSize.z / 2 - 1));
            newFlower.transform.position = new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));
            newFlower.transform.SetParent(flowersHolder);
            flowers.Add(newFlower);
        }

        return flowers;
    }
    public override List<GameObject> CreateTrees2()
    {
        Transform trees2Holder = GameObject.FindGameObjectWithTag("Map").transform.Find("Trees2");
        Transform _plane = GameObject.FindGameObjectWithTag("Map").transform;
        GameObject tree2Prefab = Resources.Load<GameObject>("Prefabs/Tree2");
        int randomCountTrees2 = Random.Range(20, 30);

        Vector3 planeSize = _plane.GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 planeWorldSize = Vector3.Scale(planeSize, _plane.transform.localScale);

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
        Transform _plane = GameObject.FindGameObjectWithTag("Map").transform;
        GameObject tree1Prefab = Resources.Load<GameObject>("Prefabs/Tree1");
        int randomCountTrees1 = Random.Range(20, 30);

        Vector3 planeSize = _plane.GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 planeWorldSize = Vector3.Scale(planeSize, _plane.transform.localScale);

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
    /*private async IAsyncEnumerable<GameObject> ReturnTree1()
{
   Debug.Log("ReturnTree1");
   GameObject treePrefab = Resources.Load<GameObject>("Prefabs/Tree");
   int randomCountTree1 = Random.Range(19, 50);

   //await foreach () ;

   for (int i = 0; i < randomCountTree1; i++)
   {
       var newTree = GameObject.Instantiate(treePrefab);
       yield return newTree;           
   }
}*/

}

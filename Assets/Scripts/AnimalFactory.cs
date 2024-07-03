using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;


public class AnimalFactory : AnimalAbstractFactory
{

    public override GameObject CreateCat()
    {        
        GameObject catPrefab = Resources.Load<GameObject>("Models/Cat"); // если создать папку Resources в Ассетах
        GameObject goCat = GameObject.Instantiate(catPrefab);
        goCat.AddComponent<Player>(); 
        return goCat;
    }

    public override async IAsyncEnumerable<GameObject> CreateDogAsync(int count)
    {
        GameObject dogPrefab = Resources.Load<GameObject>("Models/Dog"); // в статику вынести
        GameObject dogsParent = new GameObject("Dogs");

        for (int i = 0; i < count; i++)
        {
            var goDog = GameObject.Instantiate(dogPrefab);
            goDog.transform.position = new Vector3(Random.Range(StaticFields.LeftBoard, StaticFields.RightBoard), 0, Random.Range(StaticFields.TopBoard, StaticFields.BottomBoard ));
            //goDog.AddComponent<Dog>();
            goDog.transform.SetParent(dogsParent.transform);
            
            await Task.Yield();

            yield return goDog;
        }        
    }

    public override async IAsyncEnumerable<GameObject> CreateChickensAsync(int count)
    {
        GameObject chickenPrefab = Resources.Load<GameObject>("Models/Chicken");
        GameObject chickenParent = new GameObject("Chickens");


        for (int i = 0; i < count; i++)
        {
            var goChicken = GameObject.Instantiate(chickenPrefab);
            goChicken.AddComponent<Chicken>();
            goChicken.transform.position = new Vector3(Random.Range(StaticFields.LeftBoard, StaticFields.RightBoard), 0, Random.Range(StaticFields.TopBoard, StaticFields.BottomBoard));
            goChicken.transform.SetParent(chickenParent.transform);

            await Task.Yield();

            yield return goChicken;


        }
    }
}

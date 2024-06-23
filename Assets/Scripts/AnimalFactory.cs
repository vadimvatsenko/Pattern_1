using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AnimalFactory : AnimalAbstractFactory
{
    
    public override GameObject CreateCat()
    {
        GameObject catPrefab = Resources.Load<GameObject>("Models/Cat"); // если создать папку Resources в Ассетах
        GameObject goCat = GameObject.Instantiate(catPrefab);
        goCat.AddComponent<Cat>(); 
        return goCat;
    }


    public override List<GameObject> CreateDog()
    {
        GameObject dogPrefab = Resources.Load<GameObject>("Models/Dog");
        List<GameObject> dogList = new List<GameObject>();
        GameObject dogsParent = new GameObject("Dogs");

        for (int i = 0; i < 5; i++)
        {
            var goDog = GameObject.Instantiate(dogPrefab);
            goDog.AddComponent<Dog>();
            goDog.AddComponent<DogVision>();
            goDog.transform.position = new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));
            goDog.transform.SetParent(dogsParent.transform);
            dogList.Add(goDog);
        }
        
        return dogList;
    }
    public override List<GameObject> CreateChickens()
    {
        GameObject chickenPrefab = Resources.Load<GameObject>("Models/Chicken");
        List<GameObject> chickenList = new List<GameObject>();
        GameObject chickenParent = new GameObject("Chickens");

        for (int i = 0; i < 100; i++)
        {
            var goChicken = GameObject.Instantiate(chickenPrefab);
            goChicken.AddComponent<Chicken>();
            goChicken.AddComponent<DogVision>();
            goChicken.transform.position = new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));
            goChicken.transform.SetParent(chickenParent.transform);
            chickenList.Add(goChicken);
        }

        return chickenList;
    }
}

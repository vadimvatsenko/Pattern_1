using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events
{
   
    public delegate void GameReset(GameObject cat);
    public static event GameReset? gameReset;

    public static void InvokeGameReset(GameObject cat)
    {
        gameReset?.Invoke(cat);
    }
}

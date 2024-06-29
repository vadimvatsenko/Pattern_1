using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events
{
    public delegate void IsCatDead(bool isDead);
    public static event IsCatDead? isCatDead;

    public delegate void GameReset();
    public static event GameReset? gameReset;

    public static void InvokeIsCatDead(bool isDead)
    {
        isCatDead?.Invoke(isDead);
    }

    public static void InvokeGameReset()
    {
        gameReset?.Invoke();
    }
}

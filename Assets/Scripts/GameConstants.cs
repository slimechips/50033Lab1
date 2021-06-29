using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
    int currentScore;
    int currentPlayerHealth;

    public float groundDistance = -2.9f;

    // for Reset values
    Vector3 gombaSpawnPointStart = new Vector3(2.5f, -0.45f, 0); // hardcoded location
                                                                 // .. other reset values 

    // for Consume.cs
    public int consumeTimeStep = 10;
    public int consumeLargestScale = 4;

    // for Break.cs
    public int breakTimeStep = 30;
    public int breakDebrisTorque = 10;
    public int breakDebrisForce = 10;

    // for SpawnDebris.cs
    public int spawnNumberOfDebris = 10;

    // for Rotator.cs
    public int rotatorRotateSpeed = 6;

    // for testing
    public int testValue;

    // for enemyController
    public float maxOffset = 5.0f;
    public float enemyPatroltime = 2.0f;

    // for playerController
    public int maxHealth = 10;

    // for Spawner
    public float spawnInterval = 3.0f;
    public int spawnAmt = 2;
    public int spawnMax = 6;

}

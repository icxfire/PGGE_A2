using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoints : MonoBehaviour
{
    /*public List<Transform> mSpawnPoints = new List<Transform>();

    public Transform GetSpawnPoint()
    {
        if (mSpawnPoints.Count == 0) return this.transform;
        return mSpawnPoints[Random.Range(0, mSpawnPoints.Count)].transform;
    }*/

    public Transform[] mSpawnPoints; // change the list into an array as we are not adding any new spawn points during the game

    public Transform GetSpawnPoint()
    {
        return (mSpawnPoints.Length == 0) ? transform : mSpawnPoints[Random.Range(0, mSpawnPoints.Length)].transform; // made the function neater 
    }
}

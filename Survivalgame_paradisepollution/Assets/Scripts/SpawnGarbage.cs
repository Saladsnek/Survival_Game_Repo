using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGarbage : MonoBehaviour
{
    public GameObject gameObjectToInstance;
    public bool hasTrash = false;
    public bool destruction = true;
    public void spawnGarbage()
    {
        int spawnChance = Random.Range(1, 11);
        if (spawnChance == 10 && hasTrash == false)
        {
            Instantiate(gameObjectToInstance, transform.position, Quaternion.identity);
            hasTrash = true;
            FindObjectOfType<MechanicsForPlayer>().fullGarbage ++;
        }
    }
}

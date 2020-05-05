using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGarbage : MonoBehaviour
{
    // Start is called before the first frame upd
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<SpawnGarbage>().hasTrash = false;
            FindObjectOfType<MechanicsForPlayer>().fullGarbage--;
        }
    }
}

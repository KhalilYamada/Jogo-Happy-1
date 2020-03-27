using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("object") || coll.CompareTag("item"))
        {
            Destroy(coll.gameObject);
        }
    }
}

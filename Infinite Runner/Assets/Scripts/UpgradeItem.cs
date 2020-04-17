using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItem : MonoBehaviour
{
    public bool isTheItemGood;
    private GameObject scorePrefabs, gameC;
    private Rigidbody2D rb2d;

    void MoveTheItem()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(Vector2.left * gameC.GetComponent<GameController>().objectSpeed);
    }
}

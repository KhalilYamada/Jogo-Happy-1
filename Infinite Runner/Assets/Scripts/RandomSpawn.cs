using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    float time;


    [System.Serializable]
    public class SpawnRarity
    {
        public string itemName;
        public GameObject item;
        public int rarity;
    }
    public List<SpawnRarity> Drop = new List<SpawnRarity>();
    public int dropChance;

    public void CalculateLoot()
    {
        int calcDropChance = Random.Range(0, 101);
        if (calcDropChance > dropChance)
        {
            return;
        }
        if (calcDropChance <= dropChance)
        {
            int itemWeight = 0;
            for (int i = 0; i < Drop.Count; i++)
            {
                itemWeight += Drop[i].rarity;
            }

            int randomValue = Random.Range(0, itemWeight);
            for (int k = 0; k < Drop.Count; k++)
            {
                if (randomValue <= Drop[k].rarity)
                {
                    if (Drop[k].item.GetComponent<ObjectMovement>().type.ToString() == "cactus1")
                    {
                        Instantiate(Drop[k].item, new Vector3(transform.position.x, transform.position.y + 0.21f, 0), Quaternion.identity);
                        return;
                    }
                    else if (Drop[k].item.GetComponent<ObjectMovement>().type.ToString() == "cactus2")
                    {
                        Instantiate(Drop[k].item, new Vector3(transform.position.x, transform.position.y + 0.21f, 0), Quaternion.identity);
                        return;
                    }
                    else if (Drop[k].item.GetComponent<ObjectMovement>().type.ToString() == "cactus3")
                    {
                        Instantiate(Drop[k].item, new Vector3(transform.position.x, transform.position.y + 0.21f, 0), Quaternion.identity);
                        return;
                    }
                    else if (Drop[k].item.GetComponent<ObjectMovement>().type.ToString() == "cactus4")
                    {
                        Instantiate(Drop[k].item, transform.position, Quaternion.identity);
                        return;
                    }
                    else if (Drop[k].item.GetComponent<ObjectMovement>().type.ToString() == "goodItem")
                    {
                        Instantiate(Drop[k].item, new Vector3(transform.position.x, transform.position.y + 0.21f, 0), Quaternion.identity);
                        return;
                    }
                    else if (Drop[k].item.GetComponent<ObjectMovement>().type.ToString() == "badItem")
                    {
                        Instantiate(Drop[k].item, new Vector3(transform.position.x, transform.position.y + 0.21f, 0), Quaternion.identity);
                        return;
                    }
                }
                randomValue -= Drop[k].rarity;
            }

        }

    }

    void WaitForSpawn()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            CalculateLoot();
            time = Random.Range(1.75f, 3.5f);
        }
    }

    private void Update()
    {
        WaitForSpawn();
    }

    private void Start()
    {
        CalculateLoot();
        time = Random.Range(1.75f, 3.5f);
    }
}


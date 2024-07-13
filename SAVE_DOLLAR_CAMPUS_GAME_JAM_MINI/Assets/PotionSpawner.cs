using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> Items;
    public List<Transform> Spawns;
    void Start()
    {
        StartCoroutine(ItemSpawner());
        StartCoroutine(BotSpawner());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject Bots;
    IEnumerator BotSpawner()
    {
        yield return new WaitForSeconds(Random.Range(10, 20));
        Instantiate(Bots, Spawns[Random.Range(0, Spawns.Count)].position, Quaternion.identity);

        StartCoroutine(BotSpawner());
    }

    IEnumerator ItemSpawner()
    {
        yield return new WaitForSeconds(Random.Range(5,10));
        Instantiate(Items[Random.Range(0,Items.Count)], Spawns[Random.Range(0,Spawns.Count)].position, Quaternion.identity);

        StartCoroutine(ItemSpawner());
    }
}

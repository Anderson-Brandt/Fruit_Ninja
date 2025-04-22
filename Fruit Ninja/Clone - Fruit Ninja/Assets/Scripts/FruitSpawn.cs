using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    public GameObject fruit;
    public Transform[] spawnPoints;

    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            float Timer = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(1f);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedFruit = Instantiate(fruit, spawnPoint.position, spawnPoint.rotation);
            AudioController.instance.PlayMusic(AudioController.instance.woosh);
            Destroy(spawnedFruit, 5f);
        }
    }
}

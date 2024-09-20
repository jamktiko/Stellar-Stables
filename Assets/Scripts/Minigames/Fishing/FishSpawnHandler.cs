using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnHandler : MonoBehaviour
{

    [SerializeField] private GameObject[] fishPrefabs;
    [SerializeField] private float spawnRateMin;
    [SerializeField] private float spawnRateMax;
    [SerializeField] private float fishSpeedMin;
    [SerializeField] private float fishSpeedMax;

    private float[] spawnSide = new float[2] { -10f, 10f };
    private float spawnXValue;
    private float spawnYValue;

    private bool winCondition = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFish());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnFish()
    {
        while (!winCondition)
        {
            float spawnDelay = Random.Range(spawnRateMin, spawnRateMax);
            yield return new WaitForSeconds(spawnDelay);

            spawnXValue = spawnSide[Random.Range(0, 2)];
            spawnYValue = Random.Range(-4.25f, 4.25f);

            Vector3 randomSpawnPosition = new Vector3(spawnXValue, spawnYValue, 0);

            if (spawnXValue == 10f)
            {
                Debug.Log("Fish spawned on right.");
                GameObject spawnedFish = Instantiate(fishPrefabs[Random.Range(0,fishPrefabs.Length)], randomSpawnPosition, Quaternion.identity);
                spawnedFish.GetComponent<FishMovementHandler>().Spawned(spawnXValue, Random.Range(fishSpeedMin, fishSpeedMax));
            }
            else
            {
                Debug.Log("Fish spawned on left.");
                GameObject spawnedFish = Instantiate(fishPrefabs[Random.Range(0, fishPrefabs.Length)], randomSpawnPosition, Quaternion.identity);
                spawnedFish.GetComponent<FishMovementHandler>().Spawned(spawnXValue, Random.Range(fishSpeedMin, fishSpeedMax));
            }

        }
    }

}

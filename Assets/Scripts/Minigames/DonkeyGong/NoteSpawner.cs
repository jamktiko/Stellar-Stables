using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{

    [SerializeField] private GameObject notePrefab;
    [SerializeField] private Sprite[] noteVariations;
    [SerializeField] private Sprite[] badNoteVariations;
    [SerializeField] private Sprite[] colourVariations;
    [SerializeField] private float badNoteSpawnChance;
    [SerializeField] private float spawnRateMin;
    [SerializeField] private float spawnRateMax;
    [SerializeField] private int numberOfSpawnPoints;
    [SerializeField] private float radius;

    [SerializeField] private int minigameLevel;

    private List<Vector2> spawnPoints = new List<Vector2>();
    private bool winCondition = false;

    // Start is called before the first frame update
    void Start()
    {
        GenerateSpawnPoints();
        StartCoroutine(SpawnNotes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateSpawnPoints()
    {
        float angleStep = 360f / numberOfSpawnPoints;
        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector2 spawnPoint = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
            spawnPoints.Add(spawnPoint);
        }
    }

    private IEnumerator SpawnNotes()
    {
        while (!winCondition)
        {
            SpawnNote();
            yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));
        }
    }

    private void SpawnNote()
    {
        if (Random.Range(0f, 100f) < badNoteSpawnChance * minigameLevel / 2f && minigameLevel > 1)
        {
            //int randomIndex = Random.Range(0, spawnPoints.Count);
            //Vector2 spawnPosition = spawnPoints[randomIndex];
            //GameObject newNote = Instantiate(notePrefab, spawnPosition, Quaternion.identity);
            //newNote.name = "BadNote";
            //newNote.GetComponent<NoteRandomizer>().SetNoteSprites(badNoteVariations[Random.Range(0, badNoteVariations.Length)], colourVariations[Random.Range(0, colourVariations.Length)]); 
        }
        else
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Vector2 spawnPosition = spawnPoints[randomIndex];
            GameObject newNote = Instantiate(notePrefab, spawnPosition, Quaternion.identity);
            newNote.name = "Note";
            newNote.GetComponent<NoteRandomizer>().SetNoteSprites(noteVariations[Random.Range(0, noteVariations.Length)], colourVariations[Random.Range(0, colourVariations.Length)]);
        }
    }

}

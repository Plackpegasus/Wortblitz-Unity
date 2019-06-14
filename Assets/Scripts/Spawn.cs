using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawn : MonoBehaviour
{
    [Header("Spawn in s")]
    public Vector2 spawnRateMinMax;

    [Header("Enemy difficulty")]
    public Vector2 wordLengthEasyMedium;

    private int camWidth;
    private bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
        camWidth = Camera.main.pixelWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawning)
        {
            GameObject gameManager = GameObject.Find("Game Manager");
            Wordlist wordlist = gameManager.GetComponent<Wordlist>();

            int index = Random.Range(0, wordlist.wordlist.Count);
            string word = wordlist.wordlist[index];

            if (word.Length < wordLengthEasyMedium.x)
            {
                SpawnEnemy("easy", word);
            }
            else if (word.Length <= wordLengthEasyMedium.y)
            {
                SpawnEnemy("medium", word);
            }
            else if (word.Length > wordLengthEasyMedium.y)
            {
                SpawnEnemy("hard", word);
            }
            else
            {
                // some error or something idk
            }

            wordlist.wordlist.Remove(word);
        }
    }

    private void SpawnEnemy(string enemyType, string word)
    {
        float spawnpoint = Random.Range(-camWidth / 2f, camWidth / 2f) / 100;
        var enemy = Instantiate(Resources.Load("enemy_" + enemyType) as GameObject);

        enemy.GetComponent<Enemy>().text = word;
        enemy.transform.position = new Vector2(spawnpoint, 6);

        Debug.Log("type: " + enemyType + "\n\tspawnpoint: " + spawnpoint);
        StartCoroutine(WaitSpawn());
    }

    private IEnumerator WaitSpawn()
    {
        spawning = true;
        // process pre-yield
        yield return new WaitForSeconds(Random.Range(spawnRateMinMax.x, spawnRateMinMax.y));    // maybe use float if spawn rate is too consitent
        // process post-yield
        spawning = false;
    }
}

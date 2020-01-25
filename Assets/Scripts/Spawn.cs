using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Spawn in s")]
    public Vector2 spawnRateMinMax;

    [Header("Enemy difficulty")]
    public Vector2 wordLengthEasyMedium;

    private int score;
    private int camWidth;
    private bool spawning = false;
    private bool bossSpawned = false;
    private Wordlist wordlist;
    private Score scoreScript;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        camWidth = Camera.main.pixelWidth;
        gameManager = GameObject.Find("Game Manager");
        wordlist = gameManager.GetComponent<Wordlist>();
        scoreScript = gameManager.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        score = scoreScript.playerScore;

        if (!spawning)
        {
            int index = Random.Range(0, wordlist.wordlist.Count);
            string word = wordlist.wordlist[index];

            if (!bossSpawned && score > scoreScript.scoreToBoss)
            {
                Debug.LogWarning("Boss spawned");
                SpawnEnemy("boss", word);
                bossSpawned = true;
            }
            else
            {
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
                    Debug.LogError("couldn't spawn enemy with word " + word);
                }
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

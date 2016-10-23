using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    // Prefabs
    public GameObject prefabEnemy;
    public GameObject prefabAsteroid;
    public GameObject prefabPlayer;
    public GameObject prefabPlayerBullet;
    public GameObject prefabEnemyBullet;
    

    // Score
    public Text textPlayerScore;
    public int playerScore;
    public string textScore = "SCORE: ";

    // Timers
    float timerSpawnEnemey;
    float intervalSpawnEnemey = 3f;

    // Asteroids
    int totalAsteroids = 4;

    // Use this for initialization
    void Start () {
        // PlayerScore setup
        playerScore = 0;
        textPlayerScore.text = textScore + playerScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        IntervalSpawning(10);

        Asteroid[] asteroids = FindObjectsOfType<Asteroid>();
        //Debug.Log(asteroids.Length);

        if (asteroids.Length < totalAsteroids)
        {
            Debug.Log("No mas Ass");
            Instantiate(prefabAsteroid, new Vector2(Random.Range(-16, 9), Random.Range(100, 210)), Quaternion.identity);
        }
        
	}

    void UpdateScore(int points)
    {
        playerScore = playerScore + points;
        textPlayerScore.text = textScore + playerScore.ToString();
    }

    private void IntervalSpawning(float extra = 0f)
    {
        if (timerSpawnEnemey < Time.time)
        { //This checks wether real time has caught up to the timer
            // SPAWN
            UpdateScore(3);
           timerSpawnEnemey = Time.time + intervalSpawnEnemey + extra; //This sets the timer 3 seconds into the future
        }
    }
}

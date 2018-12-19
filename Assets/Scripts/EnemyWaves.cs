
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class EnemyWaves : MonoBehaviour {

    private int waveCount = 1;
    private float numberOfEnemies;
    public int maxEnemiesAtOnce;
    private float timeBetweenWavesCounter;
    public float timeBetweenWaves;
    public TextMeshProUGUI updateText;
    private int complexity = 0;
    private float searchCountdown = 1f;
    public Text roundNum;
    public Transform[] spawnPoints;
    public Transform[] enemies;




    // Use this for initialization
    void Start () {
        timeBetweenWavesCounter = timeBetweenWaves;

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Error No Spawn Points referenced");
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (waveCount == 5)
        {
            complexity = 2;
        }

        else if (waveCount == 10)
        {
            complexity = 3;
        }

        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            timeBetweenWaves -= Time.deltaTime;

            updateText.text = Mathf.Round(timeBetweenWaves).ToString();
            roundNum.text = "Round: " + waveCount;

            if (timeBetweenWaves <= 0)
            {
                updateText.gameObject.SetActive(false);
                Debug.Log("Wave" + waveCount);
                StartCoroutine(SpawnWave());
                timeBetweenWaves = timeBetweenWavesCounter;
            }

            else if (timeBetweenWaves > 0)
            {
                updateText.gameObject.SetActive(true);
            }
           

        }
    }

    IEnumerator SpawnWave()
    {
        numberOfEnemies =Mathf.Round(waveCount * 1.25F);
        
        for (int i = 0; i < numberOfEnemies; i++)
        {
           SpawnEnemy();
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == maxEnemiesAtOnce)
            {
               yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length< maxEnemiesAtOnce );
            }

            else
            {
                yield return new WaitForSeconds(1f);
            }

        }

        
        waveCount++;
        

    }


    void SpawnEnemy()
    {
        
      
            Instantiate(enemies[Random.Range(0, complexity)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, transform.rotation);

    }
}

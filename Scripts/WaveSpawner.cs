using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	public Transform enemyPrefab;
	public Transform spawnPoint;
	public Text waveCountdownText;
	public float timeBetweeenWaves = 5f;
	public float Countdown = 2f;
	int WaveIndex = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(Countdown <= 0f)
    	{
    		StartCoroutine(SpawnWave());
    		Countdown = timeBetweeenWaves;
    	}
    	
    	Countdown -= Time.deltaTime;

		Countdown = Mathf.Clamp(Countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", Countdown);
    }
    
    
    IEnumerator SpawnWave()
    {
    	for (int i = 0 ; i < WaveIndex ; i++)
    	{
    		SpawnEnemy();
    		yield return new WaitForSeconds(0.5f);
    	}
    	
    	WaveIndex++;
    }
    
    
    void SpawnEnemy()
    {
    	
    	Instantiate(enemyPrefab , spawnPoint.position , spawnPoint.rotation);
    }
}

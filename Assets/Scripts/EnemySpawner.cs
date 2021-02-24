using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemiesWave1, enemiesWave2, enemiesWave3;
	private GameObject spawnPoint;
	public int waveCounter = 1;

	public bool waveInProgress = false;

	// Use this for initialization
	void Start () {
		//find the spawn point in the scene.
		spawnPoint = GameObject.Find("_EnemySpawnPoint");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if both the space bar and waves are not happening, start spawning the enemies.
		if (Input.GetKeyDown(KeyCode.Space) && !waveInProgress)
		{
			StartCoroutine(StartSpawning(2));
			waveInProgress = true;
		}
	}


	IEnumerator StartSpawning (float delay)
	{
		//Checks if the wave counter is equal to 1.
		if (waveCounter == 1)
		{
			for (int i = 0; i < enemiesWave1.Length; i++)
			{
				//if the length of the wave has 1 left, wait 10 seconds then add 1 to the wave counter.
				if (i == (enemiesWave1.Length -1))
				{
					yield return new WaitForSeconds(10);
					waveCounter++;
				}
				else
				{
					//if there is more than 1 left, then spawn the enemies at this location randomly, with a 2 second delay between each spawn.
					Instantiate(enemiesWave1[Random.Range(0, 2)], this.transform.position, transform.rotation);
					yield return new WaitForSeconds(2);
				}
			}
		}

		//Checks if the wave counter is equal to 2.
		if(waveCounter == 2)
		{
			for (int i = 0; i < enemiesWave2.Length; i++)
			{
				if (i == (enemiesWave2.Length -1))
				{
					//if the length of the wave has 1 left, wait 10 seconds then add 1 to the wave counter.
					yield return new WaitForSeconds(10);
					waveCounter++;
				}
				else
				{
					//if there is more than 1 left, then spawn the enemies at this location randomly, with a 2 second delay between each spawn.
					Instantiate(enemiesWave2[Random.Range(0,5)], spawnPoint.transform.position, spawnPoint.transform.rotation);
					yield return new WaitForSeconds(2);
				}
			}
		}

		//Checks if the wave counter is equal to 3.
		if(waveCounter == 3)
		{
			for (int i = 0; i < enemiesWave3.Length; i++)
			{
				if (i == (enemiesWave3.Length -1))
				{
					//if the length of the wave has 1 left, stop the waves by setting it to false..
					waveInProgress = false;
				}
				else
				{
					//if there is more than 1 left, then spawn the enemies at this location randomly, with a 2 second delay between each spawn.
					Instantiate(enemiesWave3[Random.Range(0,10)], spawnPoint.transform.position, spawnPoint.transform.rotation);
					yield return new WaitForSeconds(2);
				}
			}
		}
	}
}

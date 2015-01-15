using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave02 : MonoBehaviour {
	
	private int _WaveCount = 0;
	private float _AmountWave = 1;
	private int _TimeNextWave = 30;
	public GameObject SpawnPoints;
	public List<GameObject> Enemies = new List<GameObject> ();
	public AudioClip newWaveSound;


	void Start()
	{
		StartCoroutine(SpawnWave());
	}

	IEnumerator SpawnWave()
	{
		yield return new WaitForSeconds (_TimeNextWave);
		Wave ();
		audio.PlayOneShot(newWaveSound);
	}

	IEnumerator SpawnEnemy(float _seconds){
		yield return new WaitForSeconds (_seconds);
		Instantiate(Enemies[Random.Range(0, Enemies.Count)], SpawnPoints.transform.position,
		            SpawnPoints.transform.rotation);
	}

	void Wave(){
		for(int k = 0; k < _AmountWave; k++)
		{
			StartCoroutine(SpawnEnemy(1f * k));
		}

		_AmountWave = _AmountWave + 2;
		_WaveCount = _WaveCount + 1;
		StartCoroutine(SpawnWave());
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave01 : MonoBehaviour {

	[SerializeField]
	private float _AmountWave = 2;
	private int _TimeNextWave = 10;
	public int _WaveCount = 0;
	public GameObject SpawnPoints;
	public List<GameObject> enemies = new List<GameObject> ();
	public AudioClip newWaveSound;
	public GameObject[] newEnemy;
	
	void Start()
	{
		StartCoroutine(SpawnWave());
	}

	IEnumerator SpawnWave()
	{
		yield return new WaitForSeconds (_TimeNextWave);
		if(_WaveCount == 5)
		{
			enemies.Add(newEnemy[0]);
		}
		if(_WaveCount == 10)
		{
			enemies.Add(newEnemy[1]);
		}
		if(_WaveCount == 15)
		{
			enemies.Add(newEnemy[2]);
		}
		Wave ();
		audio.PlayOneShot(newWaveSound);
	}
	
	IEnumerator SpawnEnemy(float _seconds){
		yield return new WaitForSeconds (_seconds);
		Instantiate(enemies[Random.Range(0, enemies.Count)], SpawnPoints.transform.position,
		            SpawnPoints.transform.rotation);
	}
	
	void Wave(){
		for(int k = 0; k < _AmountWave; k++)
		{
			StartCoroutine(SpawnEnemy(1f * k));
		}
		
		_AmountWave = _AmountWave + 1;
		_WaveCount = _WaveCount + 1;
		StartCoroutine(SpawnWave());
	}
}

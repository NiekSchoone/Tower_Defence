using UnityEngine;
using System.Collections;

public class WaveTest02 : MonoBehaviour {
	
	private int _WaveCount = 1;
	//private int _EnemyCount = 0;
	private float _AmountWave = 2;
	private int _TimeNextWave = 10;
	public GameObject SpawnPoints;
	public GameObject Enemy01;
	//public bool NextWave = true;


	void Start(){
		StartCoroutine(SpawnWave());
	}

<<<<<<< HEAD
	IEnumerator SpawnWave()
	{
		yield return new WaitForSeconds (_TimeNextWave);
		Wave ();
	}

	IEnumerator SpawnEnemy(float _seconds){
		yield return new WaitForSeconds (_seconds);
		Instantiate(Enemy01, SpawnPoints.transform.position,
		            SpawnPoints.transform.rotation);
=======
	IEnumerator SpawnEnemy(){
			for(int i = 0; i < _AmountWave; i++)
			{
				Instantiate(Enemy01, SpawnPoints.transform.position,
				            SpawnPoints.transform.rotation);
				_WaveCount++;
				NextWave = true;
				//Debug.Log(_AmountWave);
				yield return new WaitForSeconds (1);
		}
>>>>>>> origin/master
	}

	void Wave(){
		for(int k = 0; k < _AmountWave; k++)
		{
			StartCoroutine(SpawnEnemy(1f * k));
		}

		_AmountWave = _AmountWave + 1;
		StartCoroutine(SpawnWave());
	}
}

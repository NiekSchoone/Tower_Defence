using UnityEngine;
using System.Collections;

public class WaveTest02 : MonoBehaviour {
	
	private int _WaveCount = 1;
	//private int _EnemyCount = 0;
	private int _AmountWave = 50;
	public GameObject SpawnPoints;
	public GameObject Enemy01;


	void Start(){
		StartCoroutine(SpawnEnemy());
	}

	IEnumerator SpawnEnemy(){
			for(int i = 0; i < _AmountWave; i++)
			{
				Instantiate(Enemy01, SpawnPoints.transform.position,
				            SpawnPoints.transform.rotation);
				_WaveCount++;
				yield return new WaitForSeconds (1);
		}
	}
}

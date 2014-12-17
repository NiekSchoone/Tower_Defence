using UnityEngine;
using System.Collections;

public class WaveTest02 : MonoBehaviour {
	
	private int _WaveCount = 1;
	//private int _EnemyCount = 0;
	private int _AmountWave = 10;
	public GameObject SpawnPoints;
	public GameObject Enemy01;
	public bool NextWave;


	void Start(){
		StartCoroutine(SpawnEnemy());
	}

	IEnumerator SpawnEnemy(){
			for(int i = 0; i < _AmountWave; i++)
			{
				Instantiate(Enemy01, SpawnPoints.transform.position,
				            SpawnPoints.transform.rotation);
				_WaveCount++;
				NextWave = true;
				Debug.Log(_AmountWave);
				yield return new WaitForSeconds (1);
		}
	}
	IEnumerator WitchWave(){
		if(NextWave == true){
			_AmountWave++;
			yield return new WaitForSeconds(1);
		}
	}
}

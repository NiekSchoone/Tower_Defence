using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveCount : MonoBehaviour {

	public GameObject EnemieSpawner;

	private int _wavecounter;
	[SerializeField]
	private Text _wave;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_wavecounter = EnemieSpawner.gameObject.GetComponent<Wave01>()._WaveCount;
		_wave.text = "Wave: " + _wavecounter.ToString();
	}
}

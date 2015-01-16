using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinGUI : MonoBehaviour {

	private int _coinCounter;
	[SerializeField]
	private Text _Counter;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		_coinCounter = Camera.main.gameObject.GetComponent<GoldScript> ().playerOwnedCoin;
		_Counter.text = _coinCounter.ToString();
	}
}

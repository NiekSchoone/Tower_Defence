using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinGUI : MonoBehaviour {

	private int coinCounter;
	[SerializeField]
	private Text Counter;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		coinCounter = Camera.main.gameObject.GetComponent<GoldScript> ().playerOwnedCoin;
		Counter.text = coinCounter.ToString();
	}
}

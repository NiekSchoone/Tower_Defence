using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	[SerializeField]
	private Slider _healthBar;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	public void UpdateHealth (float Damage) 
	{
		_healthBar.value = Damage;
	}
	
}

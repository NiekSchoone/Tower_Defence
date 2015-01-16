using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/**
* ...
* @author Niek Schoone
**/

public class TowerClass : MonoBehaviour
{
	public int towerPrice;

	public AudioClip shootSound;

	[SerializeField]
	protected LayerMask EnemyLayer;
	protected float radius;

	protected GameObject target;

	[SerializeField]
	protected GameObject ammo;

	protected float fireRate;

	protected float coolDown = 3f;

	protected float projectileSpeed;

	[SerializeField]
	protected Collider2D[] enemyTargetingArray;

	protected Vector2 origin;

	public RadiusIndicator radiusIndication;

	[SerializeField]
	protected Sprite[] upgradeSprites;
	public bool towerLevel1 = true;
	public bool towerLevel2 = false;
	public bool towerLevel3 = false;
	public int towerLevel = 0;

	protected SpriteRenderer towerSpriteRenderer;

	public Animator shootAnim;
	
	protected virtual void Awake()
	{
		this.enabled = false;
		shootAnim.GetComponentInChildren<Animator>();
		towerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
		radiusIndication = GetComponent<RadiusIndicator>();
	}

	protected virtual void Update()
	{
		EnemiesEnter();

		radiusIndication.indicatedRadius = radius;

		if(enemyTargetingArray.Length > 0)
		{
			TargetEnemy();
		}
		if(enemyTargetingArray.Length < 1)
		{
			target = null;
		}
		if(Time.time >= coolDown)
		{
			AttackEnemy();
		}
	}

	protected void EnemiesEnter()
	{
		origin = new Vector2(transform.position.x, transform.position.y);
		enemyTargetingArray = Physics2D.OverlapCircleAll(origin, radius, EnemyLayer);
		for (int i = 0; i < enemyTargetingArray.Length; i++) 
		{
			if(enemyTargetingArray[i].transform.position.x < enemyTargetingArray[0].transform.position.x)
			{
				enemyTargetingArray[0] = enemyTargetingArray[i];
			}
		}
	}
	
	protected virtual void TargetEnemy()
	{
		target = enemyTargetingArray[0].gameObject;
	}

	public void UpgradeTower()
	{
		if(towerLevel2 == true)
		{
			towerLevel = 1;
			coolDown -= 0.1f;
			projectileSpeed += 10;
			radius += 0.1f;

		}else if(towerLevel3 == true)
		{
			towerLevel = 2;
			coolDown -= 0.1f;
			projectileSpeed += 10;
			radius += 0.1f;
		}
		Debug.Log (towerLevel);
		towerSpriteRenderer.sprite = upgradeSprites[towerLevel];
	}

	protected virtual void AttackEnemy()
	{

		if(target != null)
		{
			Vector2 myPos = new Vector2(this.transform.position.x, this.transform.position.y);
			Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
			Vector2 fireAt = targetPos - myPos;
			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( fireAt.y, fireAt.x ) * Mathf.Rad2Deg);
			GameObject projectile = (GameObject)Instantiate(ammo, transform.position, rotation);
			projectile.rigidbody2D.AddForce(fireAt * projectileSpeed);
			coolDown = Time.time + fireRate;
			shootAnim.SetBool("IsShooting", true);
		}
		if(target == null)
		{
			shootAnim.SetBool("IsShooting", false);
		}
	}	
}

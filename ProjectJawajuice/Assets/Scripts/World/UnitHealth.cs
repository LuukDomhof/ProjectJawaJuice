using UnityEngine;
using System.Collections;

public class UnitHealth : MonoBehaviour {
	
	public float maxHealth = 100f;
	
	private float currentHealth;
	
	void Start()
	{
		currentHealth = maxHealth;
	}
	
	public void TakeDamage(float amount)
	{
		currentHealth -= amount; //TODO Trigger Animation
		
		if (currentHealth <= 0f)
		{
			Death ();
		}
	}
	
	void Death()
	{
		//TODO Trigger Animation, possibly disable Scripts etc.
	}
}

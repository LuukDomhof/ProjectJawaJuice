using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

	public float delay = 0.5f;
	public float meleeDamage;

	private float timer;


	void Update()
	{
		timer += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) //TODO Animate Trigger in Attack animation & Trigger Animation in Player Controller
	{
		if (other.gameObject.tag == "Enemy" && timer > delay) //Note: tag comparison depending on who Script is attached to --- TODO manage attackSpeed in Player Controller
		{
			other.GetComponent<UnitHealth>().TakeDamage(meleeDamage);
			timer = 0f;
		}
	}
}

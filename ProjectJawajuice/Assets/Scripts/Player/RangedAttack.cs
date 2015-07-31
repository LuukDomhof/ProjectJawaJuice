using UnityEngine;
using System.Collections;

public class RangedAttack : MonoBehaviour {

	public GameObject weapon;
	public float rangedDamage;

	public void Shoot()
	{
		Vector3 fwd = weapon.transform.TransformDirection (Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast (weapon.transform.position, fwd, out hit, 100))
		{
			if(hit.transform.tag == "Enemy") //Tag comparison depending on where the script is placed on
			{
				hit.transform.GetComponent<UnitHealth>().TakeDamage(rangedDamage);
			}
		}
	}
}

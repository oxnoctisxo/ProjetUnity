using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour {

	public int damage;

	void OnTriggerEnter(Collider col) {
        try { 
        if (gameObject.tag == col.tag)
            return;
        } catch  {        }

        try
        {
            if (col.tag == "Invincible")
                return;
        }
        catch { }
		HealthManager healthMan = col.gameObject.GetComponentInParent<HealthManager> ();
		if (healthMan) {
			healthMan.TakeDamage (damage);
		}
	}

}

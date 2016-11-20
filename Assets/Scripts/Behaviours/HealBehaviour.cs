using UnityEngine;
using System.Collections;
[CreateAssetMenu(menuName="Behaviours/Heal Behaviour")]
public class HealBehaviour : AbstractBehaviour {

	public int healAmount;

	public override void Execute (GameObject targetObject)
	{
		HealthManager healthMan = targetObject.GetComponentInChildren<HealthManager> ();
		if (healthMan) {
			healthMan.Heal (healAmount);
		}
	}
		

}

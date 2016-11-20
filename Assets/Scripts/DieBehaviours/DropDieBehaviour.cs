using UnityEngine;
using System.Collections;

public class DropDieBehaviour : AbstractDieBehaviour {

	public DropTable dropTable;

	public override void Die (GameObject deadObject)
	{
		Drop ();
	}

	public GameObject Drop() {
		GameObject drop = dropTable.Drop ();
		if (drop != null) {
			drop = ObjectPoolsManager.GetInstance ().GetObject (drop);
			drop.transform.position = transform.position;
		}
		return drop;
	}
}

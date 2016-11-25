using UnityEngine;
using System.Collections;

public class DropDieBehaviour : AbstractAsyncDieBehaviour
{

	public DropTable dropTable;

	public override void Die (GameObject deadObject)
	{
		Drop ();
        isFinished = true;
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

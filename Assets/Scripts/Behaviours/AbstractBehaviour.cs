using UnityEngine;
using System.Collections;

public abstract class AbstractBehaviour : ScriptableObject {

	public abstract void Execute (GameObject targetObject);

}

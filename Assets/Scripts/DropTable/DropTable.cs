using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class DropTable : ScriptableObject {

	public DropTableElement[] dropTable;

	private int totalWeight;

	void OnEnable () {
		if(dropTable != null) {
			totalWeight = 0;
			foreach (var item in dropTable) {
				totalWeight += item.weight;
			}

		}
	}

	public GameObject Drop() {
		int roll = (int)(Random.value * (totalWeight + 1));
		int cursor = 0;
		foreach (var item in dropTable) {
			cursor += item.weight;
			if (cursor >= roll) {
				return item.prefab;
			}
		}
		return null;
	}

}
[System.Serializable]
public class DropTableElement {
	public GameObject prefab;
	public int weight;
}
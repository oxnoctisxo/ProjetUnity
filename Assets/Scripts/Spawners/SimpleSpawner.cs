using UnityEngine;
using System.Collections;

public class SimpleSpawner : MonoBehaviour {

	public GameObject prefab;
	public GameObject parentObject;
	public bool useParentObjectLayer;

    public float spawnInterval = 0.15f;
    public float range = 100f;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    float effectsDisplayTime = 0.2f;


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= spawnInterval && Time.timeScale != 0)
        {
            Spawn();
        }

        if (timer >= spawnInterval * effectsDisplayTime)
        {
            DisableEffects();
        }
    }
    public void DisableEffects()
    {
    //    gunLine.enabled = false;
     //   gunLight.enabled = false;
    }
	public virtual GameObject Spawn() {
        timer = 0f;


        //Jouer les sons .

		GameObject instance = ObjectPoolsManager.GetInstance().GetObject(prefab);
		instance.transform.position = transform.position;
		instance.layer = gameObject.layer;

		if (parentObject) {
			instance.transform.SetParent (parentObject.transform);
			if (useParentObjectLayer) {
				instance.layer = parentObject.layer;
			}
		}

        if (!instance.GetComponent<DirectionalMovement>())
            instance.AddComponent<DirectionalMovement>();
        if (!instance.GetComponent<PoolAfterXSeconds>())
            instance.AddComponent<PoolAfterXSeconds>();
        DirectionalMovement direction = instance.GetComponent<DirectionalMovement>();
        PoolAfterXSeconds dieAfter = instance.GetComponent<PoolAfterXSeconds>();


        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        direction.direction = shootRay.direction;
        direction.speed = 10;

        dieAfter.delay = range / (direction.speed*5);
        return instance;

	}

}

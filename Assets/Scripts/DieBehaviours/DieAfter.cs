using UnityEngine;
using System.Collections;

public class DieAfter : MonoBehaviour
{

    public float timeLeft;

    float startTime;
	
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            HealthManager healthMan = GetComponent<HealthManager>();
            healthMan.TakeDamage(healthMan.initHealth);
        }


	}
}

using UnityEngine;
using System.Collections;

public class ZizagBehaviour : MonoBehaviour {

    public int speed;
    public Vector3 direction;
    public float distance ;

    float distanceInitial;
    int sens;


    void Awake()
    {
        distanceInitial = distance;
        sens = 1;
    }

    // Update is called once per frame
    void Update()
    {
        distance -= Time.deltaTime;

        if (distance <= 0)
        {
            sens *= -1;
            distance = distanceInitial;
            transform.Rotate(direction , 180f);
        }
        transform.Translate(direction.normalized * sens * speed * Time.deltaTime, Space.World);
    }

    
}

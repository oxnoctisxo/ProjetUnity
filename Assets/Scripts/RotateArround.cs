using UnityEngine;
using System.Collections;

public class RotateArround : MonoBehaviour {
    public int elementCounts;
    private int elementsAtStart;
    public int speed;
    public int heigth;
  
    public GameObject prefab;
    private GameObject[] objects;

    HealthManager healthMan;
    // Use this for initialization
    void Awake()
    {
        if (!prefab)
        {
            gameObject.SetActive(false);
            return;
        }

     healthMan = GetComponentInParent<HealthManager>();

        
        elementCounts = healthMan.initHealth/100;
        objects = new GameObject[elementCounts];
        for (int i = 0; i < elementCounts; i++)
        { 
            objects[i] = (GameObject) Instantiate(prefab, transform);
            objects[i].transform.localPosition = new Vector3(1, Random.Range(0,2), 1);
        }
        elementsAtStart = elementCounts;
    }

    // Update is called once per frame
    void Update()
    {
        elementCounts = healthMan.initHealth/100;
        for (int i = elementCounts; i < elementsAtStart; i++)
        {
            objects[i].SetActive(false);
        }
        for (int i = 0; i < elementCounts; i++)
        {
            objects[i].SetActive(true);
        }

        for (int i = 0; i < elementCounts; i++)
        {
            objects[i].transform.RotateAround(transform.position, Vector3.up, (speed + i*speed/2) * Time.deltaTime);
        }
    }

  
}

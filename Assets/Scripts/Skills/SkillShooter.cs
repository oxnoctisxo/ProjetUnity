using UnityEngine;
using System.Collections;

public class SkillShooter : MonoBehaviour {
    public GameObject prefab;
    public GameObject parentObject;
    public bool useParentObjectLayer;
    public string input;

    public float spawnInterval = 0.15f;
    public float range = 100f;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    Animator anim;
    bool isAttacking;

    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        isAttacking = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        //Lancer l'animation d'attaque .
        anim.SetBool("IsAttacking", isAttacking);
        if (input == "")
            input = "Fire1";
        if (Input.GetButton(input) && timer >= spawnInterval && Time.timeScale != 0)
        {
            isAttacking = true;
            Spawn();
        }
        else
        {
            if( timer >= 1f)
            isAttacking = false;
        }

    }

    public virtual GameObject Spawn()
    {
        timer = 0f;
        //Jouer les sons .

        GameObject instance = ObjectPoolsManager.GetInstance().GetObject(prefab);
        instance.transform.position = transform.position;
        instance.layer = gameObject.layer;

        if (parentObject)
        {
            instance.transform.SetParent(parentObject.transform);
            if (useParentObjectLayer)
            {
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

        dieAfter.delay = range / (direction.speed * 5);
        return instance;

    }
}

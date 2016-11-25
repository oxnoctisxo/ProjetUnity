using UnityEngine;
using System.Collections;

public class SkillShooter : MonoBehaviour {
    public GameObject prefab;
    public GameObject parentObject;
    public bool useParentObjectLayer;
    public string input;
    public int speed;
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
        DirectionalMovement directionalMove = instance.GetComponent<DirectionalMovement>();
        PoolAfterXSeconds dieAfter = instance.GetComponent<PoolAfterXSeconds>();


        shootRay.origin = transform.parent.position;
        shootRay.direction = transform.parent.forward;
        directionalMove.direction = shootRay.direction;
        directionalMove.speed = speed;

        dieAfter.delay = range / (directionalMove.speed * 5);
        return instance;

    }
}

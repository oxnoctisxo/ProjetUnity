using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    NavMeshAgent nav;
    HealthManager healtMan;
    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        healtMan = GetComponent<HealthManager>();
        nav = GetComponent <NavMeshAgent> ();

    }


    void Update ()
    {

  
        if(!healtMan.IsDead())
        {
            nav.SetDestination (player.position);
        }
        else
        {
            nav.enabled = false;
           
        }
    }
}

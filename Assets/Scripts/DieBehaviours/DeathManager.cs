using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Asynchrone
public class DeathManager : MonoBehaviour
{

    public EventsManager eventsManager;

    public List<AbstractAsyncDieBehaviour> dieBehaviours;

    int indice;
    bool isDying;
    void Awake()
    {
        if (!eventsManager)
        {
            eventsManager = GetComponentInParent<EventsManager>();
        }
        foreach (var item in GetComponentsInChildren<AbstractAsyncDieBehaviour>())
        {
            item.isFinished = false;
            dieBehaviours.Add(item);
            
        }
        indice = 0;
        isDying = false;
    }

    void OnEnable()
    {
        eventsManager.OnDie += Die;
    }

    void OnDisable()
    {
        eventsManager.OnDie -= Die;
    }


    void Update()
    {
        if (!isDying)
        {
            return;
        }
        if (indice > dieBehaviours.Count)
        {
            indice = 0;
            isDying = false;
            return;
        }
        if (dieBehaviours[indice].IsFinished())
        {
            dieBehaviours[indice].isFinished = false;
            indice++;
            if (indice < dieBehaviours.Count)
                dieBehaviours[indice].Die(gameObject);
        }
    }
    void Die()
    {
        isDying = true;
        indice = 0;
        dieBehaviours[indice].Die(gameObject);
    }
}
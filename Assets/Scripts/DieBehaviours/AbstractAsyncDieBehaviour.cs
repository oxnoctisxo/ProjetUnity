using UnityEngine;
using System.Collections;

public abstract class AbstractAsyncDieBehaviour : MonoBehaviour
{
    public bool isFinished = false;
    public abstract void Die(GameObject deadObject);


    public  bool IsFinished()
    {
        return isFinished;
    }
}
using UnityEngine;
using System.Collections;

public class AnimatedDieBehaviour : AbstractDieBehaviour
{

     Animator anim;

    public override void Die(GameObject deadObject)
    {
        Debug.Log("in");
        anim = GetComponentInParent<Animator>();
        if (!anim)
            return;
        Debug.Log("in2");
        string oldTag = deadObject.tag;
        deadObject.tag = "Invincible";
        anim.SetTrigger("Dead");
        for (int i = 0; i < 100000000; i++)
            Debug.Log("in3");
        deadObject.tag = oldTag;
    }
}
using UnityEngine;
using System.Collections;

public class AnimatedDieBehaviour : AbstractAsyncDieBehaviour
{

     Animator anim;
    string oldTag;

    public override void Die(GameObject deadObject)
    {
        anim = GetComponentInParent<Animator>();
       if (anim == null)
            return;

        oldTag = deadObject.tag;
       deadObject.tag = "Invincible";
       
       StartCoroutine(WaitForAnimationToEnd(deadObject));
     ;
       
    }

    IEnumerator WaitForAnimationToEnd(GameObject deadObject)
    {
        anim.SetTrigger("Dead");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        deadObject.tag = oldTag;
        isFinished = true;
    }
}
using UnityEngine;
using System.Collections;

public class AnimatedDieBehaviour : AbstractDieBehaviour
{

     Animator anim;
     bool done;

    public override void Die(GameObject deadObject)
    {
       Debug.Log("in");
        anim = GetComponentInParent<Animator>();
       if (anim == null)
            return;
       done = false;
       string oldTag = deadObject.tag;
       deadObject.tag = "Invincible";
       anim.SetTrigger("Dead");
       StartCoroutine(DoAnimation()); 
     

       
        Debug.Log("in2");
        deadObject.tag = oldTag;
    }

    IEnumerator DoAnimation()
    {
        
        yield return new WaitForSeconds(1f); // wait for two seconds.
        done = true;
        //Debug.Log("This happens 2 seconds later. Tada.");
    }
}
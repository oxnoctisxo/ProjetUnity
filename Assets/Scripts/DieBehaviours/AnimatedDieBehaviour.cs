using UnityEngine;
using System.Collections;

public class AnimatedDieBehaviour : AbstractDieBehaviour
{

     Animator anim;


    public override void Die(GameObject deadObject)
    {
       Debug.Log("in");
        anim = GetComponentInParent<Animator>();
       if (anim == null)
            return;

       string oldTag = deadObject.tag;
       deadObject.tag = "Invincible";
       anim.SetTrigger("Dead");
    
     

       
        Debug.Log("in2");
        deadObject.tag = oldTag;
    }

  
}
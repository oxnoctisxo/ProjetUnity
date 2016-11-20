using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	public int initHealth;
	private int currentHealth;
   //  float sinkSpeed = 2.5f;
	public EventsManager eventsManager;

         
    public AudioClip deathClip;



  //  Animator anim;                              // Reference to the animator.
 //   AudioSource enemyAudio;                     // Reference to the audio source.
    ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
   CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
  //  bool isDead;                                // Whether the enemy is dead.
  //  bool isSinking;                             // Whether the enemy has started sinking through the floor.

	void Awake() {
		if (!eventsManager) {
			eventsManager = GetComponentInParent<EventsManager> ();
		}
		currentHealth = initHealth;

       // anim = GetComponent<Animator>();
       // enemyAudio = GetComponent<AudioSource>();
       // hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = initHealth;

	}

	public void TakeDamage(int damage) {
		initHealth -= damage;
		if (initHealth <= 0) {
			Die();
		}
	}

	public void Heal(int healAmount) {
		initHealth = Mathf.Min (initHealth + healAmount, currentHealth);
	}


	void Die() {
		eventsManager.Die ();
	}

	void OnEnable() {
		initHealth = currentHealth;
	}

}

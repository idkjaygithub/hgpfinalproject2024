using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;

    public int damage;

    public EnemyFollow enemyHealthComponent;

    public int enemyHealth;
    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (target != null) // If this enemy has a target to follow...
        {
            agent.SetDestination(target.position); // Set that target's current position as this enemy's destination
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // If this object this enemy just hit is the player...
        {
            AudioManager.Instance.PlaySound("Death"); // Play this sound when death
            // Despawn the player and tell the GameManager to reset the current level
            Destroy(other.gameObject);
            GameManager.Instance.GameOver();
        }
    }

    private void EnemyDeath()
    {
        EnemyFollow enemyHealthComponent = this.gameObject.GetComponent<EnemyFollow>();

        if (enemyHealthComponent != null && enemyHealthComponent.enemyHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

}

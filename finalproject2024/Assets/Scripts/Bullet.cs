using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    void Start()
    {
        Destroy(gameObject, life);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            AudioManager.Instance.PlaySound("EnemyDeath");
            Destroy(other.gameObject);
        }
    }
}

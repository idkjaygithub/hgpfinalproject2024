using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaReveal : MonoBehaviour
{
    [SerializeField] private Animator santaReveal = null;

    [SerializeField] private bool openTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(openTrigger)
            {
                santaReveal.Play("SantaReveal", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
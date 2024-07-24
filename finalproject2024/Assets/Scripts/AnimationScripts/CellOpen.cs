using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController2 : MonoBehaviour
{
    [SerializeField] private Animator cellOpen = null;

    [SerializeField] private bool openTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(openTrigger)
            {
                cellOpen.Play("CellOpen", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
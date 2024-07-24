using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCellOpen : MonoBehaviour
{
    [SerializeField] private Animator topCellBars = null;

    [SerializeField] private bool openTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(openTrigger)
            {
                topCellBars.Play("TopCellBars", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}

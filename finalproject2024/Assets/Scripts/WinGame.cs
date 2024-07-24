using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private bool winTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(winTrigger)
            {
                GameManager.Instance.WinGame();
                AudioManager.Instance.PlaySound("WinGame");
            }
        }
    }
}
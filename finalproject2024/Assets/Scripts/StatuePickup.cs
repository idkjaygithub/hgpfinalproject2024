using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuePickup : MonoBehaviour
{
    // HOW IT WORKS!!
    // 1. Detect collisions
    // 2. Identify objects colliding with this
    // 3. Destroy this if the colliding object is the player
    // 4. Every frame, update the rotation of this to attract the player

    public int pointValue = 1; // A variable to store how many points this pickup is worth

    private bool pickedUp = false;

    // This function is called whenever this collider collides with another marked as a trigger (this object can be the trigger)
    private void OnTriggerEnter (Collider other)
    {
        if (pickedUp) return; // We do not want to do anything if this pickup is already collected by the player

        if (other.gameObject.CompareTag("Player")) // if the collider this pickup just hit has the tag "Player"
        {
            AudioManager.Instance.PlaySound("Collect Money"); // Play this sound when collected
            GameManager.Instance.UpdateScore(pointValue); // tell the GameManager to update the score by 1
            GameManager.Instance.totalPickups -= 1; // tell the game manager to subtract from the total # of pickups
            Destroy(this.gameObject); // destroy this pickup
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Create a singleton for this target
    public static GameManager Instance {get; private set;}

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI objectiveText;

    public int score = 0; // A var to track the player's current points

    public GameObject pickupParent; // A var to hold the pickup parent game object; this is used to count our pickups // Assign in editor

    public int totalPickups = 0;

    private PlayerControls player;

    public GameObject victoryText; // a var to hold victory text

    private void Awake()
    {
        if (Instance == null) // If there is no other copy of this script in the scene...
        {
            Instance = this; // "This" refers to itself
        }else // This is NOT the only copy of the GameManager script in the scene...
        {
            // delete this extra copy of this script
            Debug.LogWarning("Cannot have more than one instance of [GameManager] in the scene! Deleted extra copy");
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        score = 0; // Reset the score back to 0 every time the game starts
        UpdateScoreText();

        victoryText.SetActive(false);

        totalPickups = pickupParent.transform.childCount; // Disabled the victory text when the game starts

        // Count how many pickups are in the level
        // Count how many pickups are in the game
    }

    public void UpdateScore(int amount)
    {
        // Increase the score variable by amount given
        score = score + amount;
        UpdateScoreText();

        if(totalPickups <=0) // If there are no more pickups in the level...
        {

            WinGame(); // win the game
        }
    }

    public void UpdateObjectiveText()
    {
        objectiveText.text = "Objective: ✅";
    }

    public void UpdateScoreText()
    {
        // string // int
        scoreText.text = "Score: " + score.ToString(); 
        // updates the score text from the player's score    
    }

    public void WinGame()
    {
        victoryText.SetActive(true); // enable our victory text
        UpdateObjectiveText();
        GameOver();
    }

    public void GameOver()
    {
        Invoke("LoadCurrentLevel", 2f);
    }

    private void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoseGame()
    {
        if(player.health <= 0);
        {
            GameOver();
        }
    }

}
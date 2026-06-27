using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameHasEnded = false;

    public Rigidbody rb;

    public float RestartDelay = 2f;

    public float NextLevelDelay = 2f;

    public GameObject CompleteLevelUI;

    public PlayerMovement movement;


    private bool isLevelComplete = false;

    public void CompleteLevel()
    {
        isLevelComplete = true;
        movement.enabled = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        CompleteLevelUI.SetActive(true);
        Invoke("nextLevel", NextLevelDelay);
    }

    public void EndGame()
    {
        if (GameHasEnded == false && !isLevelComplete)
        {
            GameHasEnded = true;
            movement.enabled = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Debug.Log("Game Over!!");
            Invoke("Restart", RestartDelay);
        }
        
    }

    void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}

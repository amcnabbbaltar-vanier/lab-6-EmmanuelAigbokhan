using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public Text scoreText;
    public int score = 0;


    private void Awake()
    {
        // Enforce one instance
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }


    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }
        public void LoadNextScene()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }
        void Die()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(1);
            GameManager.Instance.LoadNextScene();
        }
    }

}





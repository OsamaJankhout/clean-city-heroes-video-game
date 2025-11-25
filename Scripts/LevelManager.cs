using UnityEngine;
using UnityEngine.SceneManagement; 
public class LevelManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI timerText;
    public GameObject endPanel;
    public TMPro.TextMeshProUGUI endScore;

    public int totalTrash;
    public float timeLimit = 90f;

    int score = 0;
    
    float t; 
    bool running = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(endPanel) endPanel.SetActive(false);

        if (totalTrash == 0)
            totalTrash = GameObject.FindGameObjectsWithTag("Trash").Length;
        UpdateUI();
    }

    public void BeginLevel()
    {
        t = timeLimit;
        running = true;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (!running) return; 
        t-= Time.deltaTime;
        if (t <= 0f)
        {
            t = 0f;
            Lose();
            return;
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText) scoreText.text = $"score: {score}";
        if (timerText) timerText.text = $"time: {Mathf.CeilToInt(t)}";
    }

    public void AddScore(int v)
    {
        score += v;
        UpdateUI();
    }

    public void OnTrashCollected()
    {
        
        if(totalTrash == 0)
        {
            Win();
        }
    }

    void Win()
    {
        running  = false;
        int timeBonus = Mathf.CeilToInt(t);
        score += timeBonus;
        ShowEnd(score);
    }

    void Lose()
    {
        running = false;
        ShowEnd(score);
    }

    void ShowEnd(int s)
    {
        if (endPanel) endPanel.SetActive(true);
        if (endScore) endScore.text = $"score: {s}";
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI missionText;
    public GameObject quiz;
    public string nextScene = "level1";

    bool area1, area2, area3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MissionText();
        if (quiz) quiz.SetActive(false);
    }

    public void Visited(string id)
    {
        if (id == "area1") area1 = true;
        if (id == "area2") area2 = true;
        if (id == "area3") area3 = true;

        MissionText();

        if (area1 && area2 && area3)
        {
            if (quiz) quiz.SetActive(true);
        }
    }
    void MissionText()
    {
        int count = 0;
        if (area1) count++;
        if (area2) count++;
        if (area3) count++;
        if (missionText) missionText.text = $"Investigate the city: ({count}/3) locations";
    }

    public void PickWrong()
    {
        var ft = quiz.GetComponentInChildren<TMPro.TextMeshProUGUI>(true);
        if (ft != null)
        {
            ft.text = "Try again!!";
            Debug.Log("Wrong answer.");
        }
    }

        public void pickCorrect()
    {
        PlayerPrefs.SetInt("coins", 5000);
        SceneManager.LoadScene(nextScene);
    }


}

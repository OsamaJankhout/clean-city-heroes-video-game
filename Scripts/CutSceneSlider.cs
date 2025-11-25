using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CutSceneSlider : MonoBehaviour
{
    public  Sprite[] slides;
    public Image slide;
    public string nextScene = "Tutorial";
    private int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (slides.Length > 0)
        {
            Show(0);
        }
    }
    public void Next()
    {
        index++;
        if (index >= slides.Length)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Show(index);
        }

    }
    private void Show(int i)
    {
        slide.sprite =slides[i];
    }
}

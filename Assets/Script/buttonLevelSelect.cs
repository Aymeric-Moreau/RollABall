using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonLevelSelect : MonoBehaviour
{
    public string sceneName;
    public int levelId;
    public Image myImage;
    public LevelData levelData;
    public TextMeshPro TextUi;
    public Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (text.text != sceneName)
        {
            text.text = sceneName;
        }
    }

    public void LoadLevel()
    {
        GameManager.instance.levelData = levelData;
        SceneManager.LoadScene(sceneName);
    }

    public void Setup(LevelData levelData)
    {
        this.levelData = levelData;
        sceneName = levelData.sceneName;
        myImage.sprite = levelData.levelPreview;

    }




}

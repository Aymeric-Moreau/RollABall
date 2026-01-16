using UnityEngine;

public class MenuCreator : MonoBehaviour
{
    public GameObject buttonPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in GameManager.instance.levelDb.level)
        {
           GameObject button =  Instantiate(buttonPrefab, gameObject.transform);
            button.GetComponent<buttonLevelSelect>().Setup(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

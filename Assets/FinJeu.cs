using UnityEngine;
using UnityEngine.SceneManagement;

public class FinJeu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<controler>().coCheckpoint = transform.position;

            //if (other.gameObject.TryGetComponent<controler>(out var ball))
            //{
            //    ball.coCheckpoint = transform.position;
            //    gameObject.SetActive(false);
            //}

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }


    }
}

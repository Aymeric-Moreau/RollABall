using Unity.VisualScripting;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float LifeRange;
    public float timeSpawn = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        timeSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSpawn > LifeRange)
        {

            DestroyMyObject();
        }
        timeSpawn += Time.deltaTime;
        //Debug.Log();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyMyObject();
        }
    }


    void DestroyMyObject()
    {
        gameObject.SetActive(false);
    }
}

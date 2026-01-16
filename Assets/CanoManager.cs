
using System.Collections.Generic;
using UnityEngine;

public class CanoManager : MonoBehaviour
{
    float lastShot;
    public float colldown;
    public GameObject bullet;
    public float force;

    List<GameObject> pool = new();
    public int poolSize = 100;
    void initPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject g = Instantiate(bullet);
            pool.Add(g);
            g.SetActive(false);
        }
    }

    public void Awake()
    {
        initPool();
    }

    GameObject GetFree() {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeSelf)
            {
                return pool[i];
            }
        }
        // grossir la liste avec un nouvel objet
        GameObject g = Instantiate(bullet);
        pool.Add(g);
        g.SetActive(false);
        return g;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastShot + Random.Range(colldown - 0.2f , colldown + 0.2f))
        {
            Shot();
            lastShot = Time.time;
        }
    }

    void Shot()
    {
        GameObject leBoulet = GetFree();// Instantiate(bullet,this.transform);
        leBoulet.SetActive(true);
        leBoulet.transform.position = this.transform.position;
        leBoulet.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        leBoulet.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

        if (leBoulet.activeSelf)
        {
            leBoulet.GetComponent<Rigidbody>().AddForce(transform.up * force);
        }
        
        //leBoulet.GetComponent<BulletManager>().timeSpawn = 0;
    }
}


using System;
using UnityEngine;

public class controler : MonoBehaviour
{
    public GameObject GameObject;
    Rigidbody m_Rigidbody;
    public float speed = 10;
    float zAxis;
    float xAxis;
    public UnityEngine.Vector3 coCheckpoint;
    public float respawnAltitude;
    public cameraController cam;
    Vector3 direction;
    public float jumpForce;
    int nbrJump;
    public int nbrJumpMax = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.ball = this.gameObject;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(new UnityEngine.Vector3(0, respawnAltitude,0),2);
    }

    // Update is called once per frame
    void Update()
    {

        Quaternion rot = Quaternion.Euler(0, GameManager.instance.cam.camAngle, 0);
        xAxis = Input.GetAxis("Vertical");
        zAxis = Input.GetAxis("Horizontal");
        direction = new Vector3(xAxis , 0, - zAxis);
        direction = rot * direction;


        if (transform.position.y < GameManager.instance.levelData.ballRespawnAltitude)
        {
            respawn();
        }

        Debug.Log("jump : " + nbrJump + " . ");
        if (Input.GetKeyDown(KeyCode.Space) && nbrJump < nbrJumpMax) // Jump 
        {
            nbrJump++;
            m_Rigidbody.AddForce(UnityEngine.Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
    }

    private void FixedUpdate()
    {
        m_Rigidbody.AddTorque(direction * GameManager.instance.levelData.vitesseBall, ForceMode.VelocityChange);


        

        

        //if (Input.GetKey(KeyCode.A)) // gauche
        //{

        //    m_Rigidbody.AddForce(UnityEngine.Vector3.left * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D)) // droite
        //{
        //    m_Rigidbody.AddForce(UnityEngine.Vector3.right * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.W)) // avant
        //{
        //    m_Rigidbody.AddForce(UnityEngine.Vector3.forward * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S)) // arri�re
        //{
        //    m_Rigidbody.AddForce(UnityEngine.Vector3.back * speed * Time.deltaTime);
        //}
    }

    void respawn()
    {
        transform.position = coCheckpoint;
        m_Rigidbody.linearVelocity = new UnityEngine.Vector3(0,0,0);
        m_Rigidbody.angularVelocity = new UnityEngine.Vector3(0, 0, 0);

        


    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Terrain"))
        {
            
            nbrJump = 0;
        }


    }

}

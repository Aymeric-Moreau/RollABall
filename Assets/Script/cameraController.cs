using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class cameraController : MonoBehaviour
{
    public int offset = 20;
    public Vector3 offsetV3 = new Vector3(0,0,0);
    public GameObject Player;
    //Vector3 PosY;
    //Vector3 lastMousePos;
    [HideInInspector] public float camAngle = 0;
    [HideInInspector] public float camAngleY = 0;
    [Range(0.1f,20)]public float camSpeed;
    [Range(0.1f, 20)] public float camSpeedY;

    [SerializeField] float minRotY;
    [SerializeField] float maxRoty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.cam = this;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    //    lastMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float delta = Input.GetAxis("Mouse X");
        float deltaY = -Input.GetAxis("Mouse Y");
        camAngle += delta * camSpeed;
        camAngleY += deltaY * camSpeedY; // Mathf.Clamp(deltaY * camSpeed, -90, 90)
        camAngleY = Mathf.Clamp(camAngleY, minRotY, maxRoty);
        //Mathf.Clamp(xValue, xMin, xMax);
        Quaternion rot = Quaternion.Euler(camAngleY, camAngle,0);
        Vector3 newDisatnce = rot * offsetV3;
        //transform.position = new Vector3(Player.transform.position.x , Player.transform.position.y , Player.transform.position.z - offset);//  Player.transform.position
        transform.position = GameManager.instance.ball.transform.position + newDisatnce; // Player.transform.position
        transform.LookAt(GameManager.instance.ball.transform.position);
        //transform.position = new Vector3(transform.position.x, PosY.y, transform.position.z);//  PosY.y;

        //transform.rotation = new Quaternion(0, 0, 0, 0);

        //lastMousePos = Input.mousePosition;
    }
}

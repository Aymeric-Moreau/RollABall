using UnityEngine;

public class AIEnnemis : MonoBehaviour
{
    Rigidbody rb;
    public GameObject Player;
    public float speed = 3f;
    public float maxAngularSpeed = 20;

    Vector3 axeRotation;

    void Start()
    {
        // on sauvegarde le rigidbody 
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        if (Player == null) return;

        // Direction vers la cible 
        Vector3 direction = transform.position - Player.transform.position;
        // qu'on normalize pour pas que la vitesse change si le joueur est plus loin ou moins loin
        direction.Normalize();

        // on calcule l'axe de rotation avec la direction et la direction avant
        axeRotation = Vector3.Cross(direction, Vector3.up);

        // Appliquer la rotation
        rb.AddTorque(axeRotation * speed, ForceMode.VelocityChange);

        // Permet de limiter la vistesse de la balle
        rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, maxAngularSpeed);


       
    }
}

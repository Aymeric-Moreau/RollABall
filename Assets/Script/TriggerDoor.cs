using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public DoorManager Door;
    bool ouvertureEnCours = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // lancement de louverture de la portet si l'ouverture n'estr pas en cours et si c'est bien le joueur
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !ouvertureEnCours)
        {
            ouvertureEnCours = true;
            Door.StartOverture();
            Debug.Log("Start ouverture ");
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {


    //    }
    //}
    // lancement de la fermeture de la portet si l'ouverture est en cours et si c'est bien le joueur
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ouvertureEnCours)
        {
            ouvertureEnCours =false;
            Door.StartFermeture();

            Debug.Log("Start Fermeture !!! ");
        }
    }
}

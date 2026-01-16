using UnityEngine;

[System.Serializable]
public struct EtapePoint
{
   public Transform transform;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
   public float duration;
    
}
public class DoorManager : MonoBehaviour
{
    public EtapePoint[] listePosition;
    Transform initialTransform;

    public Vector3 initialPosition;
    public Quaternion initialRotation;
    public Vector3 initialScale;

    public Vector3 startPosition;
    public Quaternion startRotation;
    public Vector3 startScale;
    private float elapsedTime = 0.0f;// Temps 
    public bool estPasPosisionner = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
         initialPosition = transform.position;
         initialRotation = transform.rotation;
         initialScale = transform.localScale;
}
    private void FixedUpdate()
    {
        // on parcour la lsite des position
        foreach (var item in listePosition)
        {
            // quand selectionne une position on active le faite qu'il n'est pas bien posisionner et on reset le elapsedTime
            estPasPosisionner = true;
            elapsedTime = 0;
            //stadeLerp = 0;

            startPosition = transform.position;
            startRotation = transform.rotation;
            startScale = transform.localScale;

            // tant qu'il n'est pas bien positionner il vas ce diriger progressivement en respectant les delay vers la position cible
            while (estPasPosisionner)
            {
                elapsedTime += Time.deltaTime;

                float stadeLerp = elapsedTime / item.duration;

                transform.position = Vector3.Lerp(startPosition, item.position, stadeLerp);
                transform.rotation = Quaternion.Lerp(startRotation, item.rotation, stadeLerp);
                transform.localScale = Vector3.Lerp(startScale, item.scale, stadeLerp);

                if (stadeLerp > 1.0f)
                {
                    stadeLerp = 1.0f;
                    estPasPosisionner = false;
                    initialTransform = transform;
                }
            }
        }
        
    }


}

using UnityEngine;
using static UnityEngine.GraphicsBuffer;



public class DoorManager : MonoBehaviour
{
    // position ou commence l'élément au début d u jeux
    Vector3 initialPosition;
    Quaternion initialRotation;
    Vector3 initialScale;

    // position ou est l'élément au début de l'anim
    Vector3 startPosition;
    Quaternion startRotation;
    Vector3 startScale;

    // position ou doi finir l'élément a la fin 
    public Vector3 ciblePosition;
    public Quaternion cibleRotation;
    public Vector3 cibleScale;

    float elapsedTime = 0f;
    // duréer de l'anime
    public float duration;
    enum DoorState { Idle, Opening, Closing }
    DoorState state = DoorState.Idle;

    private void Start()
    {
        // on sauvegarde la position initial de la porte
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialScale = transform.localScale;
    }
    private void Update()
    {
        // si la porte est au stade d'ouverture
        if (state == DoorState.Opening)
        {
            // on update la positon la rotation et la scale petit a petit entre la position de départ du déplacement et la position cible
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / duration;

            transform.position = Vector3.Lerp(startPosition, ciblePosition, t);
            transform.rotation = Quaternion.Lerp(startRotation, cibleRotation, t);
            transform.localScale = Vector3.Lerp(startScale, cibleScale, t);
        }
        // si la porte est au stade fermer
        else if (state == DoorState.Closing)
        {
            // update la postion dans le sens invers que pour l'ouverture de la position de départ du déplacement jusqu'a la position initial
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / duration;

            transform.position = Vector3.Lerp(startPosition, initialPosition, t);
            transform.rotation = Quaternion.Lerp(startRotation, initialRotation, t);
            transform.localScale = Vector3.Lerp(startScale, initialScale, t);
        }
    }
    public void StartOverture()
    {
        // update start postion pour la positon ou ce trouve l'élément a l'activation de l'ouverture
        startPosition = transform.position;
        startRotation = transform.rotation;
        startScale = transform.localScale;

        state = DoorState.Opening;
        if (elapsedTime != 0f)
            elapsedTime = duration - elapsedTime;
    }
    public void StartFermeture()
    {
        if (state == DoorState.Opening)
        {
            startPosition = transform.position;
            startRotation = transform.rotation;
            startScale = transform.localScale;

            elapsedTime = duration - elapsedTime;
        }

        state = DoorState.Closing;
    }
}






//[System.Serializable]
//public struct EtapePoint
//{
//    public Vector3 position;
//    public Quaternion rotation;
//    public Vector3 scale;
//    public float duration;
//}


//public EtapePoint[] listePosition;

//int index = 0;
//float elapsedTime = 0f;

//Vector3 startPosition;
//Quaternion startRotation;
//Vector3 startScale;

//// Point 4 : enum au lieu d’un bool
//enum DoorState { Idle, Opening, Closing }
//DoorState state = DoorState.Idle;

//EtapePoint etape;

//void Start()
//{

//    startPosition = transform.position;
//    startRotation = transform.rotation;
//    startScale = transform.localScale;

//    index = 0;
//    elapsedTime = 0f;
//    state = DoorState.Idle;
//}

//void Update()
//{
//    if (state == DoorState.Idle)
//        return;

//    if (index < 0 || index >= listePosition.Length)
//        return;

//    etape = listePosition[index];
//    elapsedTime += Time.deltaTime;
//    float stadeLerp = elapsedTime / etape.duration;

//    if (state == DoorState.Opening)
//    {
//        transform.position = Vector3.Lerp(startPosition, etape.position, stadeLerp);
//        transform.rotation = Quaternion.Lerp(startRotation, etape.rotation, stadeLerp);
//        transform.localScale = Vector3.Lerp(startScale, etape.scale, stadeLerp);

//        if (stadeLerp >= 1f)
//        {
//            transform.position = etape.position;
//            transform.rotation = etape.rotation;
//            transform.localScale = etape.scale;

//            startPosition = transform.position;
//            startRotation = transform.rotation;
//            startScale = transform.localScale;

//            elapsedTime = 0f;
//            index++;
//        }
//    }
//    else if (state == DoorState.Closing)
//    {
//        EtapePoint currentEtape = listePosition[index];

//        Vector3 targetPosition;
//        Quaternion targetRotation;
//        Vector3 targetScale;

//        // Si on a une étape précédente
//        if (index > 0)
//        {
//            EtapePoint previousEtape = listePosition[index - 1];
//            targetPosition = previousEtape.position;
//            targetRotation = previousEtape.rotation;
//            targetScale = previousEtape.scale;
//        }
//        else
//        {
//            // Retour à l'état initial
//            targetPosition = startPosition;
//            targetRotation = startRotation;
//            targetScale = startScale;
//        }

//        elapsedTime += Time.deltaTime;
//        stadeLerp = elapsedTime / currentEtape.duration;

//        transform.position = Vector3.Lerp(currentEtape.position, targetPosition, stadeLerp);
//        transform.rotation = Quaternion.Lerp(currentEtape.rotation, targetRotation, stadeLerp);
//        transform.localScale = Vector3.Lerp(currentEtape.scale, targetScale, stadeLerp);

//        if (stadeLerp >= 1f)
//        {
//            transform.position = targetPosition;
//            transform.rotation = targetRotation;
//            transform.localScale = targetScale;

//            elapsedTime = 0f;
//            index--;

//            if (index < 0)
//            {
//                state = DoorState.Idle;
//            }
//        }
//    }

//}

//public void StartOverture()
//{
//    state = DoorState.Opening;
//    if (elapsedTime != 0f)
//        elapsedTime = etape.duration - elapsedTime;
//}

//public void StartFermeture()
//{
//    if (state == DoorState.Opening)
//    {
//        index--; //  essentiel
//        elapsedTime = listePosition[index].duration - elapsedTime;
//    }

//    state = DoorState.Closing;
//}
//}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    /*List<GameObject> nearestObject = new List<GameObject> { };
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    */
    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "target" && !nearestObject.Contains(collision.gameObject))
        {
            nearestObject.Add(collision.gameObject);
            print(collision.gameObject.name + " added");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (nearestObject.Contains(collision.gameObject))
        {
            nearestObject.Remove(collision.gameObject);
            print(collision.gameObject.name + " removed");
        }
    }*/

    /// <summary>
    /// Trouve la cible la plus proche du joueur
    /// </summary>
    /// <param name="targets">Liste de cibles dans lesquelles chercher</param>
    /// <param name="fromThis">Point depuis où chercher</param>
    /// <param name="radius">Radius de recherche</param>
    /// <returns>Retourne la cible la plus proche du joueur</returns>
    private GameObject GetClosestTarget(GameObject[] targets, Transform fromThis, float radius)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = radius;
        Vector3 currentPosition = fromThis.position;
        foreach (GameObject potentialTarget in targets)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    /// <summary>
    /// Donne la cible la plus proche
    /// </summary>
    /// <returns>La cible la plus proche</returns>
    public GameObject getTarget(float radius)
    {
        return GetClosestTarget(GameObject.FindGameObjectsWithTag("target"), this.transform, radius);
    }
}

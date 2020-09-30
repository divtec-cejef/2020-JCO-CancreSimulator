using UnityEngine;

/**
* Permet de rechercher la cible la plus proche d'un viseur
*/
public class PlayerCollider : MonoBehaviour
{
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
    public GameObject GetTarget(float radius)
    {
        return GetClosestTarget(GameObject.FindGameObjectsWithTag("target"), this.transform, radius);
    }
}

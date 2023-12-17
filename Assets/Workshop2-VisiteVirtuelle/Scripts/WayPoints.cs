using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float waypointSize = 0.2f;

    private void OnDrawGizmos()
    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position) ;
    }

    public Transform GetNextWayPoint(Transform currentWaypoint)
    {
        
        if (currentWaypoint == null) // Vérifie si le point de passage actuel est nul
        {
            
            return transform.GetChild(0); // Retourne le premier enfant du transform actuel
        }

        // Vérifie si l'index du point de passage actuel est inférieur au nombre total d'enfants - 1
        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            // Retourne le prochain point de passage en prenant l'enfant suivant dans la séquence
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
        else
        {
            // Si le point de passage actuel est le dernier, retourne le premier point de passage pour boucler
            return transform.GetChild(0);
        }
    }
}

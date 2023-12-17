using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMover : MonoBehaviour
{
    // Stores a reference to the waypoints system this object will use
    [SerializeField] private WayPoints waypoints;

    [SerializeField] private float movespeed = 5f;

    [SerializeField] private float distanceThreshold  = 0.5f;

    private Transform currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        // Obtient le prochain point de passage et met � jour la position de l'objet � cette position
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // D�finit le prochain point de passage comme cible
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        // Calcule la direction vers le prochain point de passage
        Vector3 direction = currentWaypoint.position - transform.position;

        // Cr�e une rotation bas�e sur la direction calcul�e
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Applique la nouvelle rotation au transform de l'objet
        transform.rotation = rotation;
        transform.LookAt(currentWaypoint.position);
    }


    // Update is called once per frame
    void Update()
    {
        // D�place l'objet vers le point de passage actuel � une vitesse donn�e (movespeed)
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, movespeed * Time.deltaTime);

        // V�rifie si la distance entre l'objet et le point de passage actuel est inf�rieure � une certaine limite (distanceThreshold)
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            // Si la distance est inf�rieure � la limite, passe au prochain point de passage
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint); 
            transform.LookAt(currentWaypoint.position);
        }
    }

}

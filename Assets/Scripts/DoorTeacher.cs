using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

/**
* Gestion du professeur de la porte
*/
public class DoorTeacher : MonoBehaviour
{

    // Position d'arrivée
    [SerializeField] private Vector3 target = new Vector3(7.6f, -3.8f, 0);
    // Position de départ
    [SerializeField] private Vector3 start = new Vector3(10.3f, -3.8f, 0);
    //nouvelle position
    [SerializeField] private Vector3 targetProgress = new Vector3(10.3f, -3.8f, 0);

    //Vitesse de déplacement
    [SerializeField] private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        MoveOUT();
    }

    // Update is called once per frame
    void Update()
    {
        //Fait entrer le prof
        if(transform.position.x > targetProgress.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        }
        //Fait sortir le prof
        if (transform.position.x < targetProgress.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, start, Time.deltaTime * speed);
        }
    }

    /**
     *  Fait bouger le prof dans la salle
     */
    public void MoveIN()
    {
        targetProgress = transform.position - new Vector3(3.5f, 0, 0);
    }

    /**
     * Fait bouger le prof hors de la salle
     */
    public void MoveOUT()
    {
        targetProgress = transform.position + new Vector3(3.5f, 0, 0);
    }

    /**
     * Tant que le prof n'est pas à sa position d'arrivée, il n'est pas considéré comme "dans la classe"
     */
    public bool IsTeacherIN() 
    {
        return (transform.position == target);
    }
}

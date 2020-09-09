using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

/**
 * Professeur qui peut intervenir depuis la porte de la salle de classe
 */
public class old_DoorTeacher : MonoBehaviour
{
    // Position d'arrivée
    [SerializeField] private Vector3 target = new Vector3(7.6f, -1.7f, 0);
    // Position de départ
    [SerializeField] private Vector3 start = new Vector3(10.3f, -1.7f, 0);

    //Vitesse de déplacement
    [SerializeField] private float speed = 5;
    //true = le prof est dans la salle | false = le prof n'est pas dans la classe
    public Boolean isIN = false;
    //nombre aléatoire permettant l'entrée/sortie aléatoire du prof
    int rndNum = -100;


    // Lancement du script
    void Start()
    {
        // Éxécute la fonction getRndNum après la première seconde du lancement et la répète chaque seconde
        InvokeRepeating("getRndNum", 1, 1);
        
    }

    // S'éxécute toutes les frames
    void Update()
    {
        //fait rentrer le prof
        if(rndNum == 31)
        {
            CancelInvoke("getRndNum");
            moveIN();
            //dès que le prof atteint sa position d'arrivé, relancer la création de nombre aléatoire
            if (isIN)
            {
                rndNum = -1;
                InvokeRepeating("getRndNum",1,1);
            }
        }
        //fait sortir le prof
        if(rndNum >= 20 && rndNum <= 30)
        {
            CancelInvoke("getRndNum");
            moveOUT();
            //tant que le prof n'est pas sortit de la salle, le faire sortir
            if (!isIN)
            {
                rndNum = -1;
                InvokeRepeating("getRndNum", 1, 1);
            }
        }
        //debug
        print(rndNum);
        print("Door : " + IsInvoking("getRndNum"));
    }

        

    /**
     * Fait bouger le prof en direction de la salle
     * lorsqu'il a atteint sa position d'arrivée, il est déclaré "dans la salle"
     */
    void moveIN()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        
        if(transform.position == target)
        {
            isIN = true;
        }
    }

    /**
     * Fait bouger le prof hors de la salle
     * lorsqu'il a atteint sa position initiale, il est déclaré "en dehors de la salle"
     */
    void moveOUT()
    {
        transform.position = Vector3.MoveTowards(transform.position, start, Time.deltaTime * speed);

        if (transform.position == start)
        {
            isIN = false;
        }
    }

    /**
     * génère un nombre aléatoire entre un range donné
     * return: un nombre aléatoire
     */
    private int getRndNum()
    {
        rndNum = UnityEngine.Random.Range(0, 40);

        return rndNum;
    }
}

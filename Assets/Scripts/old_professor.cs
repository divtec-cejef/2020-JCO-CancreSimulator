using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

/**
 * Professeur principal de la classe, il peut se retourner
 */
public class old_professor : MonoBehaviour
{
    //sprite
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    //sprite point d'exclamation
    public GameObject exclamation;
    //true = le prof est dans la salle | false = le prof n'est pas dans la classe
    Boolean isIN = false;
    //nombre aléatoire permettant l'entrée/sortie aléatoire du prof
    int rndNum = -100;


    // Lancement du script
    void Start()
    {
        // Sprite de lancement = prof de dos
        spriteRenderer.sprite = spriteArray[0];
        // Éxécute la fonction getRndNum après la première seconde du lancement et la répète chaque seconde
        InvokeRepeating("getRndNum", 1, 1);

    }

    // S'éxécute toutes les frames
    void Update()
    {   
        // le prof s'énèrve puis se retourne retourne en direction du joueur
        if (rndNum == 61)
        {
            CancelInvoke("getRndNum");
            gettingAngry();
            //dès que le prof est retourné (joueur), relancer la création de nombre aléatoire
            if (isIN)
            {
                rndNum = -1;
                InvokeRepeating("getRndNum", 1, 1);
            }
        }

        // le prof se retourne en direction du tableau
        if (rndNum >= 50 && rndNum <= 56)
        {
            CancelInvoke("getRndNum");
            moveOUT();
            //dès que le prof est retourné (tableau), relancer la création de nombre aléatoire
            if (!isIN)
            {
                rndNum = -1;
                InvokeRepeating("getRndNum", 1, 1);
            }
        }
        //debug
        print(rndNum);
        print("Tableau : " + IsInvoking("getRndNum"));
    }

    /**
     * Fait se retourner le prof face au joueur
     * lorsqu'il est retourné, il est déclaré "dans la salle"
     * désactive le point d'exclamation
     */
    void moveIN()
    {
        isIN = true;
        spriteRenderer.sprite = spriteArray[1];
        exclamation.SetActive(false);
    }

    /**
    * Fait se retourner le prof face au tableau
    * lorsqu'il est retourné, il est déclaré "en dehors de la salle"
    */
    void moveOUT()
    {
        isIN = false;
        spriteRenderer.sprite = spriteArray[0];
    }

    /**
     * génère un nombre aléatoire entre un range donné
     * return: un nombre aléatoire
     */
    private int getRndNum()
    {
        rndNum = UnityEngine.Random.Range(50,71);

        return rndNum;
    }

    /**
     * Le prof s'énèrve un point d'exclamation appraît au dessus de sa tête
     */
    void gettingAngry()
    {
        exclamation.SetActive(true);
        Invoke("moveIN", 1.5f);
        
    }
}


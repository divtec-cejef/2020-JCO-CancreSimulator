using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Cible qui appaître sur le tableau de la salle de classe
 */
public class Target : MonoBehaviour
{
    // Référence du GameManager
    public GameManager gameManager;

    // S'éxécute au lancement du script
    void Start()
    {
        //donne accès aux fonctions présentent dans le script "GameManager"
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Si un cible n'est pas détruite après 4 secondes, la drétuit
        Destroy(gameObject, 4f); 
    }

    // S'éxécute toutes les frames
    void Update()
    {
        
    }

    /**
     * Détruit une cible lorsque qu'elle est clquée
     */
    /*private void OnMouseDown()
    {
        
        gameManager.IncrementScore();

        Destroy(gameObject);
    }*/
}

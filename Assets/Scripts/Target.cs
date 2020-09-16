using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/**
 * Cible qui appaître sur le tableau de la salle de classe
 */
public class Target : MonoBehaviour
{
    // Référence du GameManager
    private GameManager gameManager;
    //Pièce à deux faces choisissant si le mouvement sera vertical ou horizontal
    int verticalORhorizontal;
    //left
    Vector3 Lhori;
    //right
    Vector3 RHori;
    //up
    Vector3 UVerti;
    //down
    Vector3 DVerti;

    int goldenTarget = 10;
    int goldenTargetRoll;
    //Taille de la cible
    public float targetSize;
    public bool isGoldenTarget = false;

    float speed;

    Vector3 tempPosition;

    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    // S'éxécute au lancement du script
    void Start()
    {
        //donne accès aux fonctions présentent dans le script "GameManager"
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //La cible aura une vitesse constante aléatoire
        speed = UnityEngine.Random.Range(0f, 1.5f);
        //Choisit si le mouvement sera vertical ou horizontal
        verticalORhorizontal = UnityEngine.Random.Range(0, 2);
        print("vertical OR horizontal : " + verticalORhorizontal);

        goldenTargetRoll = UnityEngine.Random.Range(0, 50);
        if (goldenTargetRoll == goldenTarget)
        {
            spriteRenderer.sprite = spriteArray[1];
            isGoldenTarget = true;
        }

        transform.localScale = RndScale();

        if (verticalORhorizontal == 1)
        {
            //horizontal
            Lhori = transform.position + new Vector3(-0.75f, 0, 0);
            RHori = transform.position + new Vector3(0.75f, 0, 0);
            //Si une position est suceptible de sortir du tableau, on lui assigne la limte du tableau
            if (Lhori.x < -4.31f)
            {
                Lhori.x = -4.31f;
            }
            if (RHori.x > 4.73f)
            {
                RHori.x = 4.73f;
            }
        }
        else
        {
            //vertical
            DVerti = transform.position + new Vector3(0, -0.75f, 0);
            UVerti = transform.position + new Vector3(0, 0.75f, 0);
            //Si une position est suceptible de sortir du tableau, on lui assigne la limte du tableau
            if (UVerti.y > 3.8f)
            {
                UVerti.y = 3.8f;
            }
            if (DVerti.y < -2.37f)
            {
                DVerti.y = -2.37f;
            }

        }

        Invoke("Destroy", 6f);
    }
    // S'éxécute toutes les frames
    void Update()
    {
        SwitchTempPosition();

        if (verticalORhorizontal == 1)
        {
            //mouvement horizontal
            Horizontal();
        }
        else
        {
            //mouvement vertical
            Vertical();
        }

    }

    /**
     * Fait bouger la cible verticalement
     */
    public void Vertical()
    {
        if (transform.position.y > tempPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, DVerti, Time.deltaTime * speed);
        }

        if (transform.position.y < tempPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, UVerti, Time.deltaTime * speed);
        }

    }

    /**
     * Fait bouger la cible horizontalement
     */
    public void Horizontal()
    {

        if (transform.position.x > tempPosition.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, Lhori, Time.deltaTime * speed);
        }

        if (transform.position.x < tempPosition.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, RHori, Time.deltaTime * speed);
        }

    }

    /**
     * Fait changer de drection le mouvement de la cible
     * Si elle atteint sa position min/max, et se dirigera vers sa position max/min
     */
    public void SwitchTempPosition()
    {
        if (verticalORhorizontal == 1)
        {
            //horizontal
            if (transform.position.x <= Lhori.x)
            {
                tempPosition = RHori;
            }
            if (transform.position.x >= RHori.x)
            {
                tempPosition = Lhori;
            }
        }
        else
        {
            //vertical
            if (transform.position.y <= DVerti.y)
            {
                tempPosition = UVerti;
            }
            if (transform.position.y >= UVerti.y)
            {
                tempPosition = DVerti;
            }
        }
    }

    public Vector3 RndScale()
    {
        float newScale = UnityEngine.Random.Range(0.01f, 0.08f);
        Vector3 Scale = new Vector3(newScale, newScale, newScale);
        targetSize = newScale;
        return Scale;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

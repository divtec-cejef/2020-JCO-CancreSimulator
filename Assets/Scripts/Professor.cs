using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Professor : MonoBehaviour
{
    //sprite
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    //sprite point d'exclamation
    public GameObject exclamation;

    // Start is called before the first frame update
    void Start()
    {
        moveOUT();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Fait se retourner le prof face au joueur
     * lorsqu'il est retourné, il est déclaré "dans la salle"
     * désactive le point d'exclamation
     */
    void gettingAngry()
    {
        spriteRenderer.sprite = spriteArray[1];
        exclamation.SetActive(false);
    }

    /**
    * Fait se retourner le prof face au tableau
    * lorsqu'il est retourné, il est déclaré "en dehors de la salle"
    */
    public void moveOUT()
    {
        spriteRenderer.sprite = spriteArray[0];
    }

    /**
     * Le prof s'énèrve un point d'exclamation appraît au dessus de sa tête
     */
    public void moveIN()
    {
        exclamation.SetActive(true);
        Invoke("gettingAngry", 1f);

    }


}

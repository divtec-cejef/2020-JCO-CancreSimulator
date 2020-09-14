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
    public GameObject exclamationRed;

    private bool isReturned = false;

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
        isReturned = true;
    }

    /**
    * Fait se retourner le prof face au tableau
    * lorsqu'il est retourné, il est déclaré "en dehors de la salle"
    */
    public void moveOUT()
    {
        spriteRenderer.sprite = spriteArray[0];
        isReturned = false;
    }

    /**
     * Le prof s'énèrve un point d'exclamation appraît au dessus de sa tête
     */
    public void moveIN()
    {
        activeExcla();
        Invoke("desacExcla", 0.25f);
        Invoke("activeExclaRed", 0.25f);
        Invoke("desacExclaRed", 0.50f);
        Invoke("activeExcla", 0.50f);
        Invoke("desacExcla", 0.75f);
        Invoke("activeExclaRed", 0.75f);

        Invoke("desacExclaRed", 1f);
        Invoke("gettingAngry", 1f);

    }

    public bool isTeacherIN()
    {
        return isReturned;
    }

    public void activeExcla()
    {
        exclamation.SetActive(true);
    }
    public void desacExcla()
    {
        exclamation.SetActive(false);
    }
    public void activeExclaRed()
    {
        exclamationRed.SetActive(true);
    }
    public void desacExclaRed()
    {
        exclamationRed.SetActive(false);
    }


}

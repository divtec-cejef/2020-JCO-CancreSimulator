using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Gestion du prof principal
*/
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
        MoveOUT();
    }

    /**
     * Fait se retourner le prof face au joueur
     * lorsqu'il est retourné, il est déclaré "dans la salle"
     * désactive le point d'exclamation
     */
    void GettingAngry()
    {
        spriteRenderer.sprite = spriteArray[1];
        exclamation.SetActive(false);
        isReturned = true;
    }

    /**
    * Fait se retourner le prof face au tableau
    * lorsqu'il est retourné, il est déclaré "en dehors de la salle"
    */
    public void MoveOUT()
    {
        spriteRenderer.sprite = spriteArray[0];
        isReturned = false;
    }

    /**
     * Le prof s'énèrve et un point d'exclamation appraît au dessus de sa tête
     */
    public void MoveIN()
    {
        ActiveExcla();
        Invoke("DesacExcla", 0.25f);
        Invoke("ActiveExclaRed", 0.25f);
        Invoke("DesacExclaRed", 0.50f);
        Invoke("ActiveExcla", 0.50f);
        Invoke("DesacExcla", 0.75f);
        Invoke("ActiveExclaRed", 0.75f);
        //Le prof se tourne face au joueur
        Invoke("DesacExclaRed", 1f);
        Invoke("GettingAngry", 1f);

    }

    //Renvoie si oui ou non le prof est dans la salle
    public bool IsTeacherIN()
    {
        return isReturned;
    }
    
    //Rend visible le point d'exclamation
    public void ActiveExcla()
    {
        exclamation.SetActive(true);
    }
    //Rend invisible le point d'exclamation
    public void DesacExcla()
    {
        exclamation.SetActive(false);
    }
    //Rend visible le point d'exclamation rouge
    public void ActiveExclaRed()
    {
        exclamationRed.SetActive(true);
    }
    //Rend invisible le point d'exclamation rouge
    public void DesacExclaRed()
    {
        exclamationRed.SetActive(false);
    }


}

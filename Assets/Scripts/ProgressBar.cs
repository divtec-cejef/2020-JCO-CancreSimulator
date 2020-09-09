using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Barre de progression qui gère le niveau de colère ou de style du joueur
 */
public class ProgressBar: MonoBehaviour
{
    private Slider progressBar;
    private float targetProgress = 0;
    public float FillSpeed = 0.5f;

    private void Awake()
    {
        progressBar = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //IncrementProgress(0.75f);
        //DecrementProgress(0.5f); 
    }

    // Update is called once per frame
    void Update()
    {
        //Fait monter le valeur de la progress bar
        if (progressBar.value < targetProgress)
        {
            progressBar.value += FillSpeed * Time.deltaTime;
        }
        //Fait déscendre la valeur de la progress bar
        if(progressBar.value > targetProgress)
        {
            progressBar.value -= FillSpeed * Time.deltaTime;
        }
    }

    /**
     * Assigne la nouvelle valeur à ajouter à la progress bar
     * newProgress : valeur à ajouter (1% == 0.01f)
     */
    public void IncrementProgress(float newProgress)
    {
        targetProgress = progressBar.value + newProgress;
    }

    /**
     * Assigne la nouvelle valeur à soustraire de la progress bar
     * newProgress : valeur à ajouter (1% == 0.01f)
     */
    public void DecrementProgress(float newProgress)
    {
        targetProgress = progressBar.value - newProgress;
    }
}

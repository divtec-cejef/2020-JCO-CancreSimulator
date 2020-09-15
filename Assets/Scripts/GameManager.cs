using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Gestion du jeux
public class GameManager : MonoBehaviour
{
    //Objet : cible
    public GameObject target;
    //Objet : écran de victoire
    public GameObject VictoryIMG;
    //Objet : doorTeacher
    public DoorTeacher doorTeacher;
    //Objet : windowTeacher
    public WindowTeacher windowTeacher;
    //Objet : professor
    public Professor professor;
    //Objet : Bouton Rejouer
    public GameObject Rejouer;
    //Objet : Nom gagnant
    public GameObject Winner;
    //condition de victoire
    bool win = false;
    //Texte du compteur
    public Text timeText;


    int compteur = 10;
    int style = 50;
    bool tenSec = false;
    int anger = 0;
    //Temps de départ du compteur
    public float timeRemaining = 120;
    //Etat du compteur
    public bool timerIsRunning = false;



    // S'éxucute au lancement du script
    void Start() 
    {
        VictoryIMG.SetActive(false);
        Rejouer.SetActive(false);
        //boucle des movement des professeurs
        //StartCoroutine(movingTeachers());

        InvokeRepeating("coroutine",1f, 30f);
        
        doorTeacher = GameObject.Find("teacher3").GetComponent<DoorTeacher>();
        windowTeacher = GameObject.Find("teacher2").GetComponent<WindowTeacher>();
        professor = GameObject.Find("Professor").GetComponent<Professor>();

        // Lancement de l'apparition des cibles dès le début, et se répète chaque seconde
        InvokeRepeating("Spawn", 1f, 1f);
        //Toutes les dix secondes, perd 5% de style si aucune action n'est faite
        InvokeRepeating("tenSecondsTimer", 1f, 1f);

                
    }

    // S'éxécute toutes les frames
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                CancelInvoke("Spawn");
                PlayerWin();
            }
        }

        DisplayTime(timeRemaining);

        //condition de victoire
        /*if (win)
        {   
            // Stop l'apparition des cibles
            CancelInvoke("Spawn");
        }*/
    }

    /**
     * Fait apparaître une cible à un point donné aléatoire
     */
    void Spawn()
    {
        float randomX = UnityEngine.Random.Range(-4.31f, 4.73f);
        float randomY = UnityEngine.Random.Range(-2.37f, 3.8f);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        Instantiate(target, randomPosition, Quaternion.identity);
    }

    /**
     * Incrémente le score
     */
    /*public void IncrementScore()
    {
        score++;
        print(score);

        //scoreText.text = score.ToString();

        if(score >= 10)
        {

        }
    }*/
    public void PlayerWin() 
    { 
        //win = true;
        VictoryIMG.SetActive(true);
        //Rejouer.SetActive(true);
    }

    /**
     * Décrémente le score
     */
    /*public void DecrementScore()
    {
        score--;
    }*/

    /**
     * incrémente le compteur jusqu'à 10, puis recommence.
     * si le score à changer avant d'atteindre 10, le compteur retourne à 0
     */
    public void tenSecondsTimer()
    {
        //compare le score du joueur avec le score enregistrer lors du dernier repeat
        /*if (oldScore != score)
        {
            compteur = 0;
            tenSec = false;
        }*/

        //Regarde si le compteur atteint 10
        if (compteur <= 10)
        {
            compteur++;
            tenSec = false;
        }
        else
        {
            compteur = 0;
            tenSec =  true;
        }
        //si le compteur atteint 10, perd 5% de style
        if (tenSec)
        {
            style -= 5;
        }        
    }
    
    /**
     * Regarde si le joueur dispose encore de style, sinon l'expulse
     */
    public void checkStyle()
    {
        if(style <= 0)
        {
            //TODO : KICK JOUEUR
        }
    }

    /**
     * Regarde si le joueur maintient un bon niveau de colère, sinon l'expulse
     */
    public void checkAnger()
    {
        if (anger >= 100)
        {
            //TODO : KICK JOUEUR
        }
    }

    public void coroutine()
    {
        //boucle des movement des professeurs
        StartCoroutine(movingTeachers());
    }
    IEnumerator movingTeachers()
    {
        int rndNum = UnityEngine.Random.Range(1, 6);
        print(rndNum);

        switch (rndNum)
        {
            case 1:
                //0
                yield return new WaitForSeconds(2.5f);
                //5
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //10
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //15
                yield return new WaitForSeconds(2.5f);
                //20
                windowTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //25
                windowTeacher.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //30
                yield return new WaitForSeconds(2.5f);
                //35
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //40
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //45
                yield return new WaitForSeconds(2.5f);
                //50
                doorTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //55
                doorTeacher.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //60
                break;

            case 2:
                //0
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //5
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //10
                windowTeacher.moveIN();
                doorTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //15
                windowTeacher.moveOUT();
                doorTeacher.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //20
                yield return new WaitForSeconds(2.5f);
                //25
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //30
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //35
                doorTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //40
                doorTeacher.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //45
                doorTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //50
                doorTeacher.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //55
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //60
                professor.moveOUT();
                break;

            case 3:
                //0
                professor.moveIN();
                windowTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //5
                windowTeacher.moveOUT();
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //10
                yield return new WaitForSeconds(2.5f);
                //15
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //20
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //25
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //30
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //35
                yield return new WaitForSeconds(2.5f);
                //40
                doorTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //45
                doorTeacher.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //50
                yield return new WaitForSeconds(2.5f);
                //55
                windowTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //60
                windowTeacher.moveOUT();

                break;

            case 4:
                //0
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //5
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //10
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //15
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //20
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //25
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //30
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //35
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //40
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //45
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //50
                yield return new WaitForSeconds(2.5f);
                //55
                windowTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //60
                windowTeacher.moveOUT();

                break;

            case 5:
                //0
                doorTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //5
                doorTeacher.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //10
                yield return new WaitForSeconds(2.5f);
                //15
                yield return new WaitForSeconds(2.5f);
                //20
                doorTeacher.moveIN();
                windowTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //25
                doorTeacher.moveOUT();
                windowTeacher.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //30
                yield return new WaitForSeconds(2.5f);
                //35
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //40
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //45
                yield return new WaitForSeconds(2.5f);
                //50
                yield return new WaitForSeconds(2.5f);
                //55
                windowTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //60
                windowTeacher.moveOUT();

                break;

            default:
                Console.WriteLine("Default case");
                break;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}

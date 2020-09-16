using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private DoorTeacher doorTeacher;
    //Objet : windowTeacher
    private WindowTeacher windowTeacher;
    //Objet : professor
    private Professor professor;
    //Objet : backTeacher
    public GameObject backTeacher;

    //Objet : exclamation
    public GameObject exclamation;
    //Objet : exclamationred
    public GameObject exclamationRed;
    //Objet : texte Rejouer
    public GameObject Rejouer;
    //Objet : Nom gagnant
    public GameObject Winner;
    //condition de victoire
    public bool win = false;
    //Texte du compteur
    public Text timeText;

    //Temps de départ du compteur
    public float timeRemaining = 120;
    //Etat du compteur
    public bool timerIsRunning = false;

    public int[] tableauScore = new int[4];

    // S'éxucute au lancement du script
    void Start()
    {
        VictoryIMG.SetActive(false);
        Rejouer.SetActive(false);

        doorTeacher = GameObject.Find("teacher3").GetComponent<DoorTeacher>();
        windowTeacher = GameObject.Find("teacher2").GetComponent<WindowTeacher>();
        professor = GameObject.Find("Professor").GetComponent<Professor>();
                 
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

    public void PlayerWin() 
    { 
        win = true;
        VictoryIMG.SetActive(true);
        DisplayWinner();
        //Annule l'apparition des cibles
        CancelInvoke("Spawn");
        //Détruit toutes les cibles restantes à la fin
        GameObject[] targets = GameObject.FindGameObjectsWithTag("target");
        foreach (var target in targets)
        {
            Destroy(target);
        }

        //Detruit tout les professeurs présents
        CancelInvoke("movingTeachers");
        Destroy(doorTeacher);
        Destroy(windowTeacher);
        Destroy(professor);
        backTeacher.SetActive(false);
        exclamation.SetActive(false);
        exclamationRed.SetActive(false);
       
        Rejouer.SetActive(true);
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
                
                yield return new WaitForSeconds(2.5f);
                //5
                
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
                
                yield return new WaitForSeconds(2.5f);
                //5
                professor.moveIN();
                windowTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //10
                windowTeacher.moveOUT();
                professor.moveOUT();
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
                yield return new WaitForSeconds(2.5f);
                //5
                yield return new WaitForSeconds(2.5f);
                //10
                professor.moveIN();
                yield return new WaitForSeconds(2.5f);
                //15
                professor.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //20
                doorTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //25
                doorTeacher.moveOUT();
                yield return new WaitForSeconds(2.5f);
                //30
                yield return new WaitForSeconds(2.5f);
                //35
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
                
                yield return new WaitForSeconds(2.5f);
                //5
                doorTeacher.moveIN();
                yield return new WaitForSeconds(2.5f);
                //10
                doorTeacher.moveOUT();
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

    void DisplayWinner()
    {
        int meilleurScore = tableauScore[0];
        int idMeilleurScore = 0;
        bool draw = false;

        for (int i = 1; i < tableauScore.Length; i++)
        {
            if(tableauScore[i] > meilleurScore)
            {
                meilleurScore = tableauScore[i];
                idMeilleurScore = i;
            } else if( tableauScore[i] == meilleurScore)
            {
                draw = true;
            }
        }
        if (!draw)
        {
            Winner.GetComponent<Text>().text = "Le joueur " + (idMeilleurScore + 1) + " a gagné";
        } else
        {
            Winner.GetComponent<Text>().text = "Egalité";
        }
    }

}

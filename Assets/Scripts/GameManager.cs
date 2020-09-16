using System;
using System.Collections;
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
    // Tableau des scores
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

    /// <summary>
    /// Fait apparaître une cible à un point donné aléatoire.
    /// </summary>
    void Spawn()
    {
        float randomX = UnityEngine.Random.Range(-4.31f, 4.73f);
        float randomY = UnityEngine.Random.Range(-2.37f, 3.8f);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        Instantiate(target, randomPosition, Quaternion.identity);
    }

    /// <summary>
    /// Ecran de fin de jeu.
    /// </summary>
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
        CancelInvoke("MovingTeachers");
        Destroy(doorTeacher);
        Destroy(windowTeacher);
        Destroy(professor);
        backTeacher.SetActive(false);
        exclamation.SetActive(false);
        exclamationRed.SetActive(false);
       
        Rejouer.SetActive(true);
    }

    /// <summary>
    /// Boucle de mouvement des professeurs.
    /// </summary>
    public void Coroutine()
    {
        //boucle des movement des professeurs
        StartCoroutine(MovingTeachers());
    }
    IEnumerator MovingTeachers()
    {

        int rndNum = UnityEngine.Random.Range(1, 6);
        print(rndNum);

        switch (rndNum)
        {
            case 1:
                //0
                yield return new WaitForSeconds(2.5f);
                //5
                professor.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //10
                professor.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //15
                yield return new WaitForSeconds(2.5f);
                //20
                windowTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //25
                windowTeacher.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //30
                yield return new WaitForSeconds(2.5f);
                //35
                professor.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //40
                professor.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //45
                yield return new WaitForSeconds(2.5f);
                //50
                doorTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //55
                doorTeacher.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //60
                break;

            case 2:
                //0
                
                yield return new WaitForSeconds(2.5f);
                //5
                
                yield return new WaitForSeconds(2.5f);
                //10
                windowTeacher.MoveIN();
                doorTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //15
                windowTeacher.MoveOUT();
                doorTeacher.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //20
                yield return new WaitForSeconds(2.5f);
                //25
                professor.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //30
                professor.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //35
                doorTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //40
                doorTeacher.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //45
                doorTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //50
                doorTeacher.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //55
                professor.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //60
                professor.MoveOUT();
                break;

            case 3:
                //0
                
                yield return new WaitForSeconds(2.5f);
                //5
                professor.MoveIN();
                windowTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //10
                windowTeacher.MoveOUT();
                professor.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //15
                professor.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //20
                professor.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //25
                professor.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //30
                professor.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //35
                yield return new WaitForSeconds(2.5f);
                //40
                doorTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //45
                doorTeacher.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //50
                yield return new WaitForSeconds(2.5f);
                //55
                windowTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //60
                windowTeacher.MoveOUT();

                break;

            case 4:
                //0
                yield return new WaitForSeconds(2.5f);
                //5
                yield return new WaitForSeconds(2.5f);
                //10
                professor.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //15
                professor.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //20
                doorTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //25
                doorTeacher.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //30
                yield return new WaitForSeconds(2.5f);
                //35
                yield return new WaitForSeconds(2.5f);
                //40
                professor.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //45
                professor.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //50
                yield return new WaitForSeconds(2.5f);
                //55
                windowTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //60
                windowTeacher.MoveOUT();

                break;

            case 5:
                //0
                
                yield return new WaitForSeconds(2.5f);
                //5
                doorTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //10
                doorTeacher.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //15
                yield return new WaitForSeconds(2.5f);
                //20
                doorTeacher.MoveIN();
                windowTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //25
                doorTeacher.MoveOUT();
                windowTeacher.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //30
                yield return new WaitForSeconds(2.5f);
                //35
                professor.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //40
                professor.MoveOUT();
                yield return new WaitForSeconds(2.5f);
                //45
                yield return new WaitForSeconds(2.5f);
                //50
                yield return new WaitForSeconds(2.5f);
                //55
                windowTeacher.MoveIN();
                yield return new WaitForSeconds(2.5f);
                //60
                windowTeacher.MoveOUT();

                break;

            default:
                Console.WriteLine("Default case");
                break;
        }
    }

    /// <summary>
    /// Affiche la timer dans le jeu
    /// </summary>
    /// <param name="timeToDisplay">Temps de jeu</param>
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    /// <summary>
    /// Affiche le(s) gagnant(s)
    /// </summary>
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

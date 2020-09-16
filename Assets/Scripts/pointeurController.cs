using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pointeurController : MonoBehaviour
{
    // Radius de recherche
    public float radius = 0.25f;
    // Vitesse de déplacement du curseur
    public float moveSpeed = 30f;

    //Index du dernier joueur à avoir rejoint
    public static int lastColorIndex = 0;
    // Score du joueur
    private int playerScore = 0;
    // Identifiant du joueur
    private int playerId;

    //Objet : doorTeacher
    private DoorTeacher doorTeacher;
    //Objet : windowTeacher
    private WindowTeacher windowTeacher;
    //Objet : professor
    private Professor professor;

    GameManager gameManager;
    PlayerCollider playerColl;
    ScoreColor sc;
    Text displayedScore;

    string playerScoreName;

    Vector2 i_movement;

    void Start()
    {
        // Ajout d'un id au joueur
        playerId = lastColorIndex;
        print("player" + playerId + " has joined!");

        // Nom de l'emplacement de score dans l'interface
        playerScoreName = "scorePlayer" + playerId.ToString();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Récupération du score pour le modifier plus tard
        displayedScore = GameObject.Find(playerScoreName).GetComponent<Text>();
        sc = displayedScore.GetComponentInChildren<ScoreColor>();
        // Initialise le score du joueur
        sc.CreateScore();

        doorTeacher = GameObject.Find("teacher3").GetComponent<DoorTeacher>();
        windowTeacher = GameObject.Find("teacher2").GetComponent<WindowTeacher>();
        professor = GameObject.Find("Professor").GetComponent<Professor>();

        playerColl = this.GetComponentInChildren<PlayerCollider>();

        gameManager.timerIsRunning = true;

        if(lastColorIndex == 0)
        {
            //boucle des movement des professeurs

            //StartCoroutine(movingTeachers());
            gameManager.InvokeRepeating("Coroutine", 1f, 30f);
            // Lancement de l'apparition des cibles dès le début, et se répète chaque seconde
            gameManager.InvokeRepeating("Spawn", 1f, 1f);
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 movement = new Vector2(i_movement.x, i_movement.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
    /// <summary>
    /// Déplace le joueur
    /// </summary>
    /// <param name="value">Valeur du joystick</param>
    void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
    }

    /// <summary>
    /// Tire et détruit une cible.
    /// </summary>
    public void OnFire()
    {
        // Trouve la cible la plus proche
        var go = playerColl.GetTarget(radius);

        // Si une cible a été trouvé, elle est détruite et le score du joueur augmente.
        if (go != null)
        {
            IncrementScore(go.GetComponent<Target>());
            Destroy(go);
        }

    }

    /// <summary>
    /// Redémarre le jeu.
    /// </summary>
    public void OnRestart()
    {
        if(gameManager.win)
        {
            gameManager.timerIsRunning = false;
            lastColorIndex = 0;

            // Détruit tous les joueurs avant de recommencer la partie
            GameObject[] pointers = GameObject.FindGameObjectsWithTag("pointer");
            foreach (var pointer in pointers)
            {
                Destroy(pointer);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

    }

    /// <summary>
    /// Replace le joueur au centre de l'écran.
    /// </summary>
    public void OnRecenter()
    {
        gameObject.transform.position = new Vector2(0, 0);
    }

    /// <summary>
    /// Augmente ou baisse le score du joueur selon la taille des cibles et l'emplacement des professeurs.
    /// </summary>
    /// <param name="cible"></param>
    public void IncrementScore(Target cible)
    {
       int  multiplicateurScore = 1;
        if (doorTeacher.IsTeacherIN() || windowTeacher.IsTeacherIN() || professor.IsTeacherIN())
        {
            multiplicateurScore = -1;
        } 

        if (cible.isGoldenTarget)
        {
            playerScore += 5000 * multiplicateurScore;
        } else
        {
            playerScore += (1000 - (int)(cible.targetSize * 10000f) + 100) * multiplicateurScore; //(10 - cible.targetSize * 100);
        }

        print(playerScore);

        gameManager.tableauScore[playerId] = playerScore;

        displayedScore.text = (playerId + 1) + " : " + playerScore.ToString();
    }
}

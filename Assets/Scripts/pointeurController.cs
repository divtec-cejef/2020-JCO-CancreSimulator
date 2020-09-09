using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class pointeurController : MonoBehaviour
{
    // Radius de recherche
    public float radius = 0.25f;
    // Vitesse de déplacement du curseur
    public float moveSpeed = 20f;
    // Score du joueur affiché à l'écran
    public Text scorePlayer;
    
    // Score du joueur
    private int playerScore = 0;

    // Identifiant du joueur
    private int playerId;

    GameManager gameManager;
    PlayerCollider playerColl;

    Vector2 i_movement;

    void Start()
    {
        playerId = ChangeColor.getPlayerId();
        print("player" + playerId + " has joined!");

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        playerColl = this.GetComponentInChildren<PlayerCollider>();

        //scorePlayer.name = "scorePlayer" + playerId;
        //scorePlayer.text = playerScore.ToString() + "/10";

        /*if (playerId != 0)
        {
            Instantiate(scorePlayer, new Vector2(-3.6f, 4f - (playerId - 0.5f)), Quaternion.identity);
        } else
        {
            Instantiate(scorePlayer, new Vector2(-3.6f, 4f), Quaternion.identity);
        }*/
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
    void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
    }

    public void OnFire()
    {
        // Trouve la cible la plus proche
        var go = playerColl.getTarget(radius);

        // Si une cible a été trouvé, elle est détruite et le score du joueur augmente.
        if (go != null)
        {
            IncrementScore();
            Destroy(go);
        }

    }

    public void IncrementScore()
    {
        playerScore++;
        print(playerScore);

        scorePlayer.text = playerScore.ToString(); // + "/10" //.GetComponent<TextMesh>()

        if (playerScore >= 10)
        {
            print("player" + playerId + " winned!");
            gameManager.PlayerWin();
        }
    }

}

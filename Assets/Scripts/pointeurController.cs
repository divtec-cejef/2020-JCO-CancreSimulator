using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.InputSystem;
public class pointeurController : MonoBehaviour
{
    // Identifiant unique du joueur
    private int playerId;

    // Radius de recherche
    public float radius = 0.25f;
    // Vitesse de déplacement du curseur
    public float moveSpeed = 20f;

    GameManager gameManager;
    PlayerCollider playerColl;

    Vector2 i_movement;

    void Start()
    {
        playerId = ChangeColor.getPlayerId();
        print("player" + playerId + " has joined!");

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerColl = this.GetComponentInChildren<PlayerCollider>();
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
            gameManager.IncrementScore();
            Destroy(go);
        }

    }

}

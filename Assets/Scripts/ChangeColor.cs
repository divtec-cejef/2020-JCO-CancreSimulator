using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeColor : MonoBehaviour
{
    public PlayerInputManager playerInput;

    private static Renderer rend;
    // Liste des couleurs qui seront utilisées
    private static List<Color> availableColors = new List<Color> { Color.red, Color.cyan, Color.green, Color.yellow  };

    // Start is called before the first frame update
    void Start()
    {
        playerInput = PlayerInputManager.instance;
        rend = GetComponent<Renderer>();
        // Donne une couleur au viseur du joueur.
        rend.material.color = availableColors[playerInput.playerCount -1];
      
    }
}

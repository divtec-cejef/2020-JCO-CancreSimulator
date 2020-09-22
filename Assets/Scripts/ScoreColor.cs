using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScoreColor : MonoBehaviour
{
    public PlayerInputManager playerInput;
    // Liste des couleurs qui seront utilisées
    private static List<Color> availableColors = new List<Color> { Color.red, Color.cyan, Color.green, Color.yellow };

    /// <summary>
    /// Donne une couleur et initialise une zone de score.
    /// </summary>
    public void CreateScore()
    {
        playerInput = PlayerInputManager.instance;
        // Donne la couleur
        GetComponent<Text>().color = availableColors[playerInput.playerCount - 1];
        // Initialise à zéro le score
        GetComponent<Text>().text = (playerInput.playerCount) + " : 0";
        
    }
}

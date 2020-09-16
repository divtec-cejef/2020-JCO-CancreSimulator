using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreColor : MonoBehaviour
{
    // Liste des couleurs qui seront utilisées
    private static List<Color> availableColors = new List<Color> { Color.red, Color.cyan, Color.green, Color.yellow };

    /// <summary>
    /// Donne une couleur et initialise une zone de score.
    /// </summary>
    public void CreateScore()
    {
        // Donne la couleur
        GetComponent<Text>().color = availableColors[pointeurController.lastColorIndex];
        // Initialise à zéro le score
        GetComponent<Text>().text = (pointeurController.lastColorIndex + 1) + " : 0";
        
    }
}

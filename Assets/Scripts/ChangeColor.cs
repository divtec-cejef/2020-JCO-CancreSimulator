using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private static Renderer rend;
    // Liste des couleurs qui seront utilisées
    private static List<Color> availableColors = new List<Color> { Color.red, Color.cyan, Color.green, Color.yellow  };

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        // Donne une couleur au viseur du joueur.
        rend.material.color = availableColors[pointeurController.lastColorIndex];
        // Passe à la couleur suivante
        pointeurController.lastColorIndex++;
      
    }
}

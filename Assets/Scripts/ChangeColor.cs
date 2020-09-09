using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private static Renderer rend;

    private static int lastColorIndex = 0;

    private static List<Color> availableColors = new List<Color> { Color.red, Color.cyan, Color.green, Color.yellow  };

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        rend.material.color = availableColors[lastColorIndex];
        lastColorIndex++;
        if (lastColorIndex >= 4)
        {
            lastColorIndex = 0;
        }
    }

    /// <summary>
    /// Donne un id au joueur
    /// </summary>
    /// <returns>L'id du joueur</returns>
    public static int getPlayerId()
    {
        return lastColorIndex;
    }

}

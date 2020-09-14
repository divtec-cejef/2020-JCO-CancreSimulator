using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private static Renderer rend;

    private static List<Color> availableColors = new List<Color> { Color.red, Color.cyan, Color.green, Color.yellow  };

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        rend.material.color = availableColors[pointeurController.lastColorIndex];
        pointeurController.lastColorIndex++;
      
    }
}

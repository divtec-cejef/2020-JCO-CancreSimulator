using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreColor : MonoBehaviour
{
    private static List<Color> availableColors = new List<Color> { Color.red, Color.cyan, Color.green, Color.yellow };

    // Start is called before the first frame update
    void Start()
    {

        
    }

    public void createScore()
    {
        GetComponent<Text>().color = availableColors[pointeurController.lastColorIndex];
        GetComponent<Text>().text = "0";
        
    }
}

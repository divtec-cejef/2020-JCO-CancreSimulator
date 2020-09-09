using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreColor : MonoBehaviour
{
    private static int lastColorIndex = 0;

    private static List<Color> availableColors = new List<Color> { Color.red, Color.cyan, Color.green, Color.yellow };

    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Text>().color = availableColors[lastColorIndex];
        lastColorIndex++;
        if (lastColorIndex >= 4)
        {
            lastColorIndex = 0;
        }
    }
}

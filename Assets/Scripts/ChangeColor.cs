using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeColor : MonoBehaviour
{
    public PlayerInputManager playerInput;

    private static Renderer rend;
    // Liste des couleurs qui seront utilisées
    public static List<Color> availableColors = new List<Color> { Color.red, Color.blue, GetColorFromString("E8790D"), Color.yellow  }; // Color.green

    // Start is called before the first frame update
    void Start()
    {
        playerInput = PlayerInputManager.instance;
        rend = GetComponent<Renderer>();
        // Donne une couleur au viseur du joueur.
        rend.material.color = availableColors[playerInput.playerCount -1];
      
    }
    
    private static int HexToDec(string hex)
    {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }

    private static float HexToFloatNormalized(string hex)
    {
        return HexToDec(hex) / 255f;
    }

    private static Color GetColorFromString(string hexString)
    {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));
        return new Color(red, green, blue);
    }
}

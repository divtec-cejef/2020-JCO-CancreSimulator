using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class highScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    public string chemin = Application.streamingAssetsPath + "/scj.json";

    private void Awake()
    {

        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        string score = PlayerPrefs.GetString("score");
        float monScore = float.Parse(score) * 100;
        int monScoreEntier = (int)monScore;
        string nomJoueur = PlayerPrefs.GetString("namePlayer");
        AddHighscoreEntry(monScoreEntier, nomJoueur);

        string jsonString = File.ReadAllText(chemin);
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[i].score > highscores.highscoreEntryList[j].score)
                {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        string json = JsonUtility.ToJson(highscores.highscoreEntryList);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeigh = 45f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeigh * transformList.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "ème"; break;

            case 1: rankString = "1ER"; break;
            case 2: rankString = "2ème"; break;
            case 3: rankString = "3ème"; break;

        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        // Met le background en valeur, fais des lignes tous les pairs (comme un tableau excel)
        entryTransform.Find("back-ground").gameObject.SetActive(rank % 2 == 1);

        if (rank == 1)
        {
            // Mets en valeur le premier
            entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
        }

        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name)
    {
        // Crée un nouveau score
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Charge le score
        string monJson = File.ReadAllText(chemin);
        Highscores highscores = JsonUtility.FromJson<Highscores>(monJson);

        // Ajoute une nouvelle entrée pour le Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);


        // Sauvegarde les changements
        string jsonString = JsonUtility.ToJson(highscores);
        File.WriteAllText(chemin, jsonString);
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }


    /*
     * Représente une seule entrée de score
     */
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;

    }

}
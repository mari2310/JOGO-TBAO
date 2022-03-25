using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour
{

    public int totalScore;
    public static Gamecontroller instanse;
    public Text scoretext;

    // Start is called before the first frame update
    void Start()
    {
        instanse = this;
    }

    public void UpdateScoretext()
    {
        scoretext.text = totalScore.ToString();
    }
}

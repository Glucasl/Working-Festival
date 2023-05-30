using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTotal : MonoBehaviour
{   
    public Text textTotalScore;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = SingletonManager.singleton.scoreGlobal;
        textTotalScore.text = score.ToString();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    Text scoreTxt;
    PlayerController reimu;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GameObject.Find("Score").GetComponent<Text>();
        reimu = GameObject.Find("Player").GetComponent<PlayerController>();

        
;    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score: " + score;
    }
}

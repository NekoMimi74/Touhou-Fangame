using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyController : MonoBehaviour
{
    public float timer;

    ScoreController score;
    BossController remilia;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Player Info").GetComponent<ScoreController>();
        remilia = GameObject.Find("Remilia").GetComponent<BossController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0){
            Destroy(transform.gameObject);
        }

        timer -= 1 * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Bullet"){
            Destroy(transform.gameObject);
            score.score += 1;
        }
    }
}

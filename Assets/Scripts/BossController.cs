using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int HP;
    public GameObject bullet;
    public float bulletStartPostion; // The y value
    public float fireRate;
    private float fire;
    public int sec; // Sec til fire

    // Boss Movement
    // Public Vars
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed;

    // Private Vars
    private Vector3 currentTarget;

    // to summon
    public float timerToSummon;
    private float timer;


    public bool isSummon;
    private int health;

    ScoreController score;

    Text bossTxt;
    Text bossHP;

    AudioSource death;
    public AudioClip deathSound;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Player Info").GetComponent<ScoreController>();
        //isSummon = false; // just to make sure she is not summon
        health = HP;
        timer = timerToSummon;

        bossTxt = GameObject.Find("Remilia").GetComponent<Text>();
        bossHP = GameObject.Find("Boss HP").GetComponent<Text>();

        death = GetComponent<AudioSource>();

        bossTxt.text = "";
        bossHP.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        TimeToSummon();
        Shoot();
        Move();
    }

    void summon()
    {
        if (!isSummon)
        {
            transform.position = new Vector3(0, 4, 0);
        }
    }

    void TimeToSummon(){
        if(timer <= 0){
            isSummon = true;
            summon();
            bossTxt.text = "Remilia Scarlet";
            bossHP.text = "HP: " + health;
        } else {
            timer -= 1 * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            health--;

            if (health <= 0)
            {
                //Destroy(transform.gameObject);
                transform.position = new Vector3(0, 10, 0);
                health = HP;
                isSummon = false;
                bossTxt.text = "";
                bossHP.text = "";
                timer = timerToSummon;
                death.PlayOneShot(deathSound);
                score.score += 20;
            }
        }
    }

    void Shoot()
    {
        // Shoot bullets
        if (isSummon)
        {
            if (fire <= 0)
            {
                GameObject g = Instantiate(bullet);

                g.transform.position = new Vector3(transform.position.x, bulletStartPostion, 0);
                fire = sec;
            }
            else
            {
                fire -= fireRate * Time.deltaTime;
            }
        }
    }

    void Move()
    {
        if (isSummon)
        {
            Vector3 toTarget = currentTarget - transform.position;
            Vector3 frameStep = toTarget.normalized * speed * Time.deltaTime;
            if (frameStep.magnitude > 0 && frameStep.magnitude < toTarget.magnitude)
            {
                transform.position += frameStep;
            }
            else
            {
                transform.position = currentTarget; // snap to target
                if (currentTarget == pointA)
                {
                    currentTarget = pointB;
                }
                else
                {
                    currentTarget = pointA;
                }
            }
        }
    }
}

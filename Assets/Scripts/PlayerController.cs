using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public float bulletStartPostion; // The y value
    public float fireRate;
    public int sec; // Sec til fire
    public int HP;
    AudioSource death;
    public AudioClip deathSound;
    private float onDeath;

    private float fire;

    Text playerHP;

    // Start is called before the first frame update
    void Start()
    {
        fire = sec;

        playerHP = GameObject.Find("HP").GetComponent<Text>();

        death = GetComponent<AudioSource>();
        onDeath = 5;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement, only on x-axis
        float h = Input.GetAxis("Horizontal");

        transform.position += new Vector3(h, 0, 0) * speed * Time.deltaTime;

        Shoot();

        playerHP.text = "HP: " + HP;
    }

    void Shoot(){
        // Shoot bullets
        if(Input.GetButton("Jump")){
            if(fire <= 0){
                GameObject g = Instantiate(bullet);

                g.transform.position = new Vector3(transform.position.x, bulletStartPostion,0);
                fire = sec;
            } else {
                fire -= fireRate* Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        HP--;

        if(HP <= 0){
            death.PlayOneShot(deathSound);
            playerHP.text = "GameOver!";
            //

            Destroy(transform.gameObject);

            Time.timeScale = 0;
        }
    }
}

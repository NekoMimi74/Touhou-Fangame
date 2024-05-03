using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairySpawner : MonoBehaviour
{
    public GameObject fairy;
    public float spawnTimer;

    private float countDown;
    // Start is called before the first frame update
    void Start()
    {
        countDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown <= 0){
            GameObject f = Instantiate(fairy);
            float r = Random.Range(-4, 5);
            //Vector2 fa = new Vector2(r, transform.position.y);

            f.transform.position = new Vector3(r, transform.position.y, 0);
            countDown = spawnTimer;
        } else {
            countDown -= 1 * Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBoom : MonoBehaviour
{
    public GameObject Boom;
    public GameController gamecontrol;
    public float GameOverTime;
    public Obstacle obs;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Player>().PlaySound(1);
        Debug.Log("Boom!");
        Instantiate(Boom, gameObject.transform.position, Quaternion.identity);

        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(GetComponent<Player>(),2);

        gamecontrol.ShowEndMenu();

    }

    

    // Start is called before the first frame update
    void Start()
    {
        obs = GameObject.Find("SpawnPoint").GetComponent<Obstacle>();
        gamecontrol = GameObject.Find("EventSystem").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

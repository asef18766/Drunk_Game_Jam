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
        Debug.Log("Boom!");
        Instantiate(Boom, gameObject.transform.position, Quaternion.identity);

        gameObject.SetActive(false);
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

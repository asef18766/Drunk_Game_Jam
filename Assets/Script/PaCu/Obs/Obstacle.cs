﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public GameObject[] Objects;

    public Transform[] Points;
    public GameController gamecontrol;

    public float TimeControl;
    public float GameClearTime;

    bool f;
    float start;
    bool[] check = new bool[3];
    public enum SpeedLevel {    
                                ten_sec,
                                five_sec,
                                two_sec,
                                dif_ten,
                                dif_five,
                                dif_two
                            };

    


    private IEnumerator Create()
    {
        while(true)
        {
            int Random_Objects = Random.Range(0, Objects.Length);
        

            int Random_Points = Random.Range(0, 3);

            GameObject NewObs = Instantiate(Objects[Random_Objects],
                                            Points[Random_Points].transform.position,
                                            Points[Random_Points].transform.rotation);
            NewObs.GetComponent<ObsMove>().speed += TimeControl / 3;
            float Random_time = Random.Range(1, 5);

            if (TimeControl - start < 1)
            {
                
                check[Random_Points] = true;
                for (int i = 0; i < 3; i++)
                    if (!check[i])
                        f = true;
                if (f)
                {
                    Debug.Log("Rainbow");
                }

            }
            else 
            {
                start = TimeControl;
                for (int i = 0; i < 3; i++)
                    check[i] = false;
            }
            yield return new WaitForSeconds(Random_time);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
        gamecontrol = GameObject.Find("EventSystem").GetComponent<GameController>();
     
    }
    public GameObject light;
    public void GameEndCheck()
    {
        if(TimeControl >= GameClearTime )
        {
          //  Debug.Log(GameObject.Find("Canvas/EndMenu") + "Check");
            Instantiate(light,new Vector3(0,0,0),Quaternion.identity);
            if (GameObject.Find("Canvas/EndMenu")?.activeInHierarchy == false || GameObject.Find("Canvas/EndMenu") == null)
            {
               // Debug.Log(GameObject.Find("CheckEndMenu")+ "Load");
                SceneManager.LoadScene("Ani02");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        TimeControl += Time.deltaTime;
        GameEndCheck();
    }
}

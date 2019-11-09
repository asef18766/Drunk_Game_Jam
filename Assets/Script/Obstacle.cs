using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject[] Objects;

    public Transform[] Points;

    public float TimeControl;
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
            int Random_Objects = 0;//Random.Range(0, 1);
        

            int Random_Points = Random.Range(0, 3);

            GameObject NewObs = Instantiate(Objects[Random_Objects],
                                            Points[Random_Points].transform.position,
                                            Points[Random_Points].transform.rotation);
            NewObs.GetComponent<ObsMove>().speed += TimeControl / 5;
            float Random_time = Random.Range(3, 6);
            yield return new WaitForSeconds(Random_time);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
     
    }

    // Update is called once per frame
    void Update()
    {
        TimeControl += Time.deltaTime;
    }
}

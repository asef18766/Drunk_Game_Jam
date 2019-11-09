using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject[] Objects;

    public Transform[] Points;

    public float TimeControl = 10;

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

        int Random_Objects = Random.Range(0, 2);
        if (Random_Objects == 0)
        {
            Debug.Log("Fish Bone");
        }
        else
        {
            Debug.Log("Dried Fish");
        }
        
        int Random_Points = Random.Range(0, 3);

        if (Random_Points == 0)
        {
            Debug.Log("Up trace");
        }
        else if (Random_Points == 1)
        {
            Debug.Log("MId trace");
        }
        else
        {
            Debug.Log("Down trace");
        }

        Instantiate(Objects[Random_Objects], 
                    Points[Random_Points].transform.position, 
                    Points[Random_Points].transform.rotation);
        
        yield return new WaitForSeconds(TimeControl);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

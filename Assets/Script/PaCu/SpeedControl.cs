using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    public Animation AniAutoMove;
    
    private IEnumerator SpeedUp()
    {
        while(true)
        {
            AniAutoMove["PlayerMove"].speed += 0.5f;
            yield return new WaitForSeconds(50);
            Debug.Log("Speed:"+ AniAutoMove["PlayerMove"].speed);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpeedUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorItem : MonoBehaviour
{
    public GameObject[] items;


    public int cnt = 0;
    
    IEnumerator Create()
    {
        while (cnt < 1000000)
        {
            GameObject a = Instantiate(items[Random.Range(0, 9)], transform.position, Quaternion.identity);

            yield return new WaitForSeconds(2);
            cnt++;
        }
    }

 /*   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision)
        {
            Instantiate(items[Random.Range(0, 8)], transform.position, Quaternion.identity);
        }

    }
*/
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

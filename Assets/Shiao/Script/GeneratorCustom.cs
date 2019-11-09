using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCustom : MonoBehaviour
{
    public GameObject[] custom;
    public Seat[] seat;
    public int seat_cnt;
    private static GeneratorCustom instance;
    public static GeneratorCustom Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        seat_cnt = seat.Length;
        StartCoroutine(Create());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Seat Fnd()
    {
        for (int i = 0; i < seat.Length; i++)
        {
            if (seat[i].empty)
            {

                seat[i].empty = false;
                return seat[i];
            }
        }
        return null;
    }
    IEnumerator Create()
    {
        while (seat_cnt > 0)
        {
            GameObject a = Instantiate(custom[0], transform.position, Quaternion.identity); // 生成顧客並傳入a

            a.GetComponent<Custom>().seat = Fnd(); // a 的 seat 為 fnd() 的回傳值
            yield return new WaitForSeconds(1);
            seat_cnt--;
        }
    }
}

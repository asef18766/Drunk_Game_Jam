using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTitle : MonoBehaviour
{
    public float hueDelta;
    [SerializeField]
    private SpriteRenderer rainbowClear;
    [SerializeField]
    private SpriteRenderer rainbowBlur;

    [Header("Star Parameter")]
    public GameObject star;
    [Header("Positions")]
    public float initX;
    public float upY;
    public float downY;
    [Header("frequency")]
    public int maxCount;
    public float interval;

    private void Start()
    {
        StartCoroutine(spawnStar());
    }

    // Update is called once per frame
    void Update()
    {
        float h, s, v;
        Color.RGBToHSV(rainbowClear.color, out h, out s, out v);

        h = Mathf.Repeat(h + hueDelta * Time.deltaTime, 1.0f);
        Color newColor = Color.HSVToRGB(h, s, v);

        rainbowBlur.color = newColor;
        rainbowClear.color = newColor;
    }

    private IEnumerator spawnStar()
    {
        while(true)
        {
            int cnt = Random.Range(0, maxCount + 1);
            for(int _=0 ; _<cnt ; _++)
            {
                float y = Random.Range(downY, upY);
                Instantiate(star, new Vector3(initX, y, -1), Quaternion.identity);
            }

            yield return new WaitForSeconds(interval);
        }
    }
}

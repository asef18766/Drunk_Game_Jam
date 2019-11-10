using UnityEngine;

public class GoldenFigure : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    public GameObject firerainbow;
    void Start()
    {
        player = GetComponent<Player>();
    }

    public void ShotFireRainbow()
    {

        bool check = (player.CurPlayerState == PlayerState.SpecialSkillActive);
        if(check)
            Debug.Log(check);
        if (check)
        {
            Instantiate(firerainbow, transform.position, Quaternion.identity);
            Debug.Log("newrainbow");
        }
    }


    // Update is called once per frame
    void LateUpdate()
    {
        ShotFireRainbow();
    }
}

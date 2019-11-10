using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    SpecialSkillActive,
    MovUp,
    MovDown,
    None
}
public class Player : MonoBehaviour
{
    private enum track
    {
        Up,
        Mid,
        Down
    }
    [SerializeField] double mov_dis=0;
    [SerializeField] double mov_time=0;
    [SerializeField] track cur_track;
    [SerializeField] KeyRecorder keyRecorder;
    public GameObject firerainbow;
    // Start is called before the first frame update
    public PlayerState CurPlayerState;
    public GameObject Light;
    public bool blocked=false;
    IEnumerator timer()
    {
        blocked=true;
        yield return new WaitForSeconds((float)mov_time);
        blocked=false;
    }
    [SerializeField]double RemainTime;
    IEnumerator moving(bool dir)
    {
        while(RemainTime>=0)
        {
            double time=Time.deltaTime;
            double v=mov_dis/mov_time;
            RemainTime-=time;
            transform.position+=new Vector3(0,((dir)? 1:-1)*(float)(v*time),0);
        }
        CurPlayerState=PlayerState.None;
        yield return null;
    }
    void ChangeTrack(bool dir)
    {
        if(dir)
        {
            if(cur_track==track.Down)
                cur_track=track.Mid;
            else if(cur_track==track.Mid)
                cur_track=track.Up;
        }
        else
        {
            if(cur_track==track.Mid)
                cur_track=track.Down;
            else if(cur_track==track.Up)
                cur_track=track.Mid;
                 
        }
    }
    void MovDir(bool dir) // up == true , down == false
    {
        if(blocked)
            return;
        
        if(cur_track==track.Down && dir==false)
        {
            return;
        }
            
        if(cur_track==track.Up   && dir==true )
        {
            return;
        }

        
        RemainTime=mov_time;
        StartCoroutine(timer());
        StartCoroutine(moving(dir));
        ChangeTrack(dir);
    }
    void UpdateState()
    {
        if(keyRecorder.specialskill())
        {

            Instantiate(Light, gameObject.transform.position, Quaternion.identity);
            Instantiate(firerainbow, transform.position, Quaternion.identity);

            CurPlayerState =PlayerState.SpecialSkillActive;
            RaycastHit2D[] raycast=Physics2D.CircleCastAll(transform.position,10000f,Vector2.down);
            foreach(var i in raycast)
            {
                if(i.collider.gameObject.tag=="Obstacle")
                {
                    Destroy(i.collider.gameObject);
                }
                    
            }
                
            return;
        }
        
        if(Input.GetKey(KeyCode.W))
        {
            CurPlayerState=PlayerState.MovUp;
            MovDir(true);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            CurPlayerState=PlayerState.MovDown;
            MovDir(false);
        }
        else
        {
            CurPlayerState=PlayerState.None;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }
}

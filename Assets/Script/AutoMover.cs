using UnityEngine;
public class AutoMover:MonoBehaviour
{
    [SerializeField] double MovRate = 1;
    [SerializeField] Vector3 des;
    [SerializeField] Vector3 start;
    [SerializeField] GameObject ControledEntity;
    void Move()
    {
        double ori_x = ControledEntity.transform.position.x;
        ControledEntity.transform.position += new Vector3(0,(float)MovRate,0);
        double aft_x = ControledEntity.transform.position.x;
        double des_x = des.x;

        if((ori_x-des_x)*(aft_x-des_x)<0)
        {
            ControledEntity.transform.position = start;
        }
    }
    void Start()
    {
        ControledEntity.transform.position = start;
    }
    void Update()
    {
        Move();
    }
}
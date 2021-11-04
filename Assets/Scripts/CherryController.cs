using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    // Start is called before the first frame update
    private float countDown = 10f;
    [SerializeField]
    private GameObject cherry;
    private bool ready;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ready)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else if (countDown <= 0)    // 如果倒计时为 0 的时候
            {
                Instantiate(cherry, RandomDriction(), Quaternion.identity, transform.parent);
                ready = true;
            }
        }if (ready)
        {
            countDown = 10f;
            ready = false;
        }
        //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x);
        //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y);
    }
    private Vector3 RandomDriction()
    {
        int r = Random.Range(0, 2);
        switch (r)
        {
            case 0:
                return new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).x, Random.Range(-Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight)).y, Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight)).y));
            default:
                return new Vector3(Random.Range(-Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight)).x, Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight)).x), Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y);
            //case 2:
            //return new Vector3(Screen.width, Random.Range(0, Screen.height));
            //default:
                //return new Vector3(0, Random.Range(0, Screen.width));
        }
    }
}

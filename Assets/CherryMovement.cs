using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CherryMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 aim;
    private Vector3 midPoint;
    //private Tilemap map;
    void Start()
    {
        midPoint = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
        aim = midPoint - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += aim.normalized * Time.fixedDeltaTime;
    }
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

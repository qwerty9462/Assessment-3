using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeInd : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public int lifes;
    [SerializeField]
    private GameObject lifeIcon;
    public bool changed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changed) {
            for (int i = 0; i < lifes; i++)
            {
                Instantiate(lifeIcon, new Vector3(i * 0.2f, -5.5f, 0), Quaternion.identity, transform);
            }
            changed = false;
        }
    }
    public void refresh()
    {
        
    }
}

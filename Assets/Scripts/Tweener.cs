using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    // Start is called before the first frame update
    private Tween activeTween;
    //private float frames = 0;
    private float time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween != null) {
            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.01f)
            {
                //float fraction = frames / (activeTween.Duration * Application.targetFrameRate);
                //time += Time.deltaTime;
                float fraction = (Time.time - activeTween.StartTime) / activeTween.Duration;
                activeTween.Target.transform.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, fraction);

                //frames = (frames + 1) % ((activeTween.Duration * Application.targetFrameRate) + 1);
            }
            else
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
                //time = 0;
                //frames = 0;
            }
        }
    }
    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
        }
        
    }
}

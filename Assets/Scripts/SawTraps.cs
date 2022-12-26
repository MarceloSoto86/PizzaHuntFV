/** using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SawTraps : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float lerpSpeed = 0.5f;
    [SerializeField] GameObject pointA, pointB;
    [SerializeField] AnimationCurve _curve;
    [SerializeField] private float _current = 0f, _target = 1f;
    void Update()
    {
        //_target = Random.value;
        //_current = Mathf.MoveTowards(_current, _target, speed * Time.deltaTime);
        //float z = Mathf.PingPong(Time.time * speed, 1) * 5.24f - 0.12f;
        //transform.position = Vector3.Lerp(pointA.transform.position, pointB.transform.position, _curve.Evaluate(_current));
        //transform.position = new Vector3(z, transform.position.y, transform.position.z);
        float y = Mathf.PingPong(Time.time * speed, 1) * 2.24f - 1.12f;
        transform.position = Vector3.Lerp(transform.position, pointA.transform.position, y);
    }
}
** */

using UnityEngine;
using System.Collections;

public class SawTraps : MonoBehaviour
{


    public Transform targetPos;
    public Transform startPos;

    bool towards = true;
    public float speed = 0.1f;

    void Update()
    {

        if (towards)
        {
            transform.LookAt(targetPos.position);
            transform.position += transform.forward * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, targetPos.position) < 1.0f)
            {
                towards = false;
            }
        }
        else
        {
            transform.LookAt(startPos.position);
            transform.position += transform.forward * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, startPos.position) < 1.0f)
            {
                {
                    towards = true;
                }
            }
        }
    }

}





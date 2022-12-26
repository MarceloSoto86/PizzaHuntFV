using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawnerBoss : MonoBehaviour
{
    [SerializeField] GameObject sawPrebaf;
    [SerializeField] int sawAmount = 10;
    [SerializeField] float next_spawn_time, spawn_rate, endAngle = 270f, startAngle = 90f;
    // Start is called before the first frame update
    void Start()
    {
        //start off with next spawn time being 'in 1 seconds'
        next_spawn_time = Time.time + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_spawn_time)
        {
            SawSpawner();
    
            //saw.transform.rotation = Quaternion.Euler(90, transform.rotation.y, transform.rotation.z);
            //saw.GetComponent<Rigidbody>().velocity= Vector3.forward * 50;
            //saw.transform.Translate(Vector3.forward * 20f * Time.deltaTime, Space.Self);
            next_spawn_time += spawn_rate;
        }
    }

    void SawSpawner()
    {
        float angleStep = endAngle / sawAmount;
        float angle = startAngle;
                
        for (int i = 0; i < sawAmount +1; i++)
        {
            float sawDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float sawDirZ = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 sawMoveVector = new Vector3(sawDirX, sawDirZ, 0f);
            Vector2 sawDir = (sawMoveVector - transform.position).normalized;

            GameObject saw = Instantiate(sawPrebaf);
            saw.transform.position = transform.position;
            saw.transform.rotation = transform.rotation;
            saw.GetComponent<SawMovement>().SetMoveDirection(sawDir);

            angle += angleStep;

        }
    }
}

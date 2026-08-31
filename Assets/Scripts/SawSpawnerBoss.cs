using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawnerBoss : MonoBehaviour
{
    //Este script se encarga de instanciar sierras en un patrón circular alrededor del objeto al que está adjunto. Las sierras se instancian a intervalos regulares de tiempo y se mueven en direcciones específicas basadas en ángulos calculados.
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
        //check if it's time to spawn a new saw
        if (Time.time > next_spawn_time)
        {
            SawSpawner();
            next_spawn_time += spawn_rate;
        }
    }

    // This method spawns saws in a circular pattern around the object. It calculates the direction for each saw based on the specified angles and instantiates them with the appropriate movement direction.
    void SawSpawner()
    {
        float angleStep = endAngle / sawAmount; // Calculate the angle step based on the total angle and the number of saws to spawn
        float angle = startAngle; // Initialize the starting angle for spawning saws

        // Loop through the number of saws to spawn and instantiate them with calculated directions
        for (int i = 0; i < sawAmount +1; i++)
        {
            float sawDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f); // Calculate the X direction for the saw based on the angle
            float sawDirZ = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f); // Calculate the Z direction for the saw based on the angle

            Vector3 sawMoveVector = new Vector3(sawDirX, sawDirZ, 0f); // Create a vector for the saw's movement direction based on the calculated X and Z directions
            Vector2 sawDir = (sawMoveVector - transform.position).normalized; // Calculate the normalized direction vector for the saw's movement

            GameObject saw = Instantiate(sawPrebaf); // Instantiate a new saw prefab
            saw.transform.position = transform.position; // Set the position of the saw to the position of the spawner
            saw.transform.rotation = transform.rotation; // Set the rotation of the saw to the rotation of the spawner
            saw.GetComponent<SawMovement>().SetMoveDirection(sawDir); // Set the movement direction of the saw using the calculated direction vector

            angle += angleStep; // Increment the angle for the next saw to be spawned

        }
    }
}

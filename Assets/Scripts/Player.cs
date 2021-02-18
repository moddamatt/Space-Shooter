using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Variables to fine tune the player
    // Tip: private variables should start with an _
    [SerializeField]
    private float _speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Take current position and assing it a new postion to 
        // (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * _speed * Time.deltaTime);
        */

        // Example of a optimized oneliner making future garbage collection easier
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime);

        // Player bounds
        // Simply based on cords as veiwed from camera in editor
        if (transform.position.y >= 0)
        { transform.position = new Vector3(transform.position.x, 0, 0); }
        else if (transform.position.y >= -3.0f)
        { transform.position = new Vector3(transform.position.x, -3.0f, 0); }

        if (transform.position.x >= 10.0f)
        { transform.position = new Vector3(-transform.position.x, transform.position.y, 0); }
        else if (transform.position.x <= -10.0f)
        { transform.position = new Vector3(-transform.position.x, transform.position.y, 0); }
    }
}

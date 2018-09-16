using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

 
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    Rigidbody rigidbody;
    AudioSource rocketSound;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	private void Update () {
        Thrust();
        Rotate();
	}

    void OnCollisionEnter(Collision collision) {
        switch(collision.gameObject.tag) {
            case "Friendly":
                print("You am OK!");
                break;
            default:
                print("You have dead");
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!rocketSound.isPlaying)
            {
                rocketSound.Play();
            }

            rigidbody.AddRelativeForce(Vector3.up * mainThrust);
        }
        else
        {
            rocketSound.Stop();
        }
    }

    private void Rotate()
    {
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        // Take manual control of rotation
        rigidbody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        rigidbody.freezeRotation = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour
{
    [SerializeField] float Thrust;
    [SerializeField] float Rotation;
    [SerializeField] ParticleSystem sidethrusterParticles;
    [SerializeField] ParticleSystem MainthrusterParticles;
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] AudioClip mainengine;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        processInput();
        processThrust();
    }

    public void processInput()
    {
        float Rotationspeed = Rotation * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.freezeRotation = true;
            transform.Rotate(0, 0, Rotationspeed);
            if (sidethrusterParticles.isPlaying == false)
            {
                sidethrusterParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.freezeRotation = true;
            transform.Rotate(0, 0, -Rotationspeed);
            if (sidethrusterParticles.isPlaying == false)
            {
                sidethrusterParticles.Play();
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
            sidethrusterParticles.Stop();
        }

    }
    void processThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            Vector3 Force = Vector3.up + new Vector3(0, Thrust, 0) * Time.deltaTime;
            rb.AddRelativeForce(Force);
            if (audioSource.isPlaying == false)
            {
                audioSource.PlayOneShot(mainengine);
            }
            if (MainthrusterParticles.isPlaying == false)
            {
                MainthrusterParticles.Play();
            }
        }
        else
        {
            audioSource.Pause();
            MainthrusterParticles.Stop();
        }
    }
}
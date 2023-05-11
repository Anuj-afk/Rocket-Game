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
            rotating(Rotationspeed);
            particlesplayer();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rotating(-Rotationspeed);
            particlesplayer();
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
            sidethrusterParticles.Stop();
        }
    }

    private void particlesplayer()
    {
        if (sidethrusterParticles.isPlaying == false)
        {
            sidethrusterParticles.Play();
        }
    }

    private void rotating(float Rotationspeed)
    {
        rb.freezeRotation = true;
        transform.Rotate(0, 0, Rotationspeed);
    }

    void processThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Startthrust();
        }
        else
        {
            audioSource.Pause();
            MainthrusterParticles.Stop();
        }
    }

    private void Startthrust()
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
}
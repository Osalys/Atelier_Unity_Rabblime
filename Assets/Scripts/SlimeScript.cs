using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public Transform target;
    private Vector3 targetPos;

    private Vector3 randomTargetPos;
    public float randomTargetDistMin = 2;
    public float randomTargetDistMax = 5;
    public bool useRandomTarget = false;

    public float distStop = 1;
    public float distSlowDown = 2;
    public float vitesse = 0;
    public float vitesseMax = 1.0f;
    public float vitesseMin = 0.1f;
    public float acceleration = 1.0f;

    private bool atDestination = false;


    Animator evilSlimeAnimator;
    AudioSource slimeAudioSource;

    [SerializeField] AudioClip sndJump;

    private void Awake()
    {
        evilSlimeAnimator = GetComponent<Animator>();
        slimeAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetRandomTargetPos();
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            useRandomTarget = true;
        }

        //calcul du point de destination

        if (useRandomTarget || target == null)
        {
            targetPos = randomTargetPos;
        }

        else
        {
            targetPos = target.position;
        }

        //Distance au point 
        Vector3 deplacement = targetPos - transform.position;
        float distance = deplacement.magnitude;
        float distanceRestante = distance - distStop;
        atDestination = distanceRestante <= 0;

        //Déplacement
        if (!atDestination)
        {
            float vitesseVoulue = vitesseMax;
            if (distanceRestante < distSlowDown - distStop)
            {
                vitesseVoulue = Mathf.Lerp(vitesseMax, vitesseMin, 1.0f - (distanceRestante / (distSlowDown - distStop)));
            }

            if (vitesseVoulue > vitesse)
            {
                vitesse = Mathf.Min(vitesse + acceleration * Time.deltaTime, vitesseVoulue);
            }

            else
            {
                vitesse = vitesseVoulue; 
            }
           
            deplacement = deplacement.normalized * vitesse * Time.deltaTime;
            transform.position += deplacement;
            evilSlimeAnimator.SetBool("move", true);

        }

        else
        {
            SetRandomTargetPos();
        }
        
    }

    void SetRandomTargetPos()
    {
        randomTargetPos = Random.onUnitSphere;
        randomTargetPos = randomTargetPos.normalized * Random.Range(randomTargetDistMin, randomTargetDistMax);
    }

    //degat des lapins slimes
    void OnCollisionEnter (Collision other)
    {
        HenryController player = other.gameObject.GetComponent<HenryController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }

        if(other.collider.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }



    //sonorisation des lapins slime
    public void PlayJumpSteps()
    {
        slimeAudioSource.spatialBlend = 1;
        slimeAudioSource.minDistance = 0.2f;
        slimeAudioSource.maxDistance = 2.0f;
        slimeAudioSource.pitch = 1f;
        slimeAudioSource.PlayOneShot(sndJump);
    }
}

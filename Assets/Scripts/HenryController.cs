using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenryController : MonoBehaviour
{
    public int maxHealth = 5;
    int currentHealth;

    public int maxSeed = 3;
    public int seed { get { return currentSeed; } }
    int currentSeed;

    public int maxCarrot = 10;
    public int carrot { get { return currentCarrot; } }
    int currentCarrot;

    float axisH, axisV;
    Animator henryAnimator;

    [SerializeField] float walkSpeed = 2f, runSpeed = 8f, rotate = 80f, jumpForce = 350;

    const float timeout = 5.0f;
    [SerializeField] float countdown = timeout;

    AudioSource henryAudioSource;
    [SerializeField] AudioClip sndLeftFoot, sndRightFoot, sndImpact, sndJump;
    bool switchFoot = false;

    Rigidbody rb;

    private void Awake()
    {
        henryAnimator = GetComponent<Animator>();
        henryAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Start ()
    {
        currentHealth = maxHealth;
        currentSeed = 0;
        currentCarrot = 0;
    }

    void Update()
    {
        axisH = Input.GetAxis("Horizontal");
        axisV = Input.GetAxis("Vertical");

        //Course et marche avant
        if (axisV > 0)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.Translate(Vector3.forward * runSpeed * axisV * Time.deltaTime);
                henryAnimator.SetFloat("run", axisV);
            }

            else
            {
                transform.Translate(Vector3.forward * walkSpeed * axisV * Time.deltaTime);
                henryAnimator.SetBool("walk", true);
                henryAnimator.SetFloat("run", 0);
            }
           
        }

        else
        {
            henryAnimator.SetBool("walk", false);
        }
        

        //Marche droite et gauche
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
            henryAnimator.SetBool("walkRight", true);
        }

        else
        {
            henryAnimator.SetBool("walkRight", false);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
            henryAnimator.SetBool("walkLeft", true);
        }

        else
        {
            henryAnimator.SetBool("walkLeft", false);
        }


        //Marche arrière
        if (axisV < 0)
        {
             transform.Translate(Vector3.forward * walkSpeed * axisV * Time.deltaTime);
             henryAnimator.SetBool("walkBack", true);
        }

        else
        {
            henryAnimator.SetBool("walkBack", false);
        }
        
        //Rotation 
        transform.Rotate(Vector3.up * rotate * Time.deltaTime * axisH);


        //Attente
        if (axisH == 0 && axisV == 0)
        {
            countdown -= Time.deltaTime;

            if(countdown <= 0)
            {
                henryAnimator.SetBool("wave", true); 
            }
        }

        else
        {
            henryAnimator.SetBool("wave", false);
            countdown = timeout;
            
        }

        //Saut
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
            henryAudioSource.volume = 0.5f;
            henryAudioSource.pitch = 1f;
            henryAnimator.SetTrigger("jump");
            henryAudioSource.PlayOneShot(sndJump);
        }

        
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    // Nombre de graines
    public void ChangeSeed(int amount)
    {
        currentSeed = Mathf.Clamp(currentSeed + amount, 0, maxSeed);
        Debug.Log(currentSeed + "/" + maxSeed);
    }

    public void ChangeCarrot(int amount)
    {
        currentCarrot = Mathf.Clamp(currentCarrot + amount, 0, maxCarrot);
        Debug.Log(currentCarrot + "/" + maxCarrot);
    }

    //Planter une graine
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.Find("Plantations").GetComponent<PlantationScript>().CanPlant == true)
        {
            if (other.tag =="Plantation")
            {
                henryAnimator.SetTrigger("plant");
                Debug.Log("plantation");

            }
        }
        
    }

  

    public void PlaySoundImpact()
    {
        henryAudioSource.volume = 0.5f;
        henryAudioSource.pitch = 1f;
        henryAudioSource.PlayOneShot(sndImpact);
    }

    public void PlayFootStep()
    {
        if (!henryAudioSource.isPlaying)
        {
            switchFoot = !switchFoot;

            if (switchFoot)
            {
                henryAudioSource.volume = 1f;
                henryAudioSource.pitch = 2f;
                henryAudioSource.PlayOneShot(sndLeftFoot);
            }

            else
            {
                henryAudioSource.volume = 1f;
                henryAudioSource.pitch = 2f;
                henryAudioSource.PlayOneShot(sndRightFoot);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UFO : MonoBehaviour
{
    private Rigidbody rigidBody;


    [SerializeField] private float rotSpeed = 100f;
    [SerializeField] float flySpeed = 10f;
    [SerializeField] Text energyText;
    [SerializeField] ParticleSystem jetParticle;
    [SerializeField] GameObject boomParticle;

    [SerializeField] int EnergyTotal = 200;
    [SerializeField] int EnergyApply = 20;
    [SerializeField] int EnergyPlus = 40;

    public List<GameObject> portalsParticle = new List<GameObject>();
    public GameObject portal;

    private float yRange = 49.5f;
    private float xRange = 58.0f;

    bool isCollision = true;
    private bool isActive = true;

    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Rotation();
        Launch();
        DebugKeys();
        RangePosition();
    }



    private void OnCollisionEnter(Collision collision)
    {
       
        switch (collision.gameObject.tag)
        {

            case "Friendly":
                break;

            case "Battery":
                break;

            case "Finish":
                if (isCollision)
                {
                    SelectPortals();
                    Debug.Log("Finish");
                    isCollision = false;
                }
                break;

            default:
                if (isCollision)
                {
                    Lose();
                    GameManager.Instance.CurrentGameState = GameManager.GameState.GameOver;
                    isCollision = false;
                }
                break;
        }
    }
        

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            AddEnergy(EnergyPlus, other.gameObject);
            //SoundManager.Instance.PlaySound(SoundManager.Instance.addBonusSound);

        }
        if (other.gameObject.CompareTag("DeathTrigger"))
            GameManager.Instance.LoadFirstLevel();
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.GameOver)
        {
            GameManager.Instance.LoadFirstLevel();
            Debug.Log("XXX");
        }
    }

    void Launch()
    {
        if (Input.GetKey(KeyCode.Space) && EnergyTotal > 0 && isActive)
        {
            rigidBody.AddRelativeForce(Vector3.up * flySpeed * Time.deltaTime);
            Energy();
            jetParticle.Play();
            //SoundManager.Instance.PlaySound(SoundManager.Instance.flySound);
        }
        else
        {
            jetParticle.Stop();
        }        
    }

    void Rotation()
    {
        float rotationSpeed = rotSpeed * Time.deltaTime;

        rigidBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {

            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        rigidBody.freezeRotation = false;
    }


    void Lose()
    {
        GameManager.Instance.Invoke("LoadFirstLevel", 1.5f);
        jetParticle.Stop();
        boomParticle.SetActive(true);
        isActive = false;
        //SoundManager.Instance.PlaySound(SoundManager.Instance.boomSound);



    }


    private void Energy()
    {
        EnergyTotal -= Mathf.RoundToInt(EnergyApply * Time.deltaTime);
        energyText.text = "Energy: " + EnergyTotal.ToString();
    }

    void AddEnergy(int energyToAdd, GameObject batteryObj)
    {
        batteryObj.GetComponent<BoxCollider>().enabled = false;
        EnergyTotal += energyToAdd;
        Destroy(batteryObj);
    }


    void DebugKeys()
    {
        if (Input.GetKey(KeyCode.L))
        {
            GameManager.Instance.LoadNextLevel();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            isCollision = !isCollision;
        }
    }

    private void RangePosition()
    {
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
    }

    private void SelectPortals()
    {
        int random = Random.Range(0, portalsParticle.Count);
        //portalsParticle[random].SetActive(true);
        portal.SetActive(true);
        GameManager.Instance.LoadNextLevel();

    }
}

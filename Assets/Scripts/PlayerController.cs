using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private GameObject camera;
    [SerializeField] private int damage = 0;
    [SerializeField] private Text healthTxt;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private GameObject antidotePrefab;
    [SerializeField] private Text deathTimerTxt;
    [SerializeField] private float timeToDeath = 10f;
    [SerializeField] private int enemyDamage = 10;

    [SerializeField] private GameObject gameOverUI, gamePlayUI;

    private bool attack = false;
    private CharacterController cc;
    private float xRotation = 0f;
    private Animator animator;
    private int health = 100;
    private bool entered = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((health > 0 || entered) && !animator.GetBool("Death"))
        {
            healthTxt.text = health.ToString();

            PlayerMovement();

            PlayerRotation();

            if (Input.GetMouseButtonDown(0) == true)
            {
                animator.SetBool("Attack", true);
                animator.SetInteger("AR", Random.Range(1, 4));
                attack = true;
            }
        }
        else if(timeToDeath > 0 && health <= 0 && entered == false)
        {
            animator.SetBool("Hit", true);
            Instantiate(antidotePrefab, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
            deathTimerTxt.gameObject.SetActive(true);
            //timeToDeath -= Time.deltaTime;
            deathTimerTxt.text = ((int)timeToDeath).ToString();
            entered = true;
        }
        if(timeToDeath <= 0)
        {
            animator.SetBool("Death", true);
            deathTimerTxt.gameObject.SetActive(false);
            entered = false;
            gamePlayUI.SetActive(false);
            gameOverUI.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
        }

        if (entered)
        {
            timeToDeath -= Time.deltaTime;
            deathTimerTxt.text = ((int)timeToDeath).ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && attack == true)
        {
            other.gameObject.GetComponent<EnemyController>().health -= damage;
        }
        if (other.gameObject.tag == "EnemySword")
        {
            if (GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>().attacking)
            {
                health -= enemyDamage;
            }
        }
        else if (other.gameObject.tag == "Antidote")
        {
            health = 100;

            timeToDeath = 10;
            deathTimerTxt.gameObject.SetActive(false);
            entered = false;
            Destroy(other.gameObject);
        }
    }

    private void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movementVector = transform.right * x + transform.forward * y;
        cc.Move(movementVector * Time.deltaTime * movementSpeed);
        animator.SetFloat("X", x);
        animator.SetFloat("Y", y);

        if (x == 0 && y == 0)
        {
            animator.SetBool("Run", false);
            
        }
        else
        {
            animator.SetBool("Run", true);
        }
    }

    private void PlayerRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -20f, 20f);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }

    public void AttackParaSetter()
    {
        animator.SetBool("Attack",false);
    }

    public void NotAttacking()
    {
        attack = false;
    }
    
    public void HitOff()
    {
        animator.SetBool("Hit", false);
    }
}

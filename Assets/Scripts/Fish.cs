using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    //veriables
    [SerializeField] float _speed;
    [SerializeField] AudioSource swim, hit, point;
    private int angle;
    private int maxAngle = 20;
    private int minAngle = -60;
    private bool touchedGround;
    // end of veriables

    //components
    Rigidbody2D _rb;
    //end of components

    //classes
    public Score score;
    public GameManager gameManager;
    public ObstacleSpawner obstacleSpawner;
    public Sprite fishDied;
    private SpriteRenderer spFish;
    private Animator fishAnim;
    //end of classes

 

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        //_rb.velocity = new Vector2(_rb.velocity.x, _speed);
        spFish = GetComponent<SpriteRenderer>();
        fishAnim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        FishSwim();

    }
    private void FixedUpdate()
    {
        FishRotation();

    }
    private void FishSwim()
    {

   
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            swim.Play();
            if (GameManager.gameStarted == false)
            {
                _rb.gravityScale = 4f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                swim.Play();
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
            }

            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x, 9f);
        }
    }

    private void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        if (touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Scored!");
            score.Scored();
            point.Play();
        }
        else if (collision.gameObject.CompareTag("Column") && GameManager.gameOver == false)
        {
            //game over
            FishDieEffect();
            gameManager.GameOver();
            //GameOver();
        }
    }

    void FishDieEffect()
    {
        hit.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                //game over
                FishDieEffect();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                //game over(fish)
                GameOver();

            }
        }
    }

    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        spFish.sprite = fishDied;
        fishAnim.enabled = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class PacStudentController : MonoBehaviour
{

    [SerializeField]
    private AudioSource Audio;
    [SerializeField]
    private AudioClip eating;
    [SerializeField]
    private AudioClip hitWall;
    [SerializeField]
    private AudioClip notEating;
    [SerializeField]
    private AudioClip dead;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GridLayout gridLayout;
    [SerializeField]
    private Tilemap map;
    //[SerializeField]
    //private Effector2D dust;

    private Tweener tweener;
    private Vector3 nextCell;
    private Animator anim;
    private Vector3 moveDir;
    private int Score = 0;

    private bool canMove;
    private bool isDead;
    private Vector3 lastInput;
    private Vector3 currentInput;

    float time;

    private GameObject temp;

    // Start is called before the first frame update
    private void Awake()
    {
        //Application.targetFrameRate = 60;
        //FindObjectsOfType(Tilemap);
        //map2.Equals(GameObject.Find("Tilemap2"));
        //map3.Equals(GameObject.Find("Tilemap3"));
        //map4.Equals(GameObject.Find("Tilemap4"));
    }
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        tweener = GetComponent<Tweener>();
        lastInput = Vector3Int.right;
        moveDir = lastInput;        
        canMove = true;
        Audio.clip = notEating;
        nextCell = transform.position;
        //Debug.Log(Application.targetFrameRate);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(map.GetTile(gridLayout.LocalToCell(nextCell)));
        GameObject.Find("CurrentScore").GetComponent<Text>().text = Score.ToString();
        time += Time.deltaTime;
        int minute = (int)time / 60;
        int second = (int)(time - minute * 60);
        int milisecond = (int)((time - (int)time) * 100);
        var text = string.Format("{0:D2}:{1:D2}:{2:D2}", minute, second, milisecond);
        //Debug.Log(text);
        GameObject.Find("Timer").GetComponent<Text>().text = text;
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = Vector3Int.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = Vector3Int.right;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = Vector3Int.down;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = Vector3Int.up;
        }
        moveDir = lastInput;
    
        if (transform.position == nextCell || !canMove)
        {

            
             nextCell = transform.position + moveDir * 0.18f;
            if (map.GetTile(gridLayout.LocalToCell(nextCell)).name.Equals("Walls_0"))
            {
                canMove = true;
                Debug.Log("a way");
            }
            else if (map.GetTile(gridLayout.LocalToCell(nextCell)).name.Equals("Walls_5"))
            {
                canMove = true;
                Debug.Log("a way");
            }
            else if (map.GetTile(gridLayout.LocalToCell(nextCell)).name.Equals("Walls_6"))
            {
                canMove = true;
                Debug.Log("a way");
            }
            else
            {
                canMove = false;
                Debug.Log("a wall");
            }
            Debug.Log(canMove);
            Debug.Log(nextCell);
            if (canMove) tweener.AddTween(transform, transform.position, nextCell, 1f/speed);

            if (canMove)
            {
                Audio.clip = notEating;
                if (!Audio.isPlaying) Audio.Play();
                Audio.loop = true;
                anim.SetBool("CanTurn", true);
                GameObject.Find("dust").GetComponent<ParticleSystem>().Play();
            }
            else if (!canMove && Audio.clip != hitWall)
            {
                Audio.clip = hitWall;
                Audio.Play();
                Audio.loop = false;
                anim.SetBool("CanTurn", false);
                GameObject.Find("dust").GetComponent<ParticleSystem>().Stop();
            }
        }

        

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Normal pellet(Clone)")
        {
            Score += 10;
            Debug.Log("score + 10");
            Audio.clip = eating;
            Audio.Play();
            Audio.loop = false;
            Destroy(other.gameObject);
        }
        if (other.name == "Power pellet(Clone)")
        {
            Destroy(other.gameObject);
        }
        if (other.name == "cherry(Clone)")
        {
            Score += 100;
            Debug.Log("score + 10");
            Audio.clip = eating;
            Audio.Play();
            Audio.loop = false;
            Destroy(other.gameObject);
            Destroy(other.gameObject);
        }
        if (other.name.StartsWith("Ghost"))
        {
            anim.Play("PacManDie");
            canMove = false;
            Audio.clip = dead;
            GameObject.Find("Life").GetComponent<lifeInd>().lifes -= 1;
            GameObject.Find("Life").GetComponent<lifeInd>().changed = true;
            Audio.Play();
            Audio.loop = false;
            isDead = true;
        }

    }
}

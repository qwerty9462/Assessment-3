using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private Tweener tweener;
    private Vector3 nextCell;
    private Animator anim;
    private Vector3 moveDir;
   
    private bool canMove;
    private bool isDead;
    private Vector3 lastInput;
    private Vector3 currentInput;

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
        Debug.Log(map.GetTile(gridLayout.LocalToCell(nextCell)));

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
            }
            else if (!canMove && Audio.clip != hitWall)
            {
                Audio.clip = hitWall;
                Audio.Play();
                Audio.loop = false;
                anim.SetBool("CanTurn", false);
            }
        }

    }
}

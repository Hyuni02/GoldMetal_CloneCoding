using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAction : MonoBehaviour
{
    public float speed = 3;
    float h, v;
    Rigidbody2D rigid;
    bool isHorizonMove;
    bool hDown, vDown, hUp, vUp;
    Animator animator;
    Vector3 dirVec;
    GameObject scanedObj;
    public GameManager gameManager;


    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        h = gameManager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = gameManager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        hDown = gameManager.isAction ? false : Input.GetButtonDown("Horizontal");
        vDown = gameManager.isAction ? false : Input.GetButtonDown("Vertical");
        hUp = gameManager.isAction ? false : Input.GetButtonUp("Horizontal");
        vUp = gameManager.isAction ? false : Input.GetButtonUp("Vertical");

        if (hDown) {
            isHorizonMove = true;
        }
        else if(vDown) {
            isHorizonMove = false;
        }
        else if(hUp || vUp) {
            isHorizonMove = h != 0;
        }
        if(animator.GetInteger("hAxisRaw") != h) {
            animator.SetBool("IsChange", true);
            animator.SetInteger("hAxisRaw", (int)h);
        }
        else if(animator.GetInteger("vAxisRaw") != v) {
            animator.SetBool("IsChange", true);
            animator.SetInteger("vAxisRaw", (int)v);
        }
        else {
            animator.SetBool("IsChange", false);
        }
        
        if(vDown && v == 1) {
            dirVec = Vector3.up;
        }
        else if (vDown && v == -1) {
            dirVec = Vector3.down;
        }
        else if (hDown && h == -1) {
            dirVec = Vector3.left;
        }
        else if (hDown && h == 1) {
            dirVec = Vector3.right;
        }

        if (Input.GetButtonDown("Jump") && scanedObj != null) {
            gameManager.Action(scanedObj);
        }
    }

    private void FixedUpdate() {
        Vector2 moveVec = isHorizonMove?new Vector2(h,0):new Vector2(0,v);
        rigid.velocity = moveVec * speed;

        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D hit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));
        if(hit.collider != null) {
            scanedObj = hit.collider.gameObject;
        }
        else {
            scanedObj=null;
        }
    }
}

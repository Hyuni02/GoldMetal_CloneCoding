using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAction : MonoBehaviour
{
    public float speed = 3;
    float h, v;
    Rigidbody2D rigid;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate() {
        rigid.velocity = new Vector2 (h, v) * speed;
    }
}

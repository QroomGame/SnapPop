using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    // Use this for initialization
    private bool canProp = true;
    Rigidbody2D rg2d;
    public float force = 100;
    public float sideForce = 1;
    float moveL = 0;
    float moveR = 0;
    Transform t;
    Animator propulsor;
    Animator helixLeft;
    Animator helixRight;
    GameObject explotion;
    Vector3 posIni;
    SpriteRenderer sp;


    void Start() {
        t = transform;
        GameData.instance.shipTr = t;
        rg2d = GetComponent<Rigidbody2D>();
        propulsor = t.Find("propulsor").GetComponent<Animator>();
        helixLeft = t.Find("helixLeft").GetComponent<Animator>();
        helixRight = t.Find("helixRight").GetComponent<Animator>();
        explotion = t.Find("explosion").gameObject;
        posIni = t.position;
        sp = GetComponent<SpriteRenderer>();
    }

    public void Restart() {
        explotion.SetActive(false);
        sp.enabled = true;
        propulsor.gameObject.SetActive(true);
        helixLeft.gameObject.SetActive(true);
        helixRight.gameObject.SetActive(true);
        t.position = posIni;
        canProp = true;
    }

    // Update is called once per frame
    void FixedUpdate() {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            if (canProp) {
                
                canProp = false;
                DoPropulsion();
            }
        }
        Vector3 rot = t.localEulerAngles;
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) { 
            moveL = -sideForce;
            rot.z = 10;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) {
            moveL = 0;
            rot.z = 0;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            moveR = sideForce;
            rot.z = -10;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) {
            moveR = 0;
            rot.z = 0;
        }

        t.localEulerAngles = rot;

        if (!canProp) {
            Vector3 pos = t.position;
            pos.x += moveL + moveR;
            t.position = pos;
        }
        
        if (moveL != 0) {
            helixLeft.SetBool("move", true);
            
        } else {
            helixLeft.SetBool("move", false);
        }

        if (moveR != 0) {
            helixRight.SetBool("move", true);
        } else {
            helixRight.SetBool("move", false);
        }

    }

    void DoPropulsion() {
        rg2d.AddForce(Vector2.up * force);
        propulsor.SetTrigger("in");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
       
        if (collision.gameObject.layer == LayerMask.NameToLayer("platform")) {
            canProp = true;
            
            if (collision.transform.name== "floor" && collision.relativeVelocity.magnitude>=10) {
                Explode();
            }
            
        }
    }

    void Explode() {

       GameObject.FindObjectOfType<GameManager>().GameOver();

        explotion.SetActive(true);
        sp.enabled = false;
        propulsor.gameObject.SetActive(false);
        helixLeft.gameObject.SetActive(false);
        helixRight.gameObject.SetActive(false);

    }

 
}

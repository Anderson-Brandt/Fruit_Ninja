using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rig;
    private CircleCollider2D circleColl;

    public bool isCuting;

    private Camera cam;

    private Vector2 lastPos;

    public float minVelocityCut;

    public GameObject linePrefab;
    private GameObject currentLine;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rig = GetComponent<Rigidbody2D>();
        circleColl = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCut();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCut();
        }

        if (isCuting)
        {
            UpdateCut();
        }
    }

    public void UpdateCut()
    {
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rig.position = newPos;

        float velocity = (newPos - lastPos).magnitude * Time.deltaTime;

        if(velocity > minVelocityCut)
        {
            circleColl.enabled = true;

        }
        else
        {
            circleColl.enabled = false;
        }

        lastPos = newPos;
    }

    public void StartCut()
    {
        isCuting = true;

        currentLine = Instantiate(linePrefab, transform);

        circleColl.enabled = true;
        lastPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void StopCut()
    {
        isCuting = false;

        currentLine.transform.SetParent(null);
        Destroy(currentLine, 2f);

        circleColl.enabled = false;
    }
}

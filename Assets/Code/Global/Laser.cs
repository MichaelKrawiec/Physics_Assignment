using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laser : MonoBehaviour
{

    public Camera cam;
    public LineRenderer LineRenderer;
    public Transform Firepoint;
    public GameObject StartVFX;
    public GameObject EndVFX;
    public GameObject Particles2;
    public GameObject LaserLight;

    public LayerMask HitMask;

    private Quaternion rotation;
    private List<ParticleSystem> particles = new List<ParticleSystem>();
    

    // Start is called before the first frame update
    void Start()
    {
        FillLists();
        DisableLaser();
        Particles2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            EnableLaser();
        }

        if (Input.GetButton("Fire1"))
        {
            UpdateLaser();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            DisableLaser();
        }

        RotateToMouse();
    }

    void EnableLaser()
    {
        LineRenderer.enabled = true;

        for(int i=0; i<particles.Count; i++)
            particles[i].Play();
        LaserLight.SetActive(true);
    }

    void UpdateLaser()
    {
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

        LineRenderer.SetPosition(0, Firepoint.position);

        LineRenderer.SetPosition(1, mousePos);

        int HitMask = 1 << 9;
        //HitMask = ~HitMask;

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude, HitMask);

        
        if (hit)
        {
            LineRenderer.SetPosition(1, hit.point);
            Particles2.SetActive(true);
        }
        else
        {
            Particles2.SetActive(false);
        }


        StartVFX.transform.position = (Vector2)Firepoint.position;
        EndVFX.transform.position = LineRenderer.GetPosition(1);
    }

    void DisableLaser()
    {
        LineRenderer.enabled = false;
        for (int i = 0; i < particles.Count; i++)
            particles[i].Stop();
        LaserLight.SetActive(false);
    }
    
    void RotateToMouse()
    {
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0, 0, angle -90);
        transform.rotation = rotation;
    }

    void FillLists()
    {
        for(int i=0; i<StartVFX.transform.childCount; i++)
        {
            var ps = StartVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null)
            {
                particles.Add(ps);
            }
        }

        for (int i = 0; i<EndVFX.transform.childCount; i++)
        {
            var ps = EndVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
            {
                particles.Add(ps);
            }
        }
    }
}

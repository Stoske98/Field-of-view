using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public Transform player;
    private Vector3 razdaljina;
    public float vidoKrug = 5;
    public float speedBot = 5;
    public float angle;
    [Range(0, 360)]
    public float ugaoVidljivosti = 160;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        razdaljina = player.position - transform.position;

        if (vidoKrug > razdaljina.magnitude)
        {
             angle = Vector3.Angle(transform.forward, razdaljina.normalized);
         
            if (angle < ugaoVidljivosti / 2)
            {
                transform.LookAt(player);
                transform.position += razdaljina.normalized * speedBot * Time.deltaTime;
            }


        }
        
    }
    void OnDrawGizmosSelected()
    {
        if (player != null)
        {
            // Draws a blue line from this transform to the target

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, player.position);

            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * vidoKrug);

            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, vidoKrug);

            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.position, vectorAngle((/*angle + */90 - ugaoVidljivosti / 2 - transform.rotation.eulerAngles.y) * Mathf.Deg2Rad, vidoKrug, transform.position));

            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.position, vectorAngle((/*angle + */90 + ugaoVidljivosti / 2 - transform.rotation.eulerAngles.y) * Mathf.Deg2Rad, vidoKrug, transform.position));


        }
    }

    public Vector3 vectorAngle(float angle, float magnituda, Vector3 center)
    {
        float x = magnituda * Mathf.Cos(angle);
        float z = magnituda * Mathf.Sin(angle);
        return new Vector3(center.x + x, center.y, center.z + z);
    }
}
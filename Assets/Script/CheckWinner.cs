using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinner : MonoBehaviour
{
    public static CheckWinner instance;

    public Camera defaultCamera;
    public Camera winnerCamera;
    public bool isWinner = false;

    public Transform target;
    public float smoothspeed = 1.0f;

    private void Awake()
    {
      instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultCamera.enabled = true;
        winnerCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWinner)
        {
            defaultCamera.enabled = false;
            winnerCamera.enabled = true;
        }
    }

    private void LateUpdate()
    {
        if (target != null && isWinner)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, target.position.z-3f);
            Vector3 smoothedPosition = Vector3.Lerp(winnerCamera.transform.position, desiredPosition, smoothspeed * Time.deltaTime);
            winnerCamera.transform.position = smoothedPosition;
        }
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.CompareTag("Player") && PlayerController.instance.groundedPlayer)
        {
            isWinner = true;
        }
    }
}

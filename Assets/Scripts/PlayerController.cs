using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Speed Setting")]
    [Space]
    public float startSpeed;
    public float currentSpeed;
    public float maxSpeed;
    public float acceleration;
    public float decelaration;

    [Header("Layers")]
    [Space]
    public int collectiblesLayer;

    public Transform moneySpawnPos;

    public static PlayerController Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Accelerate();
        }
        else
        {
            Decelarate();
        }
    }

    public void Accelerate()
    {
        GameplayPanelControl.Instance.GameStarted();

        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, startSpeed, maxSpeed);

        transform.position += transform.forward * currentSpeed * Time.deltaTime;
    }

    public void Decelarate()
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= decelaration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        transform.position += transform.forward * currentSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == collectiblesLayer)
        {
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
            MoneyManager.Instance.StartCoroutine(MoneyManager.Instance.GetMoney());

        }
    }
}

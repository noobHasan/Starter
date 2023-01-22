using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyTween : MonoBehaviour
{
    [Header("Settings for Move Money")]
    [SerializeField] private Vector3 moneyRotationDegree;
    [SerializeField] private float moneyRotationDuration;
    [SerializeField] private Ease moneyRotationEase;
    [SerializeField] private float moveDuration;
    [SerializeField] private Ease moveEase;

    public Vector3 MoneyRotationDegree { get { return moneyRotationDegree; } }
    public float MoneyRotationDuration { get { return moneyRotationDuration; } }
    public Ease MoneyRotationEase { get { return moneyRotationEase; } }
    public float MoveDuration { get { return moveDuration; } }
    public Ease MoveEase { get { return moveEase; } }

    [Header("Settings for Shake Money")]
    [SerializeField] private float shakeMoneyDuration;
    [SerializeField] private float shakeMoneyStrength;
    [SerializeField] private int shakeMoneyVibrato;
    [SerializeField] private float shakeMoneyRandomness;

    public float ShakeMoneyDuration { get { return shakeMoneyDuration; } }
    public float ShakeMoneyStrength { get { return shakeMoneyStrength; } }
    public int ShakeMoneyVibrato { get { return shakeMoneyVibrato; } }
    public float ShakeMoneyRandomness { get { return shakeMoneyRandomness; } }
}

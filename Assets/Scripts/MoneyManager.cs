using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{

    [Header("Objects for Money")]
    public Image moneyImage;
    public GameObject moneyIcon;
    public TextMeshProUGUI moneyText;
    public List<Transform> moneyList = new List<Transform>();

    [Header("Variables for Money")]
    public int money;
    public Transform moneySpawnPos;
    private int currentMoneyIndex;

    [Header("Scripts")]
    [SerializeField] private MoneyTween _moneyTweenScr;

    public static MoneyManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateMoneyList();
        moneyText.text = money.ToString();
    }

    public void CreateMoneyList()
    {
        for (int i = 0; i < 10; i++)
        {
            Transform money = Instantiate(moneyIcon.transform);
            money.SetParent(moneySpawnPos);
            money.transform.localPosition = moneySpawnPos.transform.localPosition;
            money.gameObject.SetActive(false);
            moneyList.Add(money);
        }
    }

    public IEnumerator GetMoney() 
    {
        GameObject _money = moneyList[currentMoneyIndex].gameObject;
        currentMoneyIndex++;
        _money.SetActive(true);

        //_money.transform.DOLocalJump(new Vector3(0, 2f, 0), 3f, 1, 0.5f, false);
        yield return new WaitForSeconds(0.5f);

        _money.transform.DORotate(_moneyTweenScr.MoneyRotationDegree, _moneyTweenScr.MoneyRotationDuration, 
            RotateMode.WorldAxisAdd).SetEase(_moneyTweenScr.MoneyRotationEase);


        _money.transform.DOMove(moneyIcon.transform.position,_moneyTweenScr.MoveDuration).SetEase(_moneyTweenScr.MoveEase);
        yield return new WaitForSeconds(_moneyTweenScr.MoveDuration);

        Destroy(_money);

        money += 10;
        moneyText.text = $"{money}";

        moneyIcon.transform.DOShakeScale(_moneyTweenScr.ShakeMoneyDuration, _moneyTweenScr.ShakeMoneyStrength, 
            _moneyTweenScr.ShakeMoneyVibrato, _moneyTweenScr.ShakeMoneyRandomness);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public Joystick josytick;
    public Transform stackPos;
    public int maxPickedBoxList = 5;
    public List<Transform> pickedBoxList = new List<Transform>();
    public float stackUpScale;
    public static PlayerMovement Instance;

    [Header("Layers")]
    public int collectibleBoxLayer;

    public Material boxMaterial;

    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pickedBoxList.Count; i++)
        {
            if (i>0)
            {
                stackUpScale += .2f;
            }
            else
            {
                stackUpScale = 0;
            }

            pickedBoxList[i].transform.position = Vector3.Lerp(pickedBoxList[i].transform.position, stackPos.transform.position + Vector3.up * stackUpScale, 0.2f);
        }

        Movement();
    }

    public void Movement()
    {
        float horizontalInput = josytick.Horizontal;
        float verticalInput = josytick.Vertical;

        transform.position = new Vector3(transform.position.x + horizontalInput * speed * Time.deltaTime, 
            transform.position.y, transform.position.z + verticalInput * speed * Time.deltaTime);


    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == collectibleBoxLayer)
        {
            StartCoroutine(CollectBoxes(col));
        }
    }

    public IEnumerator CollectBoxes(Collider col)
    {
        CollectibleBox collectibleBoxScr = col.gameObject.GetComponent<CollectibleBox>();

        for (int i = 0; i < collectibleBoxScr.collectibleBoxList.Count; i++)
        {
            Transform g = collectibleBoxScr.collectibleBoxList[collectibleBoxScr.collectibleBoxList.Count - 1];
            collectibleBoxScr.collectibleBoxList.Remove(g);

            g.transform.DOMove(stackPos.position, 0.1f).OnComplete(() => {
                pickedBoxList.Add(g);
                g.transform.SetParent(stackPos.transform);
                g.transform.rotation = stackPos.transform.rotation;

            });
            StartCoroutine(boxAnimation());
            yield return new WaitForSeconds(0.2f);
        }

    }

    private IEnumerator boxAnimation()
    {
        for (int i = 0; i < pickedBoxList.Count; i++)
        {
            pickedBoxList[i].transform.DOScale(1.5f, 0.1f).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                pickedBoxList[i].transform.DOScale(1f, 0.1f).SetEase(Ease.OutCubic);
            });
            yield return new WaitForSeconds(0.1f);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HandTutorialControl : MonoBehaviour
{
    public Image Hand;
    public Image HandSlider;

    public void DisablePanel()
    {
        Hand.DOFade(0f, .25f);
        HandSlider.DOFade(0f, .25f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }


    public void EnableHandAnimation()
    {
        Sequence handAnim = DOTween.Sequence();
        handAnim.Append(Hand.transform.DORotate(new Vector3(0f, 0f, -35f), .5f).SetEase(Ease.InOutQuad));
        handAnim.Insert(.2f, Hand.rectTransform.DOAnchorPosX(-120f, 1f).SetEase(Ease.InSine));
        handAnim.Append(Hand.transform.DORotate(new Vector3(0f, 0f, 35f), .5f).SetEase(Ease.InOutQuad));
        handAnim.Insert(1.55f, Hand.rectTransform.DOAnchorPosX(120f, 1f).SetEase(Ease.InSine));
        handAnim.SetLoops(-1, LoopType.Restart);
    }
}

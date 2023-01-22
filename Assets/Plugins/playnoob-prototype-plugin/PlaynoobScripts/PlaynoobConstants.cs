using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public static class PlaynoobConstants
{
    //TODO: Add any constant name you want to use repeatadly without mistake
    public static string CurrentLevel = "CurrentLevel";
    public static string GamesPlayed = "GamesPlayed";

    public static void FadeInOutAnimation(TextMeshProUGUI TextToFade, float to, float time)
    {
        TextToFade.DOFade(to, time).SetLoops(-1, LoopType.Yoyo).SetId(TextToFade.gameObject.name);
    }



}
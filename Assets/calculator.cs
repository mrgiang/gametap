using UnityEngine;
using System.Collections;

public class calculator : MonoBehaviour {
    public int[] arraySpriteLenght = new int[44] {144,128,112,96,96,128,96,96,88,120,
                                          144,96,112,112,48,96,80,96,72,64,
                                          56,96,160,128,96,96,104,128,112,88,
                                          88,88,88,120,120,88,88,88,88,120,
                                          120,120,120,72};
    public int[] arrayAllFrame = new int[44] {18,16,14,12,12,16,12,12,11,15,
                                          18,12,14,14,6,12,10,12,9,8,
                                          7,12,20,16,12,12,13,16,14,11,
                                          11,11,11,15,15,11,11,11,11,15,
                                          15,15,15,9};
    public int[] Attack = new int[] {0,1,2,3,4,5,6,11,12,15,23,24,25,26,27};
    public int[] Dead = new int[] {7,8,9,10,13};
    public int[] Hit = new int[] {14,18,19,20,21};
    public int[] Run = new int[] {16,29,30,31,32};
    public int[] Stand = new int[] {28,33,34,35,36,37,38};
    public int[] Walk = new int[] {17,39,40,41,42};
    public int Jump = 22;
    public int Sleep = 43;
    // Q 0,7,18,24,29,35,39
    //*************************************************
    public int[] arraySpriteName = new int[44] { 3759, 3760, 3761, 3762, 3763, 3764, 3765, 3766, 3767, 3768, 3769,
                                               3770, 3771, 3772, 3773, 3774, 3775, 3776, 3777, 3778, 3779,
                                               3780, 3781, 3782, 3783, 3784, 3785, 3786, 3787, 3788, 3789,
                                               3790, 3791, 3792, 3793, 3794, 3795, 3796, 3797, 3798, 3799,
                                               3800, 3801, 3802 };
    public int[] array7SpriteNameBegin = new int[44] { 109, 97, 85, 73, 73, 97, 73, 73, 67, 91,
                                                  109, 73, 85, 85, 37, 73, 61, 73, 55, 49,
                                                  43, 73, 121, 97, 73, 73, 79, 97, 85, 67,
                                                  67, 67, 67, 91, 91, 67, 67, 67, 67, 91,
                                                  91, 91, 91, 55 };
    public int[] array7SpeiteNameEnd = new int[44] { 126, 112, 98, 84, 84, 112, 84, 84, 77, 105,
                                                     126, 84, 98, 98, 42, 84, 70, 84, 63, 56,
                                                     49, 84, 140, 112, 84, 84, 91, 112, 98, 77,
                                                     77, 77, 77, 105, 105, 77, 77, 77, 77, 105,
                                                     105, 105, 105, 63 };
    // Use this for initialization

    public int SpriteName = 3759;
    void Start () {
        GetarraySpriteName(SpriteName);
        PrintSpriteQuyen();
    }
	
	private void GetarraySpriteName(int SpriteNameBegin)
    {
        for (int i = 0; i < 44; i++)
        {
            arraySpriteName[i] = SpriteNameBegin + i;
        }
        Getarray7SpriteNameBegin();
    }
    private void Getarray7SpriteNameBegin()
    {
        for (int i = 0; i < 44; i++)
        {
            array7SpriteNameBegin[i] = arrayAllFrame[i] * 6 + 1;
        }
        Getarray7SpeiteNameEnd();
    }
    private void Getarray7SpeiteNameEnd()
    {
        for (int i = 0; i < 44; i++)
        {
            array7SpeiteNameEnd[i] = array7SpriteNameBegin[i] + (arrayAllFrame[i]-1);
        }
    }
    /////
    private void PrintSpriteQuyen()
    {
        int[] arrSprite = new int[] { 0, 7, 18, 24, 29, 35, 39 };
        string mess = "";
        string copy = "COPY ";
        string to = @" E:\my\gametap\Assets\Resources\Sprite";
        for (int i = 0; i < arrSprite.Length; i++)
        {
            for (int j = 0; j < arrayAllFrame[arrSprite[i]]; j++)
            {
                mess += copy + arraySpriteName[arrSprite[i]] + "-"+(array7SpriteNameBegin[arrSprite[i]]+j)+".png"+ to + "\n";
            }           
        }
        Debug.Log(mess);
       

        //3759-109-126,3760-97-112,3761-85-98,3762-73-84,3763-73-84,3764-97-112,3765-73-84
    }
}

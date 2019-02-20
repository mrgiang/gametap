using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AnimationInfo : MonoBehaviour
{
    public int CountAnim = 44;
    public int[] FrameAnim = new int[44]   {144,128,112,96,96,128,96,96,88,120,
                                            144,96,112,112,48,96,80,96,72,64,
                                            56,96,160,128,96,96,104,128,112,88,
                                            88,88,88,120,120,88,88,88,88,120,
                                            120,120,120,72};
    public InputField ipf_begin;
    public InputField ipf_end;
    public Text txtShow;
    public Text txtShow2;
    void Start()
    {
        ipf_begin.text = "3759";
        ipf_end.text = "3802";
        txtShow.text = "";
        txtShow2.text = "";
    }
    public void Doit()
    {
        if (String.IsNullOrEmpty(ipf_begin.text) || String.IsNullOrEmpty(ipf_end.text))
        {
            Debug.Log("chưa nhập thông số");
        }
        else
        {
            CalculaFrame();
        }
    }
    private void CalculaFrame()
    {
        int begin = int.Parse(ipf_begin.text);
        int end = int.Parse(ipf_end.text);
        for (int i = 0; i < CountAnim/2; i++)
        {
            FixedText(txtShow,i+1, begin + i , FrameAnim[i] , FrameAnim[i] / 8
               ,((FrameAnim[i] / 8) * 6 + 1) ,(FrameAnim[i] / 8) * 7);
        }
        for (int i = 22; i < CountAnim; i++)
        {
            FixedText(txtShow2, i + 1, begin + i, FrameAnim[i], FrameAnim[i] / 8
               , ((FrameAnim[i] / 8) * 6 + 1), (FrameAnim[i] / 8) * 7);
        }
    }
    private void FixedText(Text text, int i,int name, int tong , int frame , int begin, int end)
    {
        text.text += i + ".";
        switch (CheckCount(name))
        {
            case 1: text.text += name + Space(1); break;
            case 2: text.text += name + Space(2); break;
            case 3: text.text += name + Space(3); break;
            case 4: text.text += name + Space(4); break;
            case 5: text.text += name + Space(5); break;
        }
        switch (CheckCount(tong))
        {
            case 1: text.text += tong + Space(1); break;
            case 2: text.text += tong + Space(2); break;
            case 3: text.text += tong + Space(3); break;
            case 4: text.text += tong + Space(4); break;
            case 5: text.text += tong + Space(5); break;
        }
        switch (CheckCount(frame))
        {
            case 1: text.text += frame + Space(1); break;
            case 2: text.text += frame + Space(2); break;
            case 3: text.text += frame + Space(3); break;
            case 4: text.text += frame + Space(4); break;
            case 5: text.text += frame + Space(5); break;
        }
        switch (CheckCount(begin))
        {
            case 1: text.text += begin + "-"; break;
            case 2: text.text += begin + "-"; break;
            case 3: text.text += begin + "-"; break;
            case 4: text.text += begin + "-"; break;
            case 5: text.text += begin + "-"; break;
        }
        switch (CheckCount(end))
        {
            case 1: text.text += end ; break;
            case 2: text.text += end ; break;
            case 3: text.text += end ; break;
            case 4: text.text += end ; break;
            case 5: text.text += end ; break;
        }
        text.text += "\n";
    }
    private int CheckCount(int check)
    {
        int count = 0;
        if(check < 10)
        {
            count = 1;
        }else if(check>=10 && check < 100)
        {
            count = 2;
        }else if(check >= 100 && check < 1000)
        {
            count = 3;
        }else if( check >= 1000 && check < 10000)
        {
            count = 4;
        }else if(check >= 10000)
        {
            count = 5;
        }
        return count;
    }
    private string Space(int count)
    {
        string s = "";
        switch(count)
        {
            case 1: s = "         "; break;
            case 2: s = "        "; break;
            case 3: s = "       "; break;
            case 4: s = "      "; break;
            case 5: s = "     "; break;
        }
        return s;
    }
}



using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class QuaternionMyDictionary : SerializableDictionary<int, AnimAsset> { }
public class TextAssetManager : MonoBehaviour
{
    public static TextAssetManager instance;
    public TextAssetInfo TextAssetInfo;
    public QuaternionMyDictionary dictBody = new QuaternionMyDictionary();
    public QuaternionMyDictionary dictHandleft = new QuaternionMyDictionary();
    public QuaternionMyDictionary dictHandright = new QuaternionMyDictionary();
    public QuaternionMyDictionary dictHead = new QuaternionMyDictionary();
    [Header("Array")]
    public int[] arrayAnim = new int[44] {144,128,112,96,96,128,96,96,88,120,
                                          144,96,112,112,48,96,80,96,72,64,
                                          56,96,160,128,96,96,104,128,112,88,
                                          88,88,88,120,120,88,88,88,88,120,
                                          120,120,120,72};
    public int[] arrayAnim1 = new int[45] {0,144,272,384,480,576,704,800,896,984,1104,
                                          1248,1344,1456,1568,1616,1712,1792,1888,1960,2024,
                                          2080,2176,2336,2464,2560,2656,2760,2888,3000,3088,
                                          3176,3264,3352,3472,3592,3680,3768,3856,3944,4064,4184,
                                          4304, 4424,4496};
    public int[] arrayAllFrame = new int[44] {18,16,14,12,12,16,12,12,11,15,
                                          18,12,14,14,6,12,10,12,9,8,
                                          7,12,20,16,12,12,13,16,14,11,
                                          11,11,11,15,15,11,11,11,11,15,
                                          15,15,15,9};
    //         Attack          Dead          Hit           Chuong           Run           Stand           Walk
    // quyen   0               7             18            24               29            35              39
    void Awake()
    {
        instance = this;
        dictBody.Add(3759,SetAnimAsset(TextAssetInfo.body.text, 3759));
        dictHandleft.Add(6021, SetAnimAsset(TextAssetInfo.handleft.text, 6021));
        dictHandright.Add(7153, SetAnimAsset(TextAssetInfo.handright.text, 7153));
        dictHead.Add(4257, SetAnimAsset(TextAssetInfo.head.text, 4257));

    }
    #region set norman
    public AnimAsset SetAnimAsset(string text ,int key)
    {
        AnimAsset AnimAsset = new AnimAsset();
        string[] array = text.Split('\n');

        for (int i = 0; i < arrayAnim.Length; i++)
        {
            for (int j = arrayAnim1[i] + 1; j <= arrayAnim1[i + 1]; j++)
            {
                //Debug.Log("i:"+i+"              j:"+j);
                string[] item = array[j - 1].Split('|');
                Setoffset setoffset = new Setoffset();
                setoffset.layer = int.Parse(item[0]);
                setoffset.vector3 = new Vector3(float.Parse(item[1]), float.Parse(item[2]), 0);
                AddAnimAsset(AnimAsset,i).Add(setoffset);
            }
        }
        for (int i = 0; i < arrayAnim.Length; i++)
        {
            for (int j = 0; j < arrayAnim[i]; j++)
            {
                var sprite = Resources.Load<Sprite>("Sprite/" + (key + i) + "-" + (j + 1));
                //Debug.Log(i + "|" + j + "   " + (key + i) + "   " + "Sprite/" + (key + i) + "-" + (j + 1));
                AddSpriteAnim(AnimAsset, i, sprite, j);
            }
        }

        return AnimAsset;
    }
    private List<Setoffset> AddAnimAsset(AnimAsset animAsset, int i)
    {
        switch (i)
        {
            case 0: return animAsset.AttackQuyen;
            case 1: return animAsset.AttackDao1; 
            case 2: return animAsset.AttackDao2; 
            case 3: return animAsset.AttackBong1; 
            case 4: return animAsset.AttackBong2; 
            case 5: return animAsset.AttackChuy1; 
            case 6: return animAsset.AttackChuy2; 
            case 7: return animAsset.DeadQuyen; 
            case 8: return animAsset.DeadDao; 
            case 9: return animAsset.DeadBong; 
            case 10: return animAsset.DeadChuy; 
            case 11: return animAsset.AttackPet1; 
            case 12: return animAsset.AttackPet2; 
            case 13: return animAsset.DeadPet; 
            case 14: return animAsset.HitPet; 
            case 15: return animAsset.AttackPetTieu; 
            case 16: return animAsset.PetRun; 
            case 17: return animAsset.PetWalk; 
            case 18: return animAsset.HitQuyen; 
            case 19: return animAsset.HitDao; 
            case 20: return animAsset.HitBong; 
            case 21: return animAsset.HitChuy; 
            case 22: return animAsset.Jump; 
            case 23: return animAsset.AttackTieu; 
            case 24: return animAsset.ChuongQuyen; 
            case 25: return animAsset.ChuongDao; 
            case 26: return animAsset.ChuongBong; 
            case 27: return animAsset.ChuongChuy; 
            case 28: return animAsset.PetStand; 
            case 29: return animAsset.RunQuyen; 
            case 30: return animAsset.RunDao; 
            case 31: return animAsset.RunBong; 
            case 32: return animAsset.RunChuy; 
            case 33: return animAsset.Stand1; 
            case 34: return animAsset.Stand2; 
            case 35: return animAsset.StandQuyen; 
            case 36: return animAsset.StandDao; 
            case 37: return animAsset.StandBong; 
            case 38: return animAsset.StandChuy; 
            case 39: return animAsset.WalkQuyen; 
            case 40: return animAsset.WalkDao; 
            case 41: return animAsset.WalkBong; 
            case 42: return animAsset.WalkChuy; 
            case 43: return animAsset.Thien; 
        }
        return null;
    }
    private void AddSpriteAnim(AnimAsset animAsset, int i,Sprite sprite ,int j)
    {
        switch (i)
        {
            case 0:  animAsset.AttackQuyen[j].sprite = sprite; break;
            case 1:  animAsset.AttackDao1[j].sprite = sprite; break;
            case 2:  animAsset.AttackDao2[j].sprite = sprite; break;
            case 3:  animAsset.AttackBong1[j].sprite = sprite; break;
            case 4:  animAsset.AttackBong2[j].sprite = sprite; break;
            case 5:  animAsset.AttackChuy1[j].sprite = sprite; break;
            case 6:  animAsset.AttackChuy2[j].sprite = sprite; break;
            case 7:  animAsset.DeadQuyen[j].sprite = sprite; break;
            case 8:  animAsset.DeadDao[j].sprite = sprite; break;
            case 9:  animAsset.DeadBong[j].sprite = sprite; break;
            case 10:  animAsset.DeadChuy[j].sprite = sprite; break;
            case 11:  animAsset.AttackPet1[j].sprite = sprite; break;
            case 12:  animAsset.AttackPet2[j].sprite = sprite; break;
            case 13:  animAsset.DeadPet[j].sprite = sprite; break;
            case 14:  animAsset.HitPet[j].sprite = sprite; break;
            case 15:  animAsset.AttackPetTieu[j].sprite = sprite; break;
            case 16:  animAsset.PetRun[j].sprite = sprite; break;
            case 17:  animAsset.PetWalk[j].sprite = sprite; break;
            case 18:  animAsset.HitQuyen[j].sprite = sprite; break;
            case 19:  animAsset.HitDao[j].sprite = sprite; break;
            case 20:  animAsset.HitBong[j].sprite = sprite; break;
            case 21:  animAsset.HitChuy[j].sprite = sprite; break;
            case 22:  animAsset.Jump[j].sprite = sprite; break;
            case 23:  animAsset.AttackTieu[j].sprite = sprite; break;
            case 24:  animAsset.ChuongQuyen[j].sprite = sprite; break;
            case 25:  animAsset.ChuongDao[j].sprite = sprite; break;
            case 26:  animAsset.ChuongBong[j].sprite = sprite; break;
            case 27:  animAsset.ChuongChuy[j].sprite = sprite; break;
            case 28:  animAsset.PetStand[j].sprite = sprite; break;
            case 29:  animAsset.RunQuyen[j].sprite = sprite; break;
            case 30:  animAsset.RunDao[j].sprite = sprite; break;
            case 31:  animAsset.RunBong[j].sprite = sprite; break;
            case 32:  animAsset.RunChuy[j].sprite = sprite; break;
            case 33:  animAsset.Stand1[j].sprite = sprite; break;
            case 34:  animAsset.Stand2[j].sprite = sprite; break;
            case 35:  animAsset.StandQuyen[j].sprite = sprite; break;
            case 36:  animAsset.StandDao[j].sprite = sprite; break;
            case 37:  animAsset.StandBong[j].sprite = sprite; break;
            case 38:  animAsset.StandChuy[j].sprite = sprite; break;
            case 39:  animAsset.WalkQuyen[j].sprite = sprite; break;
            case 40:  animAsset.WalkDao[j].sprite = sprite; break;
            case 41:  animAsset.WalkBong[j].sprite = sprite; break;
            case 42:  animAsset.WalkChuy[j].sprite = sprite; break;
            case 43:  animAsset.Thien[j].sprite = sprite; break;
        }
    }
    #endregion
}

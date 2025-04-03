using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 static public class PlayOnlyData
{
    //制限時間
    public const float TimeLimit = 60.0f;

    //個別制限時間
    public const float customerTimeLimit = 10.0f;

    //フルーツリスポーン時間
    public const float FruitsRespawnTime = 3.0f;

    //フルーツ持てる時間
    public const float FruitsCarryTime = 3.0f;

    //ーーー難易度によって変わるやつーーー
    //フルーツの種類数
    public static int FruitKinds = 0;
    //個別制限時間(割合)
    public static float customerTimeRatio = 0;
    //基礎点
    public static int BaseScore = 0;

    public static void DataSetting(int difficulty)
    {
        switch (difficulty)
        { 
        case 0:
            FruitKinds = 3;

            customerTimeRatio = 1.2f;
           
            BaseScore = 100;
            break;
          
        case 1:
                break;

        case 2:
                break;
                
        case 3:
                break; 
                

        }

    }



}

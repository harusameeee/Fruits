using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 static public class PlayOnlyData
{
    //��������
    public const float TimeLimit = 60.0f;

    //�ʐ�������
    public const float customerTimeLimit = 10.0f;

    //�t���[�c���X�|�[������
    public const float FruitsRespawnTime = 3.0f;

    //�t���[�c���Ă鎞��
    public const float FruitsCarryTime = 3.0f;

    //�[�[�[��Փx�ɂ���ĕς���[�[�[
    //�t���[�c�̎�ސ�
    public static int FruitKinds = 0;
    //�ʐ�������(����)
    public static float customerTimeRatio = 0;
    //��b�_
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

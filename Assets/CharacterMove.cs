using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    public int moveTime;
    public int roll_of_Dice;
    public int nowPos_num;
    public int terget_num;            

    Vector3 zero = new Vector3(0, 0, 0);
    Vector3 PlayerPos;
    Vector3 searchPos;
    Vector3 startPos = new Vector3(-7.8f, 0.0f);
    Vector3[] vin = new Vector3[32];
    Vector3[] vout = new Vector3[48];

    // mypositionに設定したstart positionを入れる
    void Start()
    {
        moveTime = 0;
        Transform myPosition = this.transform;
        myPosition.position = startPos;
        //vin 内側のひし形升
        vin[0] = new Vector3(-7.8f, 0.0f); // Aスタート
        vin[1] = new Vector3(-7f  , 1.7f); 
        vin[2] = new Vector3(-6f  , 2.3f);
        vin[3] = new Vector3(-5f  , 3f  );
        vin[4] = new Vector3(-4f  , 3.6f);
        vin[5] = new Vector3(-3f  , 4.3f);
        vin[6] = new Vector3(-2f  , 4.6f);
        vin[7] = new Vector3(-1f  , 5.5f);
        vin[8] = new Vector3( 0f  , 5.8f); // Bスタート
        vin[9] = new Vector3( 1f  , 5.1f); 
        vin[10] = new Vector3(2.4f, 4.8f);
        vin[11] = new Vector3(3.2f, 4.0f);
        vin[12] = new Vector3(4.3f, 3.2f);
        vin[13] = new Vector3(5.1f, 2.7f);
        vin[14] = new Vector3(6.2f, 1.9f);
        vin[15] = new Vector3(7.0f, 1.0f);
        vin[16] = new Vector3(8.0f, 0.0f); // Dスタート
        vin[17] = new Vector3(7.0f, -0.9f);
        vin[18] = new Vector3(5.8f, -1f);
        vin[19] = new Vector3(4.8f, -1.5f);
        vin[20] = new Vector3(3.9f, -2.3f);
        vin[21] = new Vector3(2.9f, -3.1f);
        vin[22] = new Vector3(2.0f, -3.6f);
        vin[23] = new Vector3(1.2f, -4.3f);
        vin[24] = new Vector3(0.0f, -5.4f); // Cスタート
        vin[25] = new Vector3(-0.8f, -4.0f);
        vin[26] = new Vector3(-1.7f, -3.3f);
        vin[27] = new Vector3(-2.8f, -2.7f);
        vin[28] = new Vector3(-3.8f, -2.1f);
        vin[29] = new Vector3(-4.7f, -1.5f);
        vin[30] = new Vector3(-5.7f, -0.6f);
        vin[31] = new Vector3(-6.6f, -0.3f);

        vout[1] = new Vector3(-8.6f, 1.2f);
        vout[2] = new Vector3(-8.6f, 2.4f);
        vout[3] = new Vector3(-8.6f, 3.6f);
        vout[4] = new Vector3(-8.6f, 4.8f);
        vout[5] = new Vector3(-8.6f, 6.0f); //左上角
        vout[6] = new Vector3(-6.9f, 6.0f);
        vout[7] = new Vector3(-5.9f, 6.0f);
        vout[8] = new Vector3(-4.9f, 6.0f);
        vout[9] = new Vector3(-3.5f, 6.0f);
        vout[10] = new Vector3(-2.3f, 6.0f);
        vout[11] = new Vector3(-1.1f, 6.0f);

        vout[13] = new Vector3(1.1f, 6.0f);
        vout[14] = new Vector3(2.3f, 6.0f);
        vout[15] = new Vector3(3.5f, 6.0f);
        vout[16] = new Vector3(4.9f, 6.0f);
        vout[17] = new Vector3(5.9f, 6.0f);
        vout[18] = new Vector3(6.9f, 6.0f);
        vout[19] = new Vector3(8.6f, 6.0f); //右上角
        vout[20] = new Vector3(8.6f, 4.8f);
        vout[21] = new Vector3(8.6f, 3.6f);
        vout[22] = new Vector3(8.6f, 2.4f);
        vout[23] = new Vector3(8.6f, 1.2f);

        vout[25] = new Vector3(8.6f, -1.0f);
        vout[26] = new Vector3(8.6f, -2.2f);
        vout[27] = new Vector3(8.6f, -3.4f);
        vout[28] = new Vector3(8.6f, -4.5f);
        vout[29] = new Vector3(8.6f, -6.0f); //右下角
        vout[30] = new Vector3(7.1f, -6.0f);
        vout[31] = new Vector3(5.8f, -6.0f);
        vout[32] = new Vector3(4.8f, -6.0f);
        vout[33] = new Vector3(3.5f, -6.0f);
        vout[34] = new Vector3(2.5f, -6.0f);
        vout[35] = new Vector3(1.5f, -6.0f);

        vout[36] = new Vector3(-1.2f, -6.0f);
        vout[37] = new Vector3(-2.2f, -6.0f);
        vout[38] = new Vector3(-3.5f, -6.0f);
        vout[39] = new Vector3(-4.5f, -6.0f);
        vout[40] = new Vector3(-5.8f, -6.0f);
        vout[41] = new Vector3(-7.0f, -6.0f);
        vout[42] = new Vector3(-8.6f, -6.0f); //左下角
        vout[43] = new Vector3(-8.6f, -4.5f);
        vout[44] = new Vector3(-8.6f, -3.3f);
        vout[44] = new Vector3(-8.6f, -2.2f);
        vout[44] = new Vector3(-8.6f, -1.1f);





    }


    // Update is called once per frame
    void Update()
    {

        Transform myPosition = this.transform;
        

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            roll_of_Dice = UnityEngine.Random.Range(1, 6);
            moveTime = roll_of_Dice;
            for (int i = 0; i < 33; i++) // 自分の座標がどの配列番号か判定(内側)
            {        
                if(vin[i] == myPosition.position)
                {
                    nowPos_num = i;
                    break;
                }
            }

            
            terget_num = nowPos_num + moveTime;//配列番号にサイコロの目を足す
            
            Vector3 pos = myPosition.position;
            pos.x = vin[terget_num].x;    // x座標
            pos.y = vin[terget_num].y;    // y座標
            pos.z += 0.0f;    // z座標は移動しない

            myPosition.position = pos;  // 座標を設定

            Debug.Log($"今{nowPos_num}");
            Debug.Log($"サイコロ {moveTime}");
            Debug.Log($"位置{myPosition.position}"); 
        
        }
    }
}
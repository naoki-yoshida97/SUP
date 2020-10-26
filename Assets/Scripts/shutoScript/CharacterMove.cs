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
    Vector3 startPos = new Vector3(-600f, -35f);
    Vector3[] vin = new Vector3[32];
    Vector3[] vout = new Vector3[48];
    Vector3[] aimV = new Vector3[30];

    // mypositionに設定したstart positionを入れる
    void Start()
    {
        moveTime = 0;
        Transform myPosition = this.transform;
        myPosition.position = startPos;

        //AimingBoard ----
        aimV[0] = new Vector3( -600f, 245f);
        aimV[1] = new Vector3( -500f, 245f);
        aimV[2] = new Vector3( -413f, 245f);
        aimV[3] = new Vector3( -330f, 245f);   
        aimV[4] = new Vector3( -250f, 245f);
        aimV[5] = new Vector3( -165f, 245f);
        aimV[6] = new Vector3(  -80f, 245f);
        aimV[7] = new Vector3(   -1f, 245f);
        aimV[8] = new Vector3(   85f, 245f);
        aimV[9] = new Vector3(  210f, 245f);
        aimV[9] = new Vector3(  210f, 245f);
        aimV[10] = new Vector3( 210f, 125f);
        aimV[11] = new Vector3( 210f,  40f);
        aimV[12] = new Vector3( 210f, -42f);
        aimV[13] = new Vector3( 210f,-125f);
        aimV[14] = new Vector3( 210f,-210f);
        aimV[15] = new Vector3( 210f,-325f);
        aimV[16] = new Vector3(  84f,-325f);
        aimV[17] = new Vector3(   1f,-325f);
        aimV[18] = new Vector3( -80f,-325f);
        aimV[19] = new Vector3(-161f,-325f);
        aimV[20] = new Vector3(-248f,-325f);
        aimV[21] = new Vector3(-333f,-325f);
        aimV[22] = new Vector3(-414f,-325f);
        aimV[23] = new Vector3(-500f,-325f);
        aimV[24] = new Vector3(-615f,-325f);
        aimV[25] = new Vector3(-615f,-205f);
        aimV[26] = new Vector3(-615f,-120f);
        aimV[27] = new Vector3(-615f, -43f);
        aimV[28] = new Vector3(-615f,  45f);
        aimV[29] = new Vector3(-615f, 125f);


        //CityBoardvin 内側のひし形升 ----
        vin[0] = new Vector3(-600f, -35f); // Aスタート
        vin[31] = new Vector3(-548f ,  5f); 
        vin[30] = new Vector3(-500f , 34f);
        vin[29] = new Vector3(-454f , 63f);
        vin[28] = new Vector3(-405f ,100f);
        vin[27] = new Vector3(-357f ,130f);
        vin[26] = new Vector3(-307f ,163f);
        vin[25] = new Vector3(-262f ,195f);
        vin[24] = new Vector3(-205f ,241f); // Bスタート
        vin[23] = new Vector3(-148f ,194f); 
        vin[22] = new Vector3(-100f,158f);
        vin[21] = new Vector3(-53f, 126f);
        vin[20] = new Vector3(-5f,   88f);
        vin[19] = new Vector3(43f,   54f);
        vin[18] = new Vector3(86f,   23f);
        vin[17] = new Vector3(138f, -13f);
        vin[16] = new Vector3(197f, -46f); // Dスタート
        vin[15] = new Vector3(143f, -90f);
        vin[14] = new Vector3(91f , -124f);
        vin[13] = new Vector3(45f,  -155f);
        vin[12] = new Vector3(-4f,  -187f);
        vin[11] = new Vector3(-55f, -223f);
        vin[10] = new Vector3(-102f,-253f);
        vin[9] = new Vector3(-148f,-283f);
        vin[8] = new Vector3(-203f, -320f); // Cスタート
        vin[7] = new Vector3(-264f, -280f);
        vin[6] = new Vector3(-304f, -248f);
        vin[5] = new Vector3(-356f, -215f);
        vin[4] = new Vector3(-405f, -178f);
        vin[3] = new Vector3(-454f, -145f);
        vin[2] = new Vector3(-503f, -110f);
        vin[1] = new Vector3(-545f, -77f);

        //--------

        vout[1] = new Vector3(-635f, 18f);
        vout[2] = new Vector3(-635f, 76f);
        vout[3] = new Vector3(-635f, 137f);
        vout[4] = new Vector3(-635f, 195f);
        vout[5] = new Vector3(-635f, 262f); //左上角
        vout[6] = new Vector3(-556f, 272f);
        vout[7] = new Vector3(-500f, 272f);
        vout[8] = new Vector3(-442f, 272f);
        vout[9] = new Vector3(-378f, 272f);
        vout[10] = new Vector3(-324f,272f);
        vout[11] = new Vector3(-264f,272f);

        vout[13] = new Vector3(-143f,272f);
        vout[14] = new Vector3(-86f, 272f);
        vout[15] = new Vector3(-25f, 272f);
        vout[16] = new Vector3(32f, 272f);
        vout[17] = new Vector3(91f, 272f);
        vout[18] = new Vector3(150f, 272f);
        vout[19] = new Vector3(224f, 272f); //右上角
        vout[20] = new Vector3(224f, 194f);
        vout[21] = new Vector3(224f, 135f);
        vout[22] = new Vector3(224f, 74f);
        vout[23] = new Vector3(224f, 17f);

        vout[25] = new Vector3(224f, -94f);
        vout[26] = new Vector3(224f, -154f);
        vout[27] = new Vector3(224f, -214f);
        vout[28] = new Vector3(224f, -273f);
        vout[29] = new Vector3(224f, -345f); //右下角
        vout[30] = new Vector3(148f, -345f);
        vout[31] = new Vector3(90f, -345f);
        vout[32] = new Vector3(31f, -345f);
        vout[33] = new Vector3(-28f, -345f);
        vout[34] = new Vector3(-88f, -345f);
        vout[35] = new Vector3(-142f, -345f);

        vout[36] = new Vector3(-268f, -345f);
        vout[37] = new Vector3(-323f, -345f);
        vout[38] = new Vector3(-382f, -345f);
        vout[39] = new Vector3(-440f, -345f);
        vout[40] = new Vector3(-499f, -345f);
        vout[41] = new Vector3(-557f, -345f);
        vout[42] = new Vector3(-635f, -345f); //左下角
        vout[43] = new Vector3(-635f, -270f);
        vout[44] = new Vector3(-635f, -212f);
        vout[44] = new Vector3(-635f, -154f);
        vout[44] = new Vector3(-635f, -96f);





    }


    // Update is called once per frame
    void Update()
    {

        Transform myPosition = this.transform;
        
        //プレイヤーが外を通っているか内を通っているかの判定
        if (Input.GetKeyDown(KeyCode.Return))
        {
            roll_of_Dice = UnityEngine.Random.Range(1, 6);
            moveTime = roll_of_Dice;     //サイコロの目が動く数とする
            for (int i = 0; i < 32; i++) // 自分の座標がどの配列番号か判定(内側)
            {        
                if(vin[i] == myPosition.position)
                {
                    nowPos_num = i;
                    break;
                }
            }
            terget_num = nowPos_num + moveTime;//配列番号にサイコロの目を足す
            
            if (terget_num > 31){
                terget_num = terget_num - 31;
            } 
　　　　　　　
            Vector3 pos = myPosition.position;
            pos.x = vin[terget_num].x;    // x座標
            pos.y = vin[terget_num].y;    // y座標
            pos.z += 0.0f;    // z座標は移動しない

            myPosition.position = pos;  // 座標を設定
            

            Debug.Log($"今{nowPos_num}");
            Debug.Log($"サイコロ {moveTime}");
            Debug.Log($"位置{myPosition.position}"); 
            //push確認
        }

        //--------外側の移動

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            roll_of_Dice = UnityEngine.Random.Range(1, 6);
            moveTime = roll_of_Dice;     //サイコロの目が動く数とする
            for (int i = 0; i < 48; i++) // 自分の座標がどの配列番号か判定(内側)
            {        
                if(vin[i] == myPosition.position)
                {
                    nowPos_num = i;
                    break;
                }
            }
            terget_num = nowPos_num + moveTime;//配列番号にサイコロの目を足す
            
            if (terget_num > 47){
                terget_num = terget_num - 47;
            } 
　　　　　　　
            Vector3 pos = myPosition.position;
            pos.x = vin[terget_num].x;    // x座標
            pos.y = vin[terget_num].y;    // y座標
            pos.z += 0.0f;    // z座標は移動しない

            myPosition.position = pos;  // 座標を設定
            

            Debug.Log($"今{nowPos_num}");
            Debug.Log($"サイコロ {moveTime}");
            Debug.Log($"位置{myPosition.position}"); 
            //push確認
        }
    
    //---移動後の自分の座標を判定 ---> 駒に応じたダイアログを発生


    }
}
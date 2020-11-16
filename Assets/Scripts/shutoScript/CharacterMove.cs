using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    //---variable----

    private int nowBranch;
    public int moveTime;
    public int roll_of_Dice;
    public int nowPos_num;
    public int terget_num;            

    Vector3 zero = new Vector3(0, 0, 0);
    Vector3 PlayerPos;
    Vector3 MovedPos;
    Vector3 searchPos;
    Vector3 startPos = new Vector3( -600f, 245f,-6f); //aiming start
    Vector3 Apoint = new Vector3(-600f,-35f,1f);
    Vector3 Bpoint = new Vector3(-205f ,241f,1f);
    Vector3 Cpoint = new Vector3(-203f, -320f,1f);
    Vector3 Dpoint = new Vector3(197f, -46f,1f);
    Vector3 AOUT = new Vector3(-635f,-45f); 
    Vector3 BOUT = new Vector3(-206f,275f);
    Vector3 COUT = new Vector3(-205f,-345f);
    Vector3 DOUT = new Vector3(226f, -40f);
    Vector3[] vin = new Vector3[32];
    Vector3[] vout = new Vector3[48];
    Vector3[] aimV = new Vector3[30];


    //-----method------
    
        // ダイアログを追加する親のCanvas
        [SerializeField] private Canvas par = default;
        // 表示するダイアログ
        [SerializeField] private OK dial = default;
    public void ShowDialog()
    {
        GameObject SampleDialog = Instantiate ((GameObject) Resources.Load ("SampleDia")) as GameObject;  
    }
    public void ShowOnly(){
        GameObject Showhide = GameObject.Find("ChangeBranch");
        Showhide.transform.localScale = new Vector3(1,1,1);
    }

    public void NoMove(){
        GameObject Showhide = GameObject.Find("ChangeBranch");
        Showhide.transform.localScale = new Vector3(0,0,0);
    }
    public void BranchChange(){
        //z座標を基準にどのコースにいるのか把握
        Transform PlayerTranse = this.transform;
        Vector3 ZVecterJudge = PlayerTranse.position;
        
        //ボタンを押したときの操作

        //nowBranch aiming --> 1, city-out --> 2, city-in --> 3,
        if(ZVecterJudge.z == -6f){
            this.nowBranch = 1;
        }
        if(ZVecterJudge.z == 0f){
            this.nowBranch = 2;
        }
        if(ZVecterJudge.z == 1f){
            this.nowBranch = 3;
        }

    }

    public void aimBranch(){
        Transform PlayerTranse = this.transform;
        Vector3 VecterJudge = PlayerTranse.position;

        PlayerTranse.position = aimV[0];
    }

    public void InBranch(){
        
        Transform PlayerTranse = this.transform;
        Vector3 VecterJudge = PlayerTranse.position;
        if( nowBranch == 1|nowBranch == 2|nowBranch == 3){
            GameObject InAstart = GameObject.Find("Button_Astart");
            GameObject InBstart = GameObject.Find("Button_Bstart");
            GameObject InCstart = GameObject.Find("Button_Cstart");
            GameObject InDstart = GameObject.Find("Button_Dstart");
            InDstart.GetComponent<Button>().interactable = true;
            InCstart.GetComponent<Button>().interactable = true;
            InBstart.GetComponent<Button>().interactable = true;
            InAstart.GetComponent<Button>().interactable = true;
        }/*else
        if(nowBranch == 2){
            GameObject InAstart = GameObject.Find("Button_Astart");
            GameObject InBstart = GameObject.Find("Button_Bstart");
            GameObject InCstart = GameObject.Find("Button_Cstart");
            GameObject InDstart = GameObject.Find("Button_Dstart");
            InDstart.GetComponent<Button>().interactable = true;
            InCstart.GetComponent<Button>().interactable = true;
            InBstart.GetComponent<Button>().interactable = true;
            InAstart.GetComponent<Button>().interactable = true;
           
           for (int i = 0; i < 48; i++){ // 自分の座標がどの配列番号か判定(外側)
                if(vout[i] == PlayerTranse.position)
                {
                    nowPos_num = i;
                    break;
                }
            }
            if(nowPos_num == 0 ){
                PlayerTranse.position = vin[nowPos_num]; //A
            }else if(nowPos_num == 12 ){
                PlayerTranse.position = vin[24]; //B
            }else if(nowPos_num == 24){
                PlayerTranse.position = vin[16]; //D
            }else if(nowPos_num == 36){
                PlayerTranse.position = vin[8]; //C
            }
            
        }
        if(nowBranch == 3){
            GameObject InAstart = GameObject.Find("Button_Astart");
            GameObject InBstart = GameObject.Find("Button_Bstart");
            GameObject InCstart = GameObject.Find("Button_Cstart");
            GameObject InDstart = GameObject.Find("Button_Dstart");
            InDstart.GetComponent<Button>().interactable = true;
            InCstart.GetComponent<Button>().interactable = true;
            InBstart.GetComponent<Button>().interactable = true;
            InAstart.GetComponent<Button>().interactable = true;
           for (int i = 0; i < 48; i++){ // 自分の座標がどの配列番号か判定(外側)
                if(vout[i] == PlayerTranse.position)
                {
                    nowPos_num = i;
                    break;
                }
            }
            if(nowPos_num == 0 ){
                PlayerTranse.position = vin[nowPos_num]; //A
            }else if(nowPos_num == 12 ){
                PlayerTranse.position = vin[24]; //B
            }else if(nowPos_num == 24){
                PlayerTranse.position = vin[16]; //D
            }else if(nowPos_num == 36){
                PlayerTranse.position = vin[8]; //C
            }
        }
        */
    }
    public void InApoint(){
        Transform PlayerTranse = this.transform;
        PlayerTranse.position = vin[0];
            GameObject InAstart = GameObject.Find("Button_Astart");
            GameObject InBstart = GameObject.Find("Button_Bstart");
            GameObject InCstart = GameObject.Find("Button_Cstart");
            GameObject InDstart = GameObject.Find("Button_Dstart");
            InDstart.GetComponent<Button>().interactable = false;
            InCstart.GetComponent<Button>().interactable = false;
            InBstart.GetComponent<Button>().interactable = false;
            InAstart.GetComponent<Button>().interactable = false;
    }
    public void InBpoint(){
        Transform PlayerTranse = this.transform;
        PlayerTranse.position = vin[24];
            GameObject InAstart = GameObject.Find("Button_Astart");
            GameObject InBstart = GameObject.Find("Button_Bstart");
            GameObject InCstart = GameObject.Find("Button_Cstart");
            GameObject InDstart = GameObject.Find("Button_Dstart");
            InDstart.GetComponent<Button>().interactable = false;
            InCstart.GetComponent<Button>().interactable = false;
            InBstart.GetComponent<Button>().interactable = false;
            InAstart.GetComponent<Button>().interactable = false;
    }
    public void InCpoint(){
        Transform PlayerTranse = this.transform;
        PlayerTranse.position = vin[8];
            GameObject InAstart = GameObject.Find("Button_Astart");
            GameObject InBstart = GameObject.Find("Button_Bstart");
            GameObject InCstart = GameObject.Find("Button_Cstart");
            GameObject InDstart = GameObject.Find("Button_Dstart");
            InDstart.GetComponent<Button>().interactable = false;
            InCstart.GetComponent<Button>().interactable = false;
            InBstart.GetComponent<Button>().interactable = false;
            InAstart.GetComponent<Button>().interactable = false;
    }
    public void InDpoint(){
        Transform PlayerTranse = this.transform;
        PlayerTranse.position = vin[16];
            GameObject InAstart = GameObject.Find("Button_Astart");
            GameObject InBstart = GameObject.Find("Button_Bstart");
            GameObject InCstart = GameObject.Find("Button_Cstart");
            GameObject InDstart = GameObject.Find("Button_Dstart");
            InDstart.GetComponent<Button>().interactable = false;
            InCstart.GetComponent<Button>().interactable = false;
            InBstart.GetComponent<Button>().interactable = false;
            InAstart.GetComponent<Button>().interactable = false;
    }
    public void OutApoint(){
        Transform PlayerTranse = this.transform;
        PlayerTranse.position = vout[0];
            GameObject OutAstart = GameObject.Find("Button_OAstart");
            GameObject OutBstart = GameObject.Find("Button_OBstart");
            GameObject OutCstart = GameObject.Find("Button_OCstart");
            GameObject OutDstart = GameObject.Find("Button_ODstart");
            OutDstart.GetComponent<Button>().interactable = false;
            OutCstart.GetComponent<Button>().interactable = false;
            OutBstart.GetComponent<Button>().interactable = false;
            OutAstart.GetComponent<Button>().interactable = false;
    }
    public void OutBpoint(){
        Transform PlayerTranse = this.transform;
        PlayerTranse.position = vout[12];
            GameObject OutAstart = GameObject.Find("Button_OAstart");
            GameObject OutBstart = GameObject.Find("Button_OBstart");
            GameObject OutCstart = GameObject.Find("Button_OCstart");
            GameObject OutDstart = GameObject.Find("Button_ODstart");
            OutDstart.GetComponent<Button>().interactable = false;
            OutCstart.GetComponent<Button>().interactable = false;
            OutBstart.GetComponent<Button>().interactable = false;
            OutAstart.GetComponent<Button>().interactable = false;
    }
    public void OutCpoint(){
        Transform PlayerTranse = this.transform;
        PlayerTranse.position = vout[36];
            GameObject OutAstart = GameObject.Find("Button_OAstart");
            GameObject OutBstart = GameObject.Find("Button_OBstart");
            GameObject OutCstart = GameObject.Find("Button_OCstart");
            GameObject OutDstart = GameObject.Find("Button_ODstart");
            OutDstart.GetComponent<Button>().interactable = false;
            OutCstart.GetComponent<Button>().interactable = false;
            OutBstart.GetComponent<Button>().interactable = false;
            OutAstart.GetComponent<Button>().interactable = false;
    }
    public void OutDpoint(){
        Transform PlayerTranse = this.transform;
        PlayerTranse.position = vout[24];
            GameObject OutAstart = GameObject.Find("Button_OAstart");
            GameObject OutBstart = GameObject.Find("Button_OBstart");
            GameObject OutCstart = GameObject.Find("Button_OCstart");
            GameObject OutDstart = GameObject.Find("Button_ODstart");
            OutDstart.GetComponent<Button>().interactable = false;
            OutCstart.GetComponent<Button>().interactable = false;
            OutBstart.GetComponent<Button>().interactable = false;
            OutAstart.GetComponent<Button>().interactable = false;
    }
    public void OutBranch(){
        Transform PlayerTranse = this.transform;
        Vector3 VecterJudge = PlayerTranse.position;

        if( nowBranch == 1 | nowBranch == 2 |nowBranch == 3){
            GameObject OutAstart = GameObject.Find("Button_OAstart");
            GameObject OutBstart = GameObject.Find("Button_OBstart");
            GameObject OutCstart = GameObject.Find("Button_OCstart");
            GameObject OutDstart = GameObject.Find("Button_ODstart");
            OutDstart.GetComponent<Button>().interactable = true;
            OutCstart.GetComponent<Button>().interactable = true;
            OutBstart.GetComponent<Button>().interactable = true;
            OutAstart.GetComponent<Button>().interactable = true;
        }/*else if(nowBranch == 3){
           for (int i = 0; i < 32; i++){ // 自分の座標がどの配列番号か判定(外側)
                if(vin[i] == PlayerTranse.position)
                {
                    nowPos_num = i;
                    break;
                }
            }
            if(nowPos_num == 0 ){
                PlayerTranse.position = vout[nowPos_num]; //A
            }else if(nowPos_num == 24 ){
                PlayerTranse.position = vout[12]; //B
            }else if(nowPos_num == 16){
                PlayerTranse.position = vout[24]; //D
            }else if(nowPos_num == 8){
                PlayerTranse.position = vout[36]; //C
            }
        } */
    }



    public void rollOfDice()
    {
            Transform myPosition = this.transform;
            roll_of_Dice = UnityEngine.Random.Range(1, 6);
            moveTime = roll_of_Dice;     //サイコロの目が動く数とする

            //どのキャラクターを動かすのか判定する。
            //変数の中身が1の時Image.niaを呼び出しポインタに代入
            //このスクリプトのthisをそれぞれのImageオブジェクトを指すポインタに置き換える。


            if(this.nowBranch == 1) //Aiming
            {
                for (int i = 0; i < 30; i++) // 自分の座標がどの配列番号か判定
                {        
                    if(aimV[i] == myPosition.position)
                    {
                        nowPos_num = i;
                        break;
                    }
                }
                terget_num = nowPos_num + moveTime;//配列番号にサイコロの目を足す
                
                if (terget_num > 29){
                    terget_num = terget_num - 29;
                } 
    　　　　　　　
                Vector3 pos = myPosition.position;
                pos.x = aimV[terget_num].x;    // x座標
                pos.y = aimV[terget_num].y;    // y座標
                pos.z += 0.0f;    // z座標は移動しない

                myPosition.position = pos;  // 座標を設定
                MovedPos = pos;
                

                Debug.Log($"今{nowPos_num}");
                Debug.Log($"サイコロ {moveTime}");
                Debug.Log($"位置{myPosition.position}"); 
                
                //---移動後の自分の座標を判定 ---> 駒に応じたダイアログを発生
                if(MovedPos == Apoint|MovedPos == Bpoint|MovedPos == Cpoint|MovedPos == Dpoint)
                {   
                    //ここに分岐用のダイアログを生成するプログラムを書く 
                    ShowDialog();               
                }
            }  //if(this.nowBranch == 1)  Aimingの移動

            if(this.nowBranch == 2) //Voutの移動
            {
                
                for (int i = 0; i < 48; i++) // 自分の座標がどの配列番号か判定(外側)
                {        
                    if(vout[i] == myPosition.position)
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
                pos.x = vout[terget_num].x;    // x座標
                pos.y = vout[terget_num].y;    // y座標
                pos.z += 0.0f;    // z座標は移動しない

                myPosition.position = pos;  // 座標を設定
                MovedPos = pos;
                

                Debug.Log($"今{nowPos_num}");
                Debug.Log($"サイコロ {moveTime}");
                Debug.Log($"位置{myPosition.position}"); 
                
                //---移動後の自分の座標を判定 ---> 駒に応じたダイアログを発生
                if(MovedPos == AOUT|MovedPos == BOUT|MovedPos == COUT|MovedPos == DOUT)
                {   
                    //ここに分岐用のダイアログを生成するプログラムを書く 
                    ShowDialog();               
                }
            }  //if(this.nowBranch == 2)  Voutの移動

            if(this.nowBranch == 3)  //vinの移動
            {
                Debug.Log($"今buranch3動いたよ");
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
                MovedPos = pos;
                

                Debug.Log($"今{nowPos_num}");
                Debug.Log($"サイコロ {moveTime}");
                Debug.Log($"位置{myPosition.position}"); 
                
                //---移動後の自分の座標を判定 ---> 駒に応じたダイアログを発生
                if(MovedPos == Apoint|MovedPos == Bpoint|MovedPos == Cpoint|MovedPos == Dpoint)
                {   
                    //ここに分岐用のダイアログを生成するプログラムを書く 
                    ShowOnly();               
                }
            }  //if(this.nowBranch == 3)  vinの移動

    }

    // mypositionに設定したstart positionを入れる
    void Start()
    {
        moveTime = 0;
        Transform myPosition = this.transform;
        myPosition.position = startPos;

        //AimingBoard ----
        aimV[0] = new Vector3( -600f, 245f,-6f);
        aimV[1] = new Vector3( -500f, 245f,-6f);
        aimV[2] = new Vector3( -413f, 245f,-6f);
        aimV[3] = new Vector3( -330f, 245f,-6f);   
        aimV[4] = new Vector3( -250f, 245f,-6f);
        aimV[5] = new Vector3( -165f, 245f,-6f);
        aimV[6] = new Vector3(  -80f, 245f,-6f);
        aimV[7] = new Vector3(   -1f, 245f,-6f);
        aimV[8] = new Vector3(   85f, 245f,-6f);
        aimV[9] = new Vector3(  210f, 245f,-6f);
        aimV[9] = new Vector3(  210f, 245f,-6f);
        aimV[10] = new Vector3( 210f, 125f,-6f);
        aimV[11] = new Vector3( 210f,  40f,-6f);
        aimV[12] = new Vector3( 210f, -42f,-6f);
        aimV[13] = new Vector3( 210f,-125f,-6f);
        aimV[14] = new Vector3( 210f,-210f,-6f);
        aimV[15] = new Vector3( 210f,-325f,-6f);
        aimV[16] = new Vector3(  84f,-325f,-6f);
        aimV[17] = new Vector3(   1f,-325f,-6f);
        aimV[18] = new Vector3( -80f,-325f,-6f);
        aimV[19] = new Vector3(-161f,-325f,-6f);
        aimV[20] = new Vector3(-248f,-325f,-6f);
        aimV[21] = new Vector3(-333f,-325f,-6f);
        aimV[22] = new Vector3(-414f,-325f,-6f);
        aimV[23] = new Vector3(-500f,-325f,-6f);
        aimV[24] = new Vector3(-615f,-325f,-6f);
        aimV[25] = new Vector3(-615f,-205f,-6f);
        aimV[26] = new Vector3(-615f,-120f,-6f);
        aimV[27] = new Vector3(-615f, -43f,-6f);
        aimV[28] = new Vector3(-615f,  45f,-6f);
        aimV[29] = new Vector3(-615f, 125f,-6f);


        //CityBoardvin 内側のひし形升 ----
        vin[0] = new Vector3(-600f, -35f, 1f); // Aスタート
        vin[31] = new Vector3(-548f ,  5f,1f); 
        vin[30] = new Vector3(-500f , 34f,1f);
        vin[29] = new Vector3(-454f , 63f,1f);
        vin[28] = new Vector3(-405f ,100f,1f);
        vin[27] = new Vector3(-357f ,130f,1f);
        vin[26] = new Vector3(-307f ,163f,1f);
        vin[25] = new Vector3(-262f ,195f,1f);
        vin[24] = new Vector3(-205f ,241f,1f); // Bスタート
        vin[23] = new Vector3(-148f ,194f,1f); 
        vin[22] = new Vector3(-100f,158f, 1f);
        vin[21] = new Vector3(-53f, 126f, 1f);
        vin[20] = new Vector3(-5f,   88f, 1f);
        vin[19] = new Vector3(43f,   54f, 1f);
        vin[18] = new Vector3(86f,   23f, 1f);
        vin[17] = new Vector3(138f, -13f, 1f);
        vin[16] = new Vector3(197f, -46f, 1f); // Dスタート
        vin[15] = new Vector3(143f, -90f, 1f);
        vin[14] = new Vector3(91f , -124f,1f);
        vin[13] = new Vector3(45f,  -155f,1f);
        vin[12] = new Vector3(-4f,  -187f,1f);
        vin[11] = new Vector3(-55f, -223f,1f);
        vin[10] = new Vector3(-102f,-253f,1f);
        vin[9] = new Vector3(-148f,-283f ,1f);
        vin[8] = new Vector3(-203f, -320f,1f); // Cスタート
        vin[7] = new Vector3(-264f, -280f,1f);
        vin[6] = new Vector3(-304f, -248f,1f);
        vin[5] = new Vector3(-356f, -215f,1f);
        vin[4] = new Vector3(-405f, -178f,1f);
        vin[3] = new Vector3(-454f, -145f,1f);
        vin[2] = new Vector3(-503f, -110f,1f);
        vin[1] = new Vector3(-545f, -77f ,1f);

        //---外側  Vout-----
        vout[0] = new Vector3(-635f,-45f); //Apoint
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
        vout[12] = new Vector3(-206f,275f);//Bpoint
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
        vout[24] = new Vector3(226f, -40f);//Dpoint
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
        vout[35] = new Vector3(-142f,-345f);
        vout[36] = new Vector3(-205f,-345f);//Cpoint
        vout[37] = new Vector3(-268f, -345f);
        vout[38] = new Vector3(-323f, -345f);
        vout[39] = new Vector3(-382f, -345f);
        vout[40] = new Vector3(-440f, -345f);
        vout[41] = new Vector3(-499f, -345f);
        vout[42] = new Vector3(-557f, -345f);
        vout[43] = new Vector3(-635f, -345f); //左下角
        vout[44] = new Vector3(-635f, -270f);
        vout[45] = new Vector3(-635f, -212f);
        vout[46] = new Vector3(-635f, -154f);
        vout[47] = new Vector3(-635f, -96f);
    }

    // Update is called once per frame
    void Update()
    {     
        Transform PlayerTranse = this.transform;
        Vector3 ZVecterJudge = PlayerTranse.position;
        //z座標を基準にどのコースにいるのか把握
        //nowBranch aiming --> 1, city-out --> 2, city-in --> 3,

        if(ZVecterJudge.z == -6f){
            this.nowBranch = 1;
            //Debug.Log($"今nowBranch1");
        }
        if(ZVecterJudge.z == 0f){
            this.nowBranch = 2;
            //Debug.Log($"今nowBranch2");
        }
        if(ZVecterJudge.z == 1f){
            this.nowBranch = 3;
            //Debug.Log($"今nowBranch3");
        }
    }
    
}
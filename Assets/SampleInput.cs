using System.Collections;
using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//namespace Com.SUP.SUPGame
//{


    public class SampleInput : Photon.PunBehaviour {



    #region Public Variables

		[Tooltip("The Ui Panel to let the user enter name, connect and play")]
		public GameObject controlPanel;

		[Tooltip("The Ui Text to inform the user about the connection progress")]
		public Text feedbackText;

		[Tooltip("The maximum number of players per room")]
		public byte maxPlayersPerRoom = 5;

		//[Tooltip("The UI Loader Anime")]
		//public LoaderAnime loaderAnime;

		#endregion

		#region Private Variables
		/// <summary>
		/// Keep track of the current process. Since connection is asynchronous and is based on several callbacks from Photon, 
		/// we need to keep track of this to properly adjust the behavior when we receive call back by Photon.
		/// Typically this is used for the OnConnectedToMaster() callback.
		/// </summary>
		bool isConnecting;

		/// <summary>
		/// This client's version number. Users are separated from each other by gameversion (which allows you to make breaking changes).
		/// </summary>
		string _gameVersion = "1";

	#endregion









	#region MonoBehaviour CallBacks

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during early initialization phase.
		/// </summary>
		void Awake()
		{
			//if (loaderAnime==null)
			//{
			//	Debug.LogError("<Color=Red><b>Missing</b></Color> loaderAnime Reference.",this);
			//}

			// #Critical
			// we don't join the lobby. There is no need to join a lobby to get the list of rooms.
			PhotonNetwork.autoJoinLobby = false;

			// #Critical
			// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
			PhotonNetwork.automaticallySyncScene = true;


		}

	#endregion







	#region Public Methods

		/// <summary>
		/// Start the connection process. 
		/// - If already connected, we attempt joining a random room
		/// - if not yet connected, Connect this application instance to Photon Cloud Network
		/// </summary>
		public void onConnect()
		{
			// we want to make sure the log is clear everytime we connect, we might have several failed attempted if connection failed.
			feedbackText.text = "";

			// keep track of the will to join a room, because when we come back from the game we will get a callback that we are connected, so we need to know what to do then
			isConnecting = true;

			// hide the Play button for visual consistency
			controlPanel.SetActive(false);

			// start the loader animation for visual effect.
			//if (loaderAnime!=null)
			//{
			//	loaderAnime.StartLoaderAnimation();
			//}

			// we check if we are connected or not, we join if we are , else we initiate the connection to the server.
			if (PhotonNetwork.connected)
			{
				LogFeedback("Joining Room...");
				// #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnPhotonRandomJoinFailed() and we'll create one.
				PhotonNetwork.JoinRandomRoom();
			}else{

				LogFeedback("Connecting...");
				
				// #Critical, we must first and foremost connect to Photon Online Server.
				PhotonNetwork.ConnectUsingSettings(_gameVersion);
			}
		}

		/// <summary>
		/// Logs the feedback in the UI view for the player, as opposed to inside the Unity Editor for the developer.
		/// </summary>
		/// <param name="message">Message.</param>
		void LogFeedback(string message)
		{
			// we do not assume there is a feedbackText defined.
			if (feedbackText == null) {
				return;
			}

			// add new messages as a new line and at the bottom of the log.
			feedbackText.text += System.Environment.NewLine+message;
		}

	#endregion







	#region Photon.PunBehaviour CallBacks

		/// <summary>
		/// Called after the connection to the master is established and authenticated but only when PhotonNetwork.autoJoinLobby is false.
		/// </summary>
		public override void OnConnectedToMaster()
		{

			Debug.Log("Region:"+PhotonNetwork.networkingPeer.CloudRegion);

			// we don't want to do anything if we are not attempting to join a room. 
			// this case where isConnecting is false is typically when you lost or quit the game, when this level is loaded, OnConnectedToMaster will be called, in that case
			// we don't want to do anything.
			if (isConnecting)
			{
				LogFeedback("OnConnectedToMaster: Next -> try to Join Random Room");
				Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room.\n Calling: PhotonNetwork.JoinRandomRoom(); Operation will fail if no room found");
		
				// #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnPhotonRandomJoinFailed()
				PhotonNetwork.JoinRandomRoom();
			}
		}

		/// <summary>
		/// Called when a JoinRandom() call failed. The parameter provides ErrorCode and message.
		/// </summary>
		public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
		{
			LogFeedback("<Color=Red>OnPhotonRandomJoinFailed</Color>: Next -> Create a new Room");
			Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");

			// #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
			PhotonNetwork.CreateRoom("RoomName", new RoomOptions() { isVisible = true, MaxPlayers = this.maxPlayersPerRoom}, null);
		}


		/// <summary>
		/// Called after disconnecting from the Photon server.
		/// </summary>
		public override void OnDisconnectedFromPhoton()
		{
			LogFeedback("<Color=Red>OnDisconnectedFromPhoton</Color>");
			Debug.LogError("DemoAnimator/Launcher:Disconnected");

			// #Critical: we failed to connect or got disconnected. There is not much we can do. Typically, a UI system should be in place to let the user attemp to connect again.
			//loaderAnime.StopLoaderAnimation();

			isConnecting = false;
			controlPanel.SetActive(true);

		}

		/// <summary>
		/// Called when entering a room (by creating or joining it). Called on all clients (including the Master Client).
		/// </summary>
		public override void OnJoinedRoom()
		{
			LogFeedback("<Color=Green>OnJoinedRoom</Color> with "+PhotonNetwork.room.PlayerCount+" Player(s)");
			Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.\nFrom here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
		
			// #Critical: We only load if we are the first player, else we rely on  PhotonNetwork.automaticallySyncScene to sync our instance scene.
			if (PhotonNetwork.room.PlayerCount <= 5)
			{
				Debug.Log("We load the 'Room for 1' ");

				// #Critical
				// Load the Room Level. 
				//PhotonNetwork.LoadLevel("PunBasics-Room for 1");
                //SceneManager.LoadScene ("Lobby");
                PhotonNetwork.LoadLevel("CityBoard");

			}
		}

	#endregion    

    /// 下は元のコード
    /*    
    //オブジェクトと結びつける
    public InputField inputField;
    public Text text;

        void Start () {
                //Componentを扱えるようにする
                PhotonNetwork.ConnectUsingSettings("v1.0");
                inputField = inputField.GetComponent<InputField>();
                text = text.GetComponent<Text> ();
        }

        // ボタンが押された場合、今回呼び出される関数
        public void OnClick(){
            Debug.Log("押された!");  // ログを出力
            text.text = inputField.text;
            GameObject target_button = GameObject.Find ("ButtonStart");
            //Debug.Log ("target_button = " + target_button);
            //Button btn = GetComponent<target_button>(target_button);
            //btn.interactable = true;
            GameObject.Find("ButtonStart").GetComponent<Button>().interactable = true;
        }

        public void OnClickStartButton () {
            //PhotonNetwork.CreateRoom("Room1", new RoomOptions() { MaxPlayers = 5 }, TypedLobby.Default);
            //Debug.Log("Room1作成");
            //PhotonNetwork.CreateRoom("Room2", new RoomOptions() { MaxPlayers = 5 }, TypedLobby.Default);
            //Debug.Log("Room2作成");
            //PhotonNetwork.CreateRoom("Room3", new RoomOptions() { MaxPlayers = 5 }, TypedLobby.Default);
            //Debug.Log("Room3作成");
            //PhotonNetwork.CreateRoom("Room4", new RoomOptions() { MaxPlayers = 5 }, TypedLobby.Default);
            //Debug.Log("Room4作成");
            SceneManager.LoadScene ("Lobby");

        }
        */


    }
//}    
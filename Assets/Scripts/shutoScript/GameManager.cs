using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

using ExitGames.Client.Photon;

public class GameManager : Photon.PunBehaviour
{
    #region Public Variables

		static public GameManager Instance;

		[Tooltip("The prefab to use for representing the player")]
		public GameObject playerPrefab;
		public GameObject playerPrefabsim;
		public GameObject playerPrefabmugi;
		public GameObject playerPrefabwhitemugi;


	#endregion

	#region Private Variables

		private GameObject instance;

	#endregion

    #region MonoBehaviour CallBacks
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

			// in case we started this demo with the wrong scene being active, simply load the menu scene
			if (!PhotonNetwork.connected)
			{
				SceneManager.LoadScene("SUPLaunch");

				return;
			}

			if (playerPrefab == null && playerPrefabsim == null && playerPrefabmugi == null && playerPrefabwhitemugi == null) { // #Tip Never assume public properties of Components are filled up properly, always check and inform the developer of it.
				
				Debug.LogError("<Color=Red><b>Missing</b></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",this);
			} else {
				
                
				if (CharacterMove.LocalPlayerInstance==null)
				{
					Debug.Log("We are Instantiating LocalPlayer from "+SceneManagerHelper.ActiveSceneName);

					// we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
					PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(-600f, 245f,-6f), Quaternion.identity, 0);
					PhotonNetwork.Instantiate(this.playerPrefabsim.name, new Vector3(-600f, 245f,-6f), Quaternion.identity, 0);
					PhotonNetwork.Instantiate(this.playerPrefabmugi.name, new Vector3(-600f, 245f,-6f), Quaternion.identity, 0);
					PhotonNetwork.Instantiate(this.playerPrefabwhitemugi.name, new Vector3(-600f, 245f,-6f), Quaternion.identity, 0);
				}else{

					Debug.Log("Ignoring scene load for "+ SceneManagerHelper.ActiveSceneName);
				}
                

				
			}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			QuitApplication();
		}
    }

    #endregion


    #region Photon Messages

		
		public override void OnPhotonPlayerConnected( PhotonPlayer other  )
		{
			Debug.Log( "OnPhotonPlayerConnected() " + other.NickName); // not seen if you're the player connecting

			if ( PhotonNetwork.isMasterClient ) 
			{
				Debug.Log( "OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient ); // called before OnPhotonPlayerDisconnected

				LoadArena();
			}
		}

		
		public override void OnPhotonPlayerDisconnected( PhotonPlayer other  )
		{
			Debug.Log( "OnPhotonPlayerDisconnected() " + other.NickName ); // seen when other disconnects

			if ( PhotonNetwork.isMasterClient ) 
			{
				Debug.Log( "OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient ); // called before OnPhotonPlayerDisconnected
				
				LoadArena();
			}
		}

		
		public override void OnLeftRoom()
		{
			SceneManager.LoadScene("SUPLaunch");
		}

		#endregion

		#region Public Methods

		public void LeaveRoom()
		{
			PhotonNetwork.LeaveRoom();
		}

		public void QuitApplication()
		{
			Application.Quit();
		}

		#endregion

		#region Private Methods

		void LoadArena()
		{
			if ( ! PhotonNetwork.isMasterClient ) 
			{
				Debug.LogError( "PhotonNetwork : Trying to Load a level but we are not the master Client" );
			}

			Debug.Log( "PhotonNetwork : Loading Level : " + PhotonNetwork.room.PlayerCount ); 

			PhotonNetwork.LoadLevel("CityBoard");
		}

		#endregion    
}

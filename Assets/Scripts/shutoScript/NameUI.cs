using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameUI : MonoBehaviour
{
    #region Public Properties

		[Tooltip("Pixel offset from the player target")]
		public Vector3 ScreenOffset = new Vector3(0f,30f,0f);

		[Tooltip("UI Text to display Player's Name")]
		public Text PlayerNameText;

	#endregion

    #region Private Properties

		SUPlayerManager _target;

		float _characterControllerHeight = 0f;

		Transform _targetTransform;

		Renderer _targetRenderer;

		Vector3 _targetPosition;

	#endregion

    void Awake()
    {

		this.GetComponent<Transform>().SetParent (GameObject.Find("Canvas").GetComponent<Transform>());
	}

    // Update is called once per frame
    void Update()
    {
        if (_target == null) {
				Destroy(this.gameObject);
				return;
			}
    }

    void LateUpdate () {

			// Do not show the UI if we are not visible to the camera, thus avoid potential bugs with seeing the UI, but not the player itself.
			if (_targetRenderer!=null) {
				this.gameObject.SetActive(_targetRenderer.isVisible);
			}
			
			// #Critical
			// Follow the Target GameObject on screen.
			if (_targetTransform!=null)
			{
				_targetPosition = _targetTransform.position;
				_targetPosition.y += _characterControllerHeight;
				Debug.Log(_targetPosition);
				
				this.transform.position = _targetPosition + ScreenOffset;
			}

		}

    public void SetTarget(SUPlayerManager target){

			if (target == null) {
				Debug.LogError("<Color=Red><b>Missing</b></Color> PlayMakerManager target for PlayerUI.SetTarget.",this);
				return;
			}

			// Cache references for efficiency because we are going to reuse them.
			_target = target;
			_targetTransform = _target.GetComponent<Transform>();
			_targetRenderer = _target.GetComponent<Renderer>();


			CharacterController _characterController = _target.GetComponent<CharacterController> ();

			// Get data from the Player that won't change during the lifetime of this Component
			if (_characterController != null){
				_characterControllerHeight = _characterController.height;
			}

			if (PlayerNameText != null) {
				PlayerNameText.text = _target.photonView.owner.NickName;
			}
		}    
}

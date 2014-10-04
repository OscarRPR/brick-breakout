using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FastBallsObj : MonoBehaviour {
	
	public float timeEffect = 3.0f;
	public float speedModifier = 0.3f;
	public float scoreModifier = 1.5f;

	public GameObject particleFire;

	private bool paddleDidntCapture = false;
	private string modifierStr = ScoreUtils.FAST_BALLS_MODIFIER;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = (GameManager)FindObjectOfType (typeof(GameManager));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)  {
		if (other.gameObject.CompareTag ("Paddle")) {
			Debug.Log ("CollisionFastBalls-----");
			GetComponent<AudioSource>().Play();
			StartCoroutine ("startObjectEffect");	
		}
	}
	
	private IEnumerator startObjectEffect()
	{
		List<GameObject> balls = gameManager.getBalls ();
		
		foreach(GameObject ball in balls) {
			BallController ballController =  (BallController)ball.GetComponent (typeof(BallController));
			ballController.setSpeedModifier(modifierStr, /*ballController.getModifiedSpeed()**/speedModifier);
			ballController.setPowerUp(modifierStr, gameObject);
			Vector3 p = ball.transform.position;
			p.z = -2;
			Quaternion rs = ball.transform.rotation;
			rs.x = 270;

			GameObject fire = Instantiate(particleFire, p, Quaternion.Euler (rs.x, rs.y, rs.z)) as GameObject;
			fire.transform.parent = ball.transform;
		}

		gameManager.setScoreModifier (modifierStr, scoreModifier);

		paddleDidntCapture = true;
		renderer.enabled = false;

		yield return StartCoroutine("waitSeconds");
	}
	
	private IEnumerator waitSeconds()
	{
		yield return new WaitForSeconds(timeEffect);
		List<GameObject> balls = gameManager.getBalls ();
		
		foreach(GameObject ball in balls) {
			BallController ballController =  (BallController)ball.GetComponent (typeof(BallController));
			ballController.removePowerUp(modifierStr);
		}

		gameManager.removeScoreModifier (modifierStr);

		Destroy (gameObject);
		Debug.Log ("Effect Fast Done");
	}

	void OnBecameInvisible() {
		if (!paddleDidntCapture) {
			Destroy (gameObject);
		}
	}
}


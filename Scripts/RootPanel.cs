using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class RootPanel : MonoBehaviour
{
	public GameObject Canvas;
	public MenuPanel menuPanel;
	public LevelPanel levelPanel;
	
	void Awake()
	{
		RedPointSystem.Instance.AddNode(RedPointKey.Play_LEVEL1_HOME);
		RedPointSystem.Instance.AddNode(RedPointKey.Play_LEVEL1_SHOP);
		RedPointSystem.Instance.AddNode(RedPointKey.Play_LEVEL2_HOME);
		RedPointSystem.Instance.AddNode(RedPointKey.Play_LEVEL2_SHOP);
	}
	
	void Start()
	{
		menuPanel.gameObject.SetActive(true);
		levelPanel.gameObject.SetActive(false);
	}
}

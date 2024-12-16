using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 主菜单面板
/// </summary>
public class MenuPanel : MonoBehaviour
{
	public GameObject playBtn;
	public GameObject continueBtn;
	public GameObject optionsBtn;
	public GameObject QuitBtn;
	public LevelPanel LevelPanel;

	void Start()
	{
		playBtn.GetComponent<Button>().onClick.AddListener(OnPlay);
		InitRedPointState();
	}

	void OnPlay()
	{
		this.gameObject.SetActive(false);
		LevelPanel.gameObject.SetActive(true);
	}

	// 设置红点的状态
	void InitRedPointState()
	{
		int redNum = RedPointSystem.Instance.GetRedPointNum(RedPointKey.Play);
		RefreshRedPointState(redNum);
		RedPointSystem.Instance.SetCallBack(RedPointKey.Play, RefreshRedPointState);
	}

	// 更新红点UI
	void RefreshRedPointState(int redNum)
	{
		Transform redPoint = playBtn.transform.Find("RedPoint");
		Transform redNumText = redPoint.transform.Find("Num");
		if (redNum <= 0)
		{
			redPoint.gameObject.SetActive(false);
		}
		else
		{
			redPoint.gameObject.SetActive(true);
			redNumText.GetComponent<Text>().text = redNum.ToString();
		}
	}
}

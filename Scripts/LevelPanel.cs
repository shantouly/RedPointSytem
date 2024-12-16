using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 等级面板
/// </summary>
public class LevelPanel : MonoBehaviour
{
	public GameObject Back1Btn;
	public MenuPanel menuPanel;
	public GameObject Level1Btn;
	public GameObject Level1Container;
	public GameObject Level1HomeBtn;
	public GameObject Level1ShopBtn;

	public GameObject Level2Btn;
	public GameObject Level2Container;
	public GameObject Level2HomeBtn;
	public GameObject Level2ShopBtn;

	void Start()
	{
		Level1Container.SetActive(false);
		Level2Container.SetActive(false);
		Back1Btn.GetComponent<Button>().onClick.AddListener(OnBackClick);
		Level1Btn.GetComponent<Button>().onClick.AddListener(OnLevel1Click);
		Level2Btn.GetComponent<Button>().onClick.AddListener(OnLevel2Click);
		Level1HomeBtn.GetComponent<Button>().onClick.AddListener(OnLevel1HomeBtn);
		Level1ShopBtn.GetComponent<Button>().onClick.AddListener(OnLevel1ShopBtn);
		Level2HomeBtn.GetComponent<Button>().onClick.AddListener(OnLevel2HomeBtn);
		Level2ShopBtn.GetComponent<Button>().onClick.AddListener(OnLevel2ShopBtn);
		InitRedPointState();
	}
	void OnBackClick()
	{
		this.gameObject.SetActive(false);
		menuPanel.gameObject.SetActive(true);
	}

	void OnLevel1Click()
	{
		Level1Container.gameObject.SetActive(!Level1Container.gameObject.activeSelf);
	}

	void OnLevel2Click()
	{
		Level2Container.gameObject.SetActive(!Level2Container.gameObject.activeSelf);
	}

	void OnLevel1HomeBtn()
	{
		RedPointSystem.Instance.DeleteNode(RedPointKey.Play_LEVEL1_HOME);
	}
	void OnLevel1ShopBtn()
	{
		RedPointSystem.Instance.DeleteNode(RedPointKey.Play_LEVEL1_SHOP);
	}
	void OnLevel2HomeBtn()
	{
		RedPointSystem.Instance.DeleteNode(RedPointKey.Play_LEVEL2_HOME);
	}
	void OnLevel2ShopBtn()
	{
		RedPointSystem.Instance.DeleteNode(RedPointKey.Play_LEVEL2_SHOP);
	}

	void InitRedPointState()
	{
		// Level1Btn
		RefreshRedPointState(
			RedPointSystem.Instance.GetRedPointNum(RedPointKey.Play_LEVEL1),
			Level1Btn.transform.Find("RedPoint")
		);
		RedPointSystem.Instance.SetCallBack(RedPointKey.Play_LEVEL1, (int redNum) =>
		{
			RefreshRedPointState(redNum, Level1Btn.transform.Find("RedPoint"));
		});

		// Level2Btn
		RefreshRedPointState(
			RedPointSystem.Instance.GetRedPointNum(RedPointKey.Play_LEVEL2),
			Level2Btn.transform.Find("RedPoint")
		);
		// 匿名函数 ---> 绑定回调函数
		RedPointSystem.Instance.SetCallBack(RedPointKey.Play_LEVEL2, (int redNum) =>
		{
			RefreshRedPointState(redNum, Level2Btn.transform.Find("RedPoint"));
		});

		// Level1HomeBtn
		RefreshRedPointState(
			RedPointSystem.Instance.GetRedPointNum(RedPointKey.Play_LEVEL1_HOME),
			Level1HomeBtn.transform.Find("RedPoint")
		);
		RedPointSystem.Instance.SetCallBack(RedPointKey.Play_LEVEL1_HOME, (int redNum) =>
		{
			RefreshRedPointState(redNum, Level1HomeBtn.transform.Find("RedPoint"));
		});

		// Level1ShopBtn
		RefreshRedPointState(
			RedPointSystem.Instance.GetRedPointNum(RedPointKey.Play_LEVEL1_SHOP),
			Level1ShopBtn.transform.Find("RedPoint")
		);
		RedPointSystem.Instance.SetCallBack(RedPointKey.Play_LEVEL1_SHOP, (int redNum) =>
		{
			RefreshRedPointState(redNum, Level1ShopBtn.transform.Find("RedPoint"));
		});

		// Level2HomeBtn
		RefreshRedPointState(
			RedPointSystem.Instance.GetRedPointNum(RedPointKey.Play_LEVEL2_HOME),
			Level2HomeBtn.transform.Find("RedPoint")
		);
		RedPointSystem.Instance.SetCallBack(RedPointKey.Play_LEVEL2_HOME, (int redNum) =>
		{
			RefreshRedPointState(redNum, Level2HomeBtn.transform.Find("RedPoint"));
		});
		// Level1ShopBtn
		RefreshRedPointState(
			RedPointSystem.Instance.GetRedPointNum(RedPointKey.Play_LEVEL2_SHOP),
			Level2ShopBtn.transform.Find("RedPoint")
		);
		RedPointSystem.Instance.SetCallBack(RedPointKey.Play_LEVEL2_SHOP, (int redNum) =>
		{
			RefreshRedPointState(redNum, Level2ShopBtn.transform.Find("RedPoint"));
		});
	}

	/// <summary>
	/// 更新红点状态，更新UI
	/// </summary>
	/// <param name="redNum"></param>
	/// <param name="redPoint"></param>
	void RefreshRedPointState(int redNum, Transform redPoint)
	{
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

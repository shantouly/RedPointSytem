using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 红点系统节点类
/// </summary>
public class RedPointNode
{
	public int redNum;
	public string strKey;
	public Dictionary<string,RedPointNode> children;
	// 委托
	public delegate void RedPointChangeDelegate(int redNum);
	public RedPointChangeDelegate OnRedPointChange;
	// 构造
	public RedPointNode(string key)
	{
		strKey = key;
		children = new Dictionary<string, RedPointNode>();
	}
}

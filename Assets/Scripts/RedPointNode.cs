using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ϵͳ�ڵ���
/// </summary>
public class RedPointNode
{
	public int redNum;
	public string strKey;
	public Dictionary<string,RedPointNode> children;
	// ί��
	public delegate void RedPointChangeDelegate(int redNum);
	public RedPointChangeDelegate OnRedPointChange;
	// ����
	public RedPointNode(string key)
	{
		strKey = key;
		children = new Dictionary<string, RedPointNode>();
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 红点系统主要类
/// </summary>
public class RedPointSystem : MonoBehaviour
{	
	private static RedPointSystem instance = new RedPointSystem();
	public static RedPointSystem Instance
	{
		get
		{
			return instance;
		}
	}
	public RedPointNode root;
	private RedPointSystem()
	{
		this.root = new RedPointNode(RedPointKey.Root);
	}
	
	/// <summary>
	/// 添加节点
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public RedPointNode AddNode(string key)
	{
		if(FindNode(key) != null)
		{
			return null;
		}
		string[] keys = key.Split("|");
		RedPointNode curNode = root;
		curNode.redNum += 1;
		curNode.OnRedPointChange?.Invoke(curNode.redNum);
		foreach(var k in keys)
		{
			if(!curNode.children.ContainsKey(k))
			{
				curNode.children.Add(k,new RedPointNode(k));
			}
			curNode = curNode.children[k];
			curNode.redNum += 1;
			curNode.OnRedPointChange?.Invoke(curNode.redNum);
		}
		return curNode;
	}
	
	/// <summary>
	/// 寻找节点
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public RedPointNode FindNode(string key)
	{
		string[] keys = key.Split("|");
		RedPointNode curNode = root;
		foreach(var k in keys)
		{
			if(!curNode.children.ContainsKey(k))
			{
				return null;
			}
			curNode = curNode.children[k];
		}
		return curNode;
	}
	
	public void DeleteNode(string key)
	{
		if(FindNode(key) == null)
		{
			return;
		}
		DeleteNode(key,root);
	}
	
	/// <summary>
	/// 删除节点，使用递归
	/// </summary>
	/// <param name="key"></param>
	/// <param name="node"></param>
	/// <returns></returns>
	public RedPointNode DeleteNode(string key,RedPointNode node)
	{
		string[] keys = key.Split("|");
		if(key==""||keys.Length == 0)
		{
			node.redNum = Mathf.Clamp(node.redNum - 1,0,node.redNum);
			node.OnRedPointChange?.Invoke(node.redNum);
			return node;
		}
		string newKeys = string.Join("|",keys,1,keys.Length - 1);
		RedPointNode curNode = DeleteNode(newKeys,node.children[keys[0]]);
		
		node.redNum = Mathf.Clamp(node.redNum - 1,0,node.redNum);
		node.OnRedPointChange?.Invoke(node.redNum);
		
		if(curNode.children.Count > 0)
		{
			foreach(RedPointNode child in curNode.children.Values)
			{
				// 如果该节点中的红点的数量为0，删除该节点
				if(child.redNum == 0)
				{
					child.children.Remove(child.strKey);
				}
			}
		}
		return node;
	}
	
	/// <summary>
	/// 设置回调
	/// </summary>
	/// <param name="key"></param>
	/// <param name="rcd">类型为红点节点类的委托类型的方法</param>
	public void SetCallBack(string key,RedPointNode.RedPointChangeDelegate rcd)
	{
		RedPointNode node = FindNode(key);
		if(node == null)
		{
			return;
		}
		node.OnRedPointChange += rcd;
	}
	
	public int GetRedPointNum(string key)
	{
		RedPointNode node = FindNode(key);
		if(node == null)
		{
			return 0;
		}
		return node.redNum;
	}
}

/// <summary>
/// 用于测试的，具体的可以进行更改
/// </summary>
public class RedPointKey
{
		public const string Root = "Root";

		public const string Play = "Play";
		public const string Play_LEVEL1 = "Play|Level1";
		public const string Play_LEVEL1_HOME = "Play|Level1|HOME";
		public const string Play_LEVEL1_SHOP = "Play|Level1|SHOP";
		public const string Play_LEVEL2 = "Play|Level2";
		public const string Play_LEVEL2_HOME = "Play|Level2|HOME";
		public const string Play_LEVEL2_SHOP = "Play|Level2|SHOP";
}

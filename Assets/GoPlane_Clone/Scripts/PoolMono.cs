using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolMono<T> where T: MonoBehaviour
{
	private T _prefab;
	private Transform _container;
	
	private bool _isAutoExpand = false;
	public void IsAutoExpand(bool value) => _isAutoExpand = value;

	private List<T> _pool;
	public List<T> Pool => _pool;

	public PoolMono(T prefab, int count, Transform container)
	{
		_prefab = prefab;
		_container = container;
		
		CreatePool(count);
	}

	private void CreatePool(int count)
	{
		_pool = new List<T>();

		for (int i = 0; i < count; i++)
		{
			CreateObject();
		}
	}

	private T CreateObject(bool isActiveByDefault = false)
	{
		var createdObject = Object.Instantiate(_prefab, _container);
		createdObject.gameObject.SetActive(isActiveByDefault);
		
		_pool.Add(createdObject);

		return createdObject;
	}

	public bool HasFreeElement(out T element)
	{
		foreach (var mono in _pool)
		{
			if (!mono.gameObject.activeInHierarchy)
			{
				element = mono;
				
				return true;
			} 
		}
		
		element = null;

		return false;
	}

	public T GetFreeElement()
	{
		if (HasFreeElement(out var element))
		{
			element.gameObject.SetActive(true);
			
			return element;
		}

		if (_isAutoExpand)
			return CreateObject(true);

		throw new Exception($"There is no free element in pool of type {typeof(T)}");
	}

	public List<T> GetActivatedElements()
	{
		List<T> activatedElements = new List<T>();
		
		foreach (var mono in _pool)
		{
			if (mono.gameObject.activeInHierarchy)
			{
				activatedElements.Add(mono);
			}
		}

		return activatedElements;
	}
}

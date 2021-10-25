
using System;
using System.Collections.Generic;
using UnityEngine;

namespace XHFrameWork
{
	public class UIManager : Singleton<UIManager>
	{
		class UIInfoData
		{
			public EnumUIType UIType { get; private set; }

			public Type ScriptType { get; private set; }

			public string Path { get; private set; }

			public object[] UIParams { get; private set; }
			public UIInfoData(EnumUIType _uiType, string _path, params object[] _uiParams)
			{
				this.UIType = _uiType;
				this.Path = _path;
				this.UIParams = _uiParams;
				this.ScriptType = UIPathDefines.GetUIScriptByType(this.UIType);
			}
		}

		private Dictionary<EnumUIType, GameObject> dicOpenUIs = null;
		private Stack<UIInfoData> stackOpenUIs = null;

		public override void Init()
		{
			dicOpenUIs = new Dictionary<EnumUIType, GameObject>();
			stackOpenUIs = new Stack<UIInfoData>();
        }

		public T GetUI<T>(EnumUIType _uiType) where T : BaseUI
		{
			GameObject _retObj = GetUIObject(_uiType);
			if (_retObj != null)
			{
				return _retObj.GetComponent<T>();
			}
			return null;
		}

		public GameObject GetUIObject(EnumUIType _uiType)
		{
			GameObject _retObj = null;
			if (!dicOpenUIs.TryGetValue(_uiType, out _retObj))
				throw new Exception("dicOpenUIs TryGetValue Failure! _uiType :" + _uiType.ToString());
			return _retObj;
		}

		public void PreloadUI(EnumUIType[] _uiTypes)
		{
			for (int i = 0; i < _uiTypes.Length; i++)
			{
				PreloadUI(_uiTypes[i]);
			}
		}

		public void PreloadUI(EnumUIType _uiType)
		{
			string path = UIPathDefines.GetPrefabPathByType(_uiType);
			Resources.Load(path);
			//ResManager.Instance.ResourcesLoad(path);
		}


		//打开UI
		public void OpenUI(EnumUIType[] uiTypes)
		{
			OpenUI(false, uiTypes, null);
		}

		public void OpenUI(EnumUIType uiType, params object[] uiObjParams)
		{
			EnumUIType[] uiTypes = new EnumUIType[1];
			uiTypes[0] = uiType;
			OpenUI(false, uiTypes, uiObjParams);
		}

		//打开UI的时候，关闭其他UI
		public void OpenUICloseOthers(EnumUIType[] uiTypes)
		{
			OpenUI(true, uiTypes, null);
		}

		public void OpenUICloseOthers(EnumUIType uiType, params object[] uiObjParams)
		{
			EnumUIType[] uiTypes = new EnumUIType[1];
			uiTypes[0] = uiType;
			OpenUI(true, uiTypes, uiObjParams);
		}

		//是否关闭其他UI，需要显示的多个UI，
		private void OpenUI(bool _isCloseOthers, EnumUIType[] _uiTypes, params object[] _uiParams)
		{
			if (_isCloseOthers)
			{
				CloseUIAll();
			}

			// push _uiTypes in Stack.
			for (int i = 0; i < _uiTypes.Length; i++)
			{
				EnumUIType _uiType = _uiTypes[i];
				if (!dicOpenUIs.ContainsKey(_uiType))
				{
					string _path = UIPathDefines.GetPrefabPathByType(_uiType);
					stackOpenUIs.Push(new UIInfoData(_uiType, _path, _uiParams));
				}
			}

			// Open UI.
			if (stackOpenUIs.Count > 0)
			{
				CoroutineController.Instance.StartCoroutine(AsyncLoadData());
			}
		}

		//异步加载预制件
		private IEnumerator<int> AsyncLoadData()
		{
			UIInfoData _uiInfoData = null;
			UnityEngine.Object _prefabObj = null;
			GameObject _uiObject = null;

			if (stackOpenUIs != null && stackOpenUIs.Count > 0)
			{
				do
				{
					_uiInfoData = stackOpenUIs.Pop();
					//加载预制UI
					_prefabObj = Resources.Load(_uiInfoData.Path);
					if (_prefabObj != null)
					{
						//_uiObject = NGUITools.AddChild(Game.Instance.mainUICamera.gameObject, _prefabObj as GameObject);
						_uiObject = MonoBehaviour.Instantiate(_prefabObj) as GameObject;
						BaseUI _baseUI = _uiObject.GetComponent<BaseUI>();
						if (null == _baseUI)
						{
							//添加对应的脚本
							_baseUI = _uiObject.AddComponent(_uiInfoData.ScriptType) as BaseUI;
						}
						if (null != _baseUI)
						{
							_baseUI.SetUIWhenOpening(_uiInfoData.UIParams);
						}
						//加载过的缓存起来
						dicOpenUIs.Add(_uiInfoData.UIType, _uiObject);
					}

				} while (stackOpenUIs.Count > 0);
			}
			yield return 0;
		}

		public void CloseUI(EnumUIType _uiType)
		{
			GameObject _uiObj = null;
			if (!dicOpenUIs.TryGetValue(_uiType, out _uiObj))
			{
				Debug.Log("dicOpenUIs TryGetValue Failure! _uiType :" + _uiType.ToString());
				return;
			}
			CloseUI(_uiType, _uiObj);
		}

		public void CloseUI(EnumUIType[] _uiTypes)
		{
			for (int i = 0; i < _uiTypes.Length; i++)
			{
				CloseUI(_uiTypes[i]);
			}
		}

		/// <summary>
		/// 关闭所有UI界面
		/// </summary>
		public void CloseUIAll()
		{
			List<EnumUIType> _keyList = new List<EnumUIType>(dicOpenUIs.Keys);
			foreach (EnumUIType _uiType in _keyList)
			{
				GameObject _uiObj = dicOpenUIs[_uiType];
				CloseUI(_uiType, _uiObj);
			}
			dicOpenUIs.Clear();
		}

		private void CloseUI(EnumUIType _uiType, GameObject _uiObj)
		{
			if (_uiObj == null)
			{
				dicOpenUIs.Remove(_uiType);
			}
			else
			{
				BaseUI _baseUI = _uiObj.GetComponent<BaseUI>();
				if (_baseUI != null)
				{
					_baseUI.StateChanged += CloseUIHandler;
					_baseUI.Release();
				}
				else
				{
					GameObject.Destroy(_uiObj);
					dicOpenUIs.Remove(_uiType);
				}
			}
		}

		private void CloseUIHandler(object _sender, EnumObjectState _newState, EnumObjectState _oldState)
		{
			if (_newState == EnumObjectState.Closing)
			{
				BaseUI _baseUI = _sender as BaseUI;
				dicOpenUIs.Remove(_baseUI.GetUIType());
				_baseUI.StateChanged -= CloseUIHandler;
			}
		}
	}
}


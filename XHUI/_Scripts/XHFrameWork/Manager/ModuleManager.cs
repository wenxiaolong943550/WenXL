

using System;
using System.Collections.Generic;


namespace XHFrameWork
{
	public class ModuleManager : Singleton<ModuleManager>
	{
		private Dictionary<string, BaseModule> dicModules = null;

		public override void Init ()
		{
			dicModules = new Dictionary<string, BaseModule> ();
		}

		public BaseModule Get(string key)
		{
			if (dicModules.ContainsKey(key))
				return dicModules[key];
			return null;
		}

		public T Get<T>() where T : BaseModule
		{
			Type t = typeof(T);
			//return Get(t.ToString()) as T;
			if (dicModules.ContainsKey(t.ToString()))
			    return dicModules[t.ToString()] as T;
			return null;
		}

		//注册所有的数据
        public void RegisterAllModules()
		{
			LoadModule(typeof(TestOneModule));
			//LoadModule(typeof(MailModule));
			//.....add
		}
		
		private void LoadModule(Type moduleType)
		{
			BaseModule bm = System.Activator.CreateInstance(moduleType) as BaseModule;
			bm.Load();
		}

		public void Register(BaseModule module)
		{
			Type t = module.GetType();
			Register(t.ToString(), module);
		}

		public void Register(string key, BaseModule module)
		{
			if (!dicModules.ContainsKey(key))
				dicModules.Add(key, module);
		}

		public void UnRegister(BaseModule module)
		{
			Type t = module.GetType();
			UnRegister(t.ToString());
		}

		public void UnRegister(string key)
		{
			if (dicModules.ContainsKey(key))
			{
				BaseModule module = dicModules[key];
				module.Release();
				dicModules.Remove(key);
				module = null;
			}
		}

		public void UnRegisterAll()
		{
			List<string> _keyList = new List<string>(dicModules.Keys);
			for (int i=0; i<_keyList.Count; i++)
			{
				UnRegister(_keyList[i]);
			}
			dicModules.Clear();
		}

    }
}


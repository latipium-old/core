// AbstractLatipiumObject.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Com.Latipium.Core.Data;

namespace Com.Latipium.Core {
	/// <summary>
	/// Simple implementation of a LatipiumObject.
	/// </summary>
	public abstract class AbstractLatipiumObject : LatipiumObject {
		private static readonly Type AttributeType = typeof(LatipiumMethod);
		private readonly Dictionary<MemberDescriptor, Delegate> Methods;
		private readonly Dictionary<string, EventInfo> Events;
		private readonly Dictionary<string, LatipiumObject> Data;

		private T FindMethod<T>(string name) {
			MethodInfo[] methods = GetType().GetMethods(BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public);
			foreach ( MethodInfo method in methods ) {
				object[] attrs = method.GetCustomAttributes(AttributeType, true);
				foreach ( object attr in attrs ) {
					if ( ((LatipiumMethod) attr).Name == name ) {
						Delegate del = Delegate.CreateDelegate(typeof(T), this, method, false);
						if ( del != null ) {
							return (T) (object) del;
						}
					}
				}
			}
			return default(T);
		}

		private EventInfo FindEvent(string name) {
			EventInfo[] events = GetType().GetEvents(BindingFlags.Instance | BindingFlags.Public);
			foreach ( EventInfo ev in events ) {
				object[] attrs = ev.GetCustomAttributes(AttributeType, true);
				foreach ( object attr in attrs ) {
					if ( ((LatipiumMethod) attr).Name == name ) {
						return ev;
					}
				}
			}
			return null;
		}

		private T GetMethod<T>(string name) {
			MemberDescriptor desc = new MemberDescriptor();
			desc.Type = typeof(T);
			desc.Name = name;
			if ( Methods.ContainsKey(desc) ) {
				return (T) (object) Methods[desc];
			} else {
				Delegate del = (Delegate) (object) FindMethod<T>(name);
				return (T) (object) (Methods[desc] = del);
			}
		}

		private EventInfo GetEvent(string name) {
			if ( Events.ContainsKey(name) ) {
				return Events[name];
			} else {
				return Events[name] = FindEvent(name);
			}
		}

		public Action GetProcedure(string name) {
			return GetMethod<Action>(name);
		}

		public Action<T1> GetProcedure<T1>(string name) {
			return GetMethod<Action<T1>>(name);
		}

		public Action<T1, T2> GetProcedure<T1, T2>(string name) {
			return GetMethod<Action<T1, T2>>(name);
		}

		public Action<T1, T2, T3> GetProcedure<T1, T2, T3>(string name) {
			return GetMethod<Action<T1, T2, T3>>(name);
		}

		public Action<T1, T2, T3, T4> GetProcedure<T1, T2, T3, T4>(string name) {
			return GetMethod<Action<T1, T2, T3, T4>>(name);
		}

		public Func<TResult> GetFunction<TResult>(string name) {
			return GetMethod<Func<TResult>>(name);
		}

		public Func<T1, TResult> GetFunction<T1, TResult>(string name) {
			return GetMethod<Func<T1, TResult>>(name);
		}

		public Func<T1, T2, TResult> GetFunction<T1, T2, TResult>(string name) {
			return GetMethod<Func<T1, T2, TResult>>(name);
		}

		public Func<T1, T2, T3, TResult> GetFunction<T1, T2, T3, TResult>(string name) {
			return GetMethod<Func<T1, T2, T3, TResult>>(name);
		}

		public Func<T1, T2, T3, T4, TResult> GetFunction<T1, T2, T3, T4, TResult>(string name) {
			return GetMethod<Func<T1, T2, T3, T4, TResult>>(name);
		}

		public void InvokeProcedure(string name) {
			Action del = GetProcedure(name);
			if ( del != null ) {
				del();
			}
		}

		public void InvokeProcedure<T1>(string name, T1 arg1) {
			Action<T1> del = GetProcedure<T1>(name);
			if ( del != null ) {
				del(arg1);
			}
		}

		public void InvokeProcedure<T1, T2>(string name, T1 arg1, T2 arg2) {
			Action<T1, T2> del = GetProcedure<T1, T2>(name);
			if ( del != null ) {
				del(arg1, arg2);
			}
		}

		public void InvokeProcedure<T1, T2, T3>(string name, T1 arg1, T2 arg2, T3 arg3) {
			Action<T1, T2, T3> del = GetProcedure<T1, T2, T3>(name);
			if ( del != null ) {
				del(arg1, arg2, arg3);
			}
		}

		public void InvokeProcedure<T1, T2, T3, T4>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			Action<T1, T2, T3, T4> del = GetProcedure<T1, T2, T3, T4>(name);
			if ( del != null ) {
				del(arg1, arg2, arg3, arg4);
			}
		}

		public TResult InvokeFunction<TResult>(string name) {
			Func<TResult> del = GetFunction<TResult>(name);
			if ( del == null ) {
				return default(TResult);
			} else {
				return del();
			}
		}

		public TResult InvokeFunction<T1, TResult>(string name, T1 arg1) {
			Func<T1, TResult> del = GetFunction<T1, TResult>(name);
			if ( del == null ) {
				return default(TResult);
			} else {
				return del(arg1);
			}
		}

		public TResult InvokeFunction<T1, T2, TResult>(string name, T1 arg1, T2 arg2) {
			Func<T1, T2, TResult> del = GetFunction<T1, T2, TResult>(name);
			if ( del == null ) {
				return default(TResult);
			} else {
				return del(arg1, arg2);
			}
		}

		public TResult InvokeFunction<T1, T2, T3, TResult>(string name, T1 arg1, T2 arg2, T3 arg3) {
			Func<T1, T2, T3, TResult> del = GetFunction<T1, T2, T3, TResult>(name);
			if ( del == null ) {
				return default(TResult);
			} else {
				return del(arg1, arg2, arg3);
			}
		}

		public TResult InvokeFunction<T1, T2, T3, T4, TResult>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			Func<T1, T2, T3, T4, TResult> del = GetFunction<T1, T2, T3, T4, TResult>(name);
			if ( del == null ) {
				return default(TResult);
			} else {
				return del(arg1, arg2, arg3, arg4);
			}
		}

		public void AddEvent(string name, Delegate del) {
			GetEvent(name).AddEventHandler(this, del);
		}

		public void RemoveEvent(string name, Delegate del) {
			GetEvent(name).RemoveEventHandler(this, del);
		}

		public T GetData<T>(string name) where T:LatipiumObject {
			if ( Data.ContainsKey(name) ) {
				LatipiumObject data = Data[name];
				if ( data is T ) {
					return (T) data;
				} else {
					return default(T);
				}
			} else {
				return default(T);
			}
		}

		public void SetData<T>(string name, T val) where T:LatipiumObject {
			Data[name] = val;
		}

		public IEnumerable<Tuple<LatipiumObject, string>> GetData() {
			return Data.Keys.Select(key => new Tuple<LatipiumObject, string>(Data[key], key));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Core.AbstractLatipiumObject"/> class.
		/// </summary>
		public AbstractLatipiumObject() {
			Methods = new Dictionary<MemberDescriptor, Delegate>();
			Events = new Dictionary<string, EventInfo>();
			Data = new Dictionary<string, LatipiumObject>();
		}
	}
}


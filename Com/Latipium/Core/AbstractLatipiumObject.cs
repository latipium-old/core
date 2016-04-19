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

		/// <summary>
		/// Gets the delegate for a procedure.
		/// </summary>
		/// <returns>The procedure delegate.</returns>
		/// <param name="name">The name of the procedure.</param>
		public Action GetProcedure(string name) {
			return GetMethod<Action>(name);
		}

		/// <summary>
		/// Gets the delegate for a procedure.
		/// </summary>
		/// <returns>The procedure delegate.</returns>
		/// <param name="name">The name of the procedure.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		public Action<T1> GetProcedure<T1>(string name) {
			return GetMethod<Action<T1>>(name);
		}

		/// <summary>
		/// Gets the delegate for a procedure.
		/// </summary>
		/// <returns>The procedure delegate.</returns>
		/// <param name="name">The name of the procedure.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		public Action<T1, T2> GetProcedure<T1, T2>(string name) {
			return GetMethod<Action<T1, T2>>(name);
		}

		/// <summary>
		/// Gets the delegate for a procedure.
		/// </summary>
		/// <returns>The procedure delegate.</returns>
		/// <param name="name">The name of the procedure.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		/// <typeparam name="T3">The 3rd type parameter.</typeparam>
		public Action<T1, T2, T3> GetProcedure<T1, T2, T3>(string name) {
			return GetMethod<Action<T1, T2, T3>>(name);
		}

		/// <summary>
		/// Gets the delegate for a procedure.
		/// </summary>
		/// <returns>The procedure delegate.</returns>
		/// <param name="name">The name of the procedure.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		/// <typeparam name="T3">The 3rd type parameter.</typeparam>
		/// <typeparam name="T4">The 4th type parameter.</typeparam>
		public Action<T1, T2, T3, T4> GetProcedure<T1, T2, T3, T4>(string name) {
			return GetMethod<Action<T1, T2, T3, T4>>(name);
		}

		/// <summary>
		/// Gets the delegate for a function.
		/// </summary>
		/// <returns>The function delegate.</returns>
		/// <param name="name">The name of the function.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		public Func<TResult> GetFunction<TResult>(string name) {
			return GetMethod<Func<TResult>>(name);
		}

		/// <summary>
		/// Gets the delegate for a function.
		/// </summary>
		/// <returns>The function delegate.</returns>
		/// <param name="name">The name of the function.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		public Func<T1, TResult> GetFunction<T1, TResult>(string name) {
			return GetMethod<Func<T1, TResult>>(name);
		}

		/// <summary>
		/// Gets the delegate for a function.
		/// </summary>
		/// <returns>The function delegate.</returns>
		/// <param name="name">The name of the function.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		public Func<T1, T2, TResult> GetFunction<T1, T2, TResult>(string name) {
			return GetMethod<Func<T1, T2, TResult>>(name);
		}

		/// <summary>
		/// Gets the delegate for a function.
		/// </summary>
		/// <returns>The function delegate.</returns>
		/// <param name="name">The name of the function.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		/// <typeparam name="T3">The 3rd type parameter.</typeparam>
		public Func<T1, T2, T3, TResult> GetFunction<T1, T2, T3, TResult>(string name) {
			return GetMethod<Func<T1, T2, T3, TResult>>(name);
		}

		/// <summary>
		/// Gets the delegate for a function.
		/// </summary>
		/// <returns>The function delegate.</returns>
		/// <param name="name">The name of the function.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		/// <typeparam name="T3">The 3rd type parameter.</typeparam>
		/// <typeparam name="T4">The 4th type parameter.</typeparam>
		public Func<T1, T2, T3, T4, TResult> GetFunction<T1, T2, T3, T4, TResult>(string name) {
			return GetMethod<Func<T1, T2, T3, T4, TResult>>(name);
		}

		/// <summary>
		/// Invokes a procedure.
		/// It is perferred to use GetProcedure and cache the result over InvokeProcedure.
		/// </summary>
		/// <param name="name">The name of the procedure.</param>
		public void InvokeProcedure(string name) {
			Action del = GetProcedure(name);
			if ( del != null ) {
				del();
			}
		}

		/// <summary>
		/// Invokes a procedure.
		/// It is perferred to use GetProcedure and cache the result over InvokeProcedure.
		/// </summary>
		/// <param name="name">The name of the procedure.</param>
		/// <param name="arg1">The 1st argument.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		public void InvokeProcedure<T1>(string name, T1 arg1) {
			Action<T1> del = GetProcedure<T1>(name);
			if ( del != null ) {
				del(arg1);
			}
		}

		/// <summary>
		/// Invokes a procedure.
		/// It is perferred to use GetProcedure and cache the result over InvokeProcedure.
		/// </summary>
		/// <param name="name">The name of the procedure.</param>
		/// <param name="arg1">The 1st argument.</param>
		/// <param name="arg2">The 2nd argument.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		public void InvokeProcedure<T1, T2>(string name, T1 arg1, T2 arg2) {
			Action<T1, T2> del = GetProcedure<T1, T2>(name);
			if ( del != null ) {
				del(arg1, arg2);
			}
		}

		/// <summary>
		/// Invokes a procedure.
		/// It is perferred to use GetProcedure and cache the result over InvokeProcedure.
		/// </summary>
		/// <param name="name">The name of the procedure.</param>
		/// <param name="arg1">The 1st argument.</param>
		/// <param name="arg2">The 2nd argument.</param>
		/// <param name="arg3">The 3rd argument.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		/// <typeparam name="T3">The 3rd type parameter.</typeparam>
		public void InvokeProcedure<T1, T2, T3>(string name, T1 arg1, T2 arg2, T3 arg3) {
			Action<T1, T2, T3> del = GetProcedure<T1, T2, T3>(name);
			if ( del != null ) {
				del(arg1, arg2, arg3);
			}
		}

		/// <summary>
		/// Invokes a procedure.
		/// It is perferred to use GetProcedure and cache the result over InvokeProcedure.
		/// </summary>
		/// <param name="name">The name of the procedure.</param>
		/// <param name="arg1">The 1st argument.</param>
		/// <param name="arg2">The 2nd argument.</param>
		/// <param name="arg3">The 3rd argument.</param>
		/// <param name="arg4">The 4th argument.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		/// <typeparam name="T3">The 3rd type parameter.</typeparam>
		/// <typeparam name="T4">The 4th type parameter.</typeparam>
		public void InvokeProcedure<T1, T2, T3, T4>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			Action<T1, T2, T3, T4> del = GetProcedure<T1, T2, T3, T4>(name);
			if ( del != null ) {
				del(arg1, arg2, arg3, arg4);
			}
		}

		/// <summary>
		/// Invokes a function.
		/// It is perferred to use GetFunction and cache the result over InvokeFunction.
		/// </summary>
		/// <param name="name">The name of the function.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		public TResult InvokeFunction<TResult>(string name) {
			Func<TResult> del = GetFunction<TResult>(name);
			if ( del == null ) {
				return default(TResult);
			} else {
				return del();
			}
		}

		/// <summary>
		/// Invokes a function.
		/// It is perferred to use GetFunction and cache the result over InvokeFunction.
		/// </summary>
		/// <param name="name">The name of the function.</param>
		/// <param name="arg1">The 1st argument.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		public TResult InvokeFunction<T1, TResult>(string name, T1 arg1) {
			Func<T1, TResult> del = GetFunction<T1, TResult>(name);
			if ( del == null ) {
				return default(TResult);
			} else {
				return del(arg1);
			}
		}

		/// <summary>
		/// Invokes a function.
		/// It is perferred to use GetFunction and cache the result over InvokeFunction.
		/// </summary>
		/// <param name="name">The name of the function.</param>
		/// <param name="arg1">The 1st argument.</param>
		/// <param name="arg2">The 2nd argument.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		public TResult InvokeFunction<T1, T2, TResult>(string name, T1 arg1, T2 arg2) {
			Func<T1, T2, TResult> del = GetFunction<T1, T2, TResult>(name);
			if ( del == null ) {
				return default(TResult);
			} else {
				return del(arg1, arg2);
			}
		}

		/// <summary>
		/// Invokes a function.
		/// It is perferred to use GetFunction and cache the result over InvokeFunction.
		/// </summary>
		/// <param name="name">The name of the function.</param>
		/// <param name="arg1">The 1st argument.</param>
		/// <param name="arg2">The 2nd argument.</param>
		/// <param name="arg3">The 3rd argument.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		/// <typeparam name="T3">The 3rd type parameter.</typeparam>
		public TResult InvokeFunction<T1, T2, T3, TResult>(string name, T1 arg1, T2 arg2, T3 arg3) {
			Func<T1, T2, T3, TResult> del = GetFunction<T1, T2, T3, TResult>(name);
			if ( del == null ) {
				return default(TResult);
			} else {
				return del(arg1, arg2, arg3);
			}
		}

		/// <summary>
		/// Invokes a function.
		/// It is perferred to use GetFunction and cache the result over InvokeFunction.
		/// </summary>
		/// <param name="name">The name of the function.</param>
		/// <param name="arg1">The 1st argument.</param>
		/// <param name="arg2">The 2nd argument.</param>
		/// <param name="arg3">The 3rd argument.</param>
		/// <param name="arg4">The 4th argument.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		/// <typeparam name="T3">The 3rd type parameter.</typeparam>
		/// <typeparam name="T4">The 4th type parameter.</typeparam>
		public TResult InvokeFunction<T1, T2, T3, T4, TResult>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			Func<T1, T2, T3, T4, TResult> del = GetFunction<T1, T2, T3, T4, TResult>(name);
			if ( del == null ) {
				return default(TResult);
			} else {
				return del(arg1, arg2, arg3, arg4);
			}
		}

		/// <summary>
		/// Adds a delegate to an event.
		/// </summary>
		/// <param name="name">The event name.</param>
		/// <param name="del">The delegate.</param>
		public void AddEvent(string name, Delegate del) {
			GetEvent(name).AddEventHandler(this, del);
		}

		/// <summary>
		/// Removes a delegate from an event.
		/// </summary>
		/// <param name="name">The event name.</param>
		/// <param name="del">The delegate.</param>
		public void RemoveEvent(string name, Delegate del) {
			GetEvent(name).RemoveEventHandler(this, del);
		}

		/// <summary>
		/// Gets extension data stored with this object.
		/// </summary>
		/// <returns>The data.</returns>
		/// <param name="name">The name of the object.</param>
		/// <typeparam name="T">The type of data.</typeparam>
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

		/// <summary>
		/// Sets extension data stored with this object.
		/// </summary>
		/// <param name="name">The name of the object.</param>
		/// <param name="val">The data.</param>
		/// <typeparam name="T">The type of data.</typeparam>
		public void SetData<T>(string name, T val) where T:LatipiumObject {
			Data[name] = val;
		}

		/// <summary>
		/// Gets all sets of extension data.
		/// </summary>
		/// <returns>The data objects and their keys.</returns>
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


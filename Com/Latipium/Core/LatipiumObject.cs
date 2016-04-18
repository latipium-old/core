// LatipiumObject.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using System.Collections.Generic;

namespace Com.Latipium.Core {
	/// <summary>
	/// An object for Latipium that can be called from another assembly.
	/// </summary>
	public interface LatipiumObject {
		/// <summary>
		/// Gets the delegate for a procedure.
		/// </summary>
		/// <returns>The procedure delegate.</returns>
		/// <param name="name">The name of the procedure.</param>
		Action GetProcedure(string name);

		/// <summary>
		/// Gets the delegate for a procedure.
		/// </summary>
		/// <returns>The procedure delegate.</returns>
		/// <param name="name">The name of the procedure.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		Action<T1> GetProcedure<T1>(string name);

		/// <summary>
		/// Gets the delegate for a procedure.
		/// </summary>
		/// <returns>The procedure delegate.</returns>
		/// <param name="name">The name of the procedure.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		Action<T1, T2> GetProcedure<T1, T2>(string name);

		/// <summary>
		/// Gets the delegate for a procedure.
		/// </summary>
		/// <returns>The procedure delegate.</returns>
		/// <param name="name">The name of the procedure.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		/// <typeparam name="T3">The 3rd type parameter.</typeparam>
		Action<T1, T2, T3> GetProcedure<T1, T2, T3>(string name);

		/// <summary>
		/// Gets the delegate for a procedure.
		/// </summary>
		/// <returns>The procedure delegate.</returns>
		/// <param name="name">The name of the procedure.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		/// <typeparam name="T3">The 3rd type parameter.</typeparam>
		/// <typeparam name="T4">The 4th type parameter.</typeparam>
		Action<T1, T2, T3, T4> GetProcedure<T1, T2, T3, T4>(string name);

		/// <summary>
		/// Gets the delegate for a function.
		/// </summary>
		/// <returns>The function delegate.</returns>
		/// <param name="name">The name of the function.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		Func<TResult> GetFunction<TResult>(string name);

		/// <summary>
		/// Gets the delegate for a function.
		/// </summary>
		/// <returns>The function delegate.</returns>
		/// <param name="name">The name of the function.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		Func<T1, TResult> GetFunction<T1, TResult>(string name);

		/// <summary>
		/// Gets the delegate for a function.
		/// </summary>
		/// <returns>The function delegate.</returns>
		/// <param name="name">The name of the function.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		Func<T1, T2, TResult> GetFunction<T1, T2, TResult>(string name);

		/// <summary>
		/// Gets the delegate for a function.
		/// </summary>
		/// <returns>The function delegate.</returns>
		/// <param name="name">The name of the function.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		/// <typeparam name="T3">The 3rd type parameter.</typeparam>
		Func<T1, T2, T3, TResult> GetFunction<T1, T2, T3, TResult>(string name);

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
		Func<T1, T2, T3, T4, TResult> GetFunction<T1, T2, T3, T4, TResult>(string name);

		/// <summary>
		/// Invokes a procedure.
		/// It is perferred to use GetProcedure and cache the result over InvokeProcedure.
		/// </summary>
		/// <param name="name">The name of the procedure.</param>
		void InvokeProcedure(string name);

		/// <summary>
		/// Invokes a procedure.
		/// It is perferred to use GetProcedure and cache the result over InvokeProcedure.
		/// </summary>
		/// <param name="name">The name of the procedure.</param>
		/// <param name="arg1">The 1st argument.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		void InvokeProcedure<T1>(string name, T1 arg1);

		/// <summary>
		/// Invokes a procedure.
		/// It is perferred to use GetProcedure and cache the result over InvokeProcedure.
		/// </summary>
		/// <param name="name">The name of the procedure.</param>
		/// <param name="arg1">The 1st argument.</param>
		/// <param name="arg2">The 2nd argument.</param>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		/// <typeparam name="T2">The 2nd type parameter.</typeparam>
		void InvokeProcedure<T1, T2>(string name, T1 arg1, T2 arg2);

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
		void InvokeProcedure<T1, T2, T3>(string name, T1 arg1, T2 arg2, T3 arg3);

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
		void InvokeProcedure<T1, T2, T3, T4>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

		/// <summary>
		/// Invokes a function.
		/// It is perferred to use GetFunction and cache the result over InvokeFunction.
		/// </summary>
		/// <param name="name">The name of the function.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		TResult InvokeFunction<TResult>(string name);

		/// <summary>
		/// Invokes a function.
		/// It is perferred to use GetFunction and cache the result over InvokeFunction.
		/// </summary>
		/// <param name="name">The name of the function.</param>
		/// <param name="arg1">The 1st argument.</param>
		/// <typeparam name="TResult">The type of the return value.</typeparam>
		/// <typeparam name="T1">The 1st type parameter.</typeparam>
		TResult InvokeFunction<T1, TResult>(string name, T1 arg1);

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
		TResult InvokeFunction<T1, T2, TResult>(string name, T1 arg1, T2 arg2);

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
		TResult InvokeFunction<T1, T2, T3, TResult>(string name, T1 arg1, T2 arg2, T3 arg3);

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
		TResult InvokeFunction<T1, T2, T3, T4, TResult>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

		/// <summary>
		/// Adds a delegate to an event.
		/// </summary>
		/// <param name="name">The event name.</param>
		/// <param name="del">The delegate.</param>
		void AddEvent(string name, Delegate del);

		/// <summary>
		/// Removes a delegate from an event.
		/// </summary>
		/// <param name="name">The event name.</param>
		/// <param name="del">The delegate.</param>
		void RemoveEvent(string name, Delegate del);

		/// <summary>
		/// Gets extension data stored with this object.
		/// </summary>
		/// <returns>The data.</returns>
		/// <param name="name">The name of the object.</param>
		/// <typeparam name="T">The type of data.</typeparam>
		T GetData<T>(string name) where T:LatipiumObject;

		/// <summary>
		/// Sets extension data stored with this object.
		/// </summary>
		/// <param name="name">The name of the object.</param>
		/// <param name="val">The data.</param>
		/// <typeparam name="T">The type of data.</typeparam>
		void SetData<T>(string name, T val) where T:LatipiumObject;

		/// <summary>
		/// Gets all sets of extension data.
		/// </summary>
		/// <returns>The data objects and their keys.</returns>
		IEnumerable<Tuple<LatipiumObject, string>> GetData();
	}
}


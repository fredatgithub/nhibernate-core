﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Collections;
using NHibernate.Transform;
using NHibernate.Type;

namespace NHibernate
{
	using System.Threading.Tasks;
	using System.Threading;
	/// <content>
	/// Contains generated async methods
	/// </content>
	public partial interface IMultiQuery
	{
		/// <summary>
		/// Get all the results
		/// </summary>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <remarks>
		/// The result is a IList of IList.
		/// </remarks>
		Task<IList> ListAsync(CancellationToken cancellationToken = default(CancellationToken));

		/// <summary>
		/// Returns the result of one of the query based on the key
		/// </summary>
		/// <param name="key">The key</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <returns>The instance for method chain.</returns>
		Task<object> GetResultAsync(string key, CancellationToken cancellationToken = default(CancellationToken));
	}
}
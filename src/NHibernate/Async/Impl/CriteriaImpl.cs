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
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using NHibernate.Engine;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using NHibernate.Util;

namespace NHibernate.Impl
{
	using System.Threading.Tasks;
	using System.Threading;
	/// <content>
	/// Contains generated async methods
	/// </content>
	public partial class CriteriaImpl : ICriteria
	{

		public async Task<IList> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			var results = new List<object>();
			await (ListAsync(results, cancellationToken)).ConfigureAwait(false);
			return results;
		}

		public async Task ListAsync(IList results, CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			Before();
			try
			{
				await (session.ListAsync(this, results, cancellationToken)).ConfigureAwait(false);
			}
			finally
			{
				After();
			}
		}

		public async Task<IList<T>> ListAsync<T>(CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			List<T> results = new List<T>();
			await (ListAsync(results, cancellationToken)).ConfigureAwait(false);
			return results;
		}

		public async Task<T> UniqueResultAsync<T>(CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			object result = await (UniqueResultAsync(cancellationToken)).ConfigureAwait(false);
			if (result == null && typeof (T).IsValueType)
			{
				return default(T);
			}
			else
			{
				return (T) result;
			}
		}

		public async Task<IEnumerable<T>> FutureAsync<T>(CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			if (!session.Factory.ConnectionProvider.Driver.SupportsMultipleQueries)
			{
				return await (ListAsync<T>(cancellationToken)).ConfigureAwait(false);
			}

			session.FutureCriteriaBatch.Add<T>(this);
			return session.FutureCriteriaBatch.GetEnumerator<T>();
		}

		public async Task<object> UniqueResultAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			return AbstractQueryImpl.UniqueElement(await (ListAsync(cancellationToken)).ConfigureAwait(false));
		}
		/// <content>
		/// Contains generated async methods
		/// </content>
		public sealed partial class Subcriteria : ICriteria
		{

			public Task<IList> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled<IList>(cancellationToken);
				}
				return root.ListAsync(cancellationToken);
			}

			public Task<IEnumerable<T>> FutureAsync<T>(CancellationToken cancellationToken = default(CancellationToken))
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled<IEnumerable<T>>(cancellationToken);
				}
				return root.FutureAsync<T>(cancellationToken);
			}

			public Task ListAsync(IList results, CancellationToken cancellationToken = default(CancellationToken))
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled<object>(cancellationToken);
				}
				return root.ListAsync(results, cancellationToken);
			}

			public Task<IList<T>> ListAsync<T>(CancellationToken cancellationToken = default(CancellationToken))
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled<IList<T>>(cancellationToken);
				}
				return root.ListAsync<T>(cancellationToken);
			}

			public async Task<T> UniqueResultAsync<T>(CancellationToken cancellationToken = default(CancellationToken))
			{
				cancellationToken.ThrowIfCancellationRequested();
				object result = await (UniqueResultAsync(cancellationToken)).ConfigureAwait(false);
				if (result == null && typeof (T).IsValueType)
				{
					throw new InvalidCastException(
						"UniqueResult<T>() cannot cast null result to value type. Call UniqueResult<T?>() instead");
				}
				else
				{
					return (T) result;
				}
			}

			public Task<object> UniqueResultAsync(CancellationToken cancellationToken = default(CancellationToken))
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled<object>(cancellationToken);
				}
				return root.UniqueResultAsync(cancellationToken);
			}
		}
	}
}

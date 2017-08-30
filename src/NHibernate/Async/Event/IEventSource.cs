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
using NHibernate.Engine;
using NHibernate.Persister.Entity;

namespace NHibernate.Event
{
	using System.Threading.Tasks;
	using System.Threading;
	/// <content>
	/// Contains generated async methods
	/// </content>
	public partial interface IEventSource : ISessionImplementor, ISession
	{

		/// <summary> Force an immediate flush</summary>
		Task ForceFlushAsync(EntityEntry e, CancellationToken cancellationToken);

		/// <summary> Cascade merge an entity instance</summary>
		Task MergeAsync(string entityName, object obj, IDictionary copiedAlready, CancellationToken cancellationToken);

		/// <summary> Cascade persist an entity instance</summary>
		Task PersistAsync(string entityName, object obj, IDictionary createdAlready, CancellationToken cancellationToken);

		/// <summary> Cascade persist an entity instance during the flush process</summary>
		Task PersistOnFlushAsync(string entityName, object obj, IDictionary copiedAlready, CancellationToken cancellationToken);

		/// <summary> Cascade refresh an entity instance</summary>
		Task RefreshAsync(object obj, IDictionary refreshedAlready, CancellationToken cancellationToken);
        
		/// <summary> Cascade delete an entity instance</summary>
		Task DeleteAsync(string entityName, object child, bool isCascadeDeleteEnabled, ISet<object> transientEntities, CancellationToken cancellationToken);
	}
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Collections;

namespace NHibernate.Event
{
	using System.Threading.Tasks;
	using System.Threading;
	/// <content>
	/// Contains generated async methods
	/// </content>
	public partial interface IPersistEventListener
	{
		/// <summary> Handle the given create event.</summary>
		/// <param name="event">The create event to be handled.</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		Task OnPersistAsync(PersistEvent @event, CancellationToken cancellationToken);

		/// <summary> Handle the given create event. </summary>
		/// <param name="event">The create event to be handled.</param>
		/// <param name="createdAlready"></param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		Task OnPersistAsync(PersistEvent @event, IDictionary createdAlready, CancellationToken cancellationToken);
	}
}
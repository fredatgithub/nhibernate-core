﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using NHibernate.DomainModel.NHSpecific;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH864
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		[Test]
		public async Task OptimisticLockingAsync()
		{
			using (ISession s = OpenSession())
			{
				ObjectWithNullableInt32 obj = new ObjectWithNullableInt32();
				await (s.SaveAsync(obj));
				await (s.FlushAsync());

				obj.NullInt32 = 1;
				await (s.FlushAsync());

				obj.NullInt32 = NullableInt32.Default;
				await (s.FlushAsync());

				await (s.DeleteAsync(obj));
				await (s.FlushAsync());
			}
		}
	}
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.EntityNameAndCompositeId
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		protected override void OnTearDown()
		{
			using (ISession s = OpenSession())
			{
				using (ITransaction tx = s.BeginTransaction())
				{
					s.CreateSQLQuery("delete from Person").ExecuteUpdate();
					tx.Commit();
				}
			}
		}

		[Test]
		public async Task CanPersistAndReadAsync()
		{
			object id;
			using (ISession s = OpenSession())
			{
				using (ITransaction tx = s.BeginTransaction())
				{
					id = await (s.SaveAsync("Person", new Dictionary<string, object>
					                      	{
					                      		{"OuterId", new Dictionary<string, int> {{"InnerId", 1}}},
					                      		{"Data", "hello"}
					                      	}));
					await (tx.CommitAsync());
				}
			}
			using (ISession s = OpenSession())
			{
				using (s.BeginTransaction())
				{
					var p = (IDictionary) await (s.GetAsync("Person", id));
					Assert.AreEqual("hello", p["Data"]);
				}
			}
		}
	}
}
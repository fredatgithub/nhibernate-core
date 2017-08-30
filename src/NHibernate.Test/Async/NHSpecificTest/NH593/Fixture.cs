﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using NHibernate.Criterion;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH593
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		[Test]
		public void BugAsync()
		{
			using (ISession session = OpenSession())
			{
				User user = new User("test");
				user.UserId = 10;
				Assert.ThrowsAsync<QueryException>(() => session.CreateCriteria(typeof(Blog))
					.Add(Expression.In("Users", new User[] {user}))
					.ListAsync());
			}
		}
	}
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using NHibernate.Cfg;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH642
{
	using System.Threading.Tasks;
	using System.Threading;

	[TestFixture]
	public class FixtureAsync
	{
		private async Task DoTestAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
		{
			try
			{
				ISessionFactory factory =
					new Configuration().AddResource("NHibernate.Test.NHSpecificTest.NH642." + name + ".hbm.xml",
					                                typeof (FixtureAsync).Assembly).BuildSessionFactory();
				await (factory.CloseAsync(cancellationToken));
			}
			catch (MappingException me)
			{
				PropertyNotFoundException found = null;
				Exception find = me;
				while (find != null)
				{
					found = find as PropertyNotFoundException;
					find = find.InnerException;
				}
				Assert.IsNotNull(found, "The PropertyNotFoundException is not present in the Exception tree.");
			}
		}

		[Test]
		public Task MissingGetterAsync()
		{
			return DoTestAsync("MissingGetter");
		}

		[Test]
		public Task MissingSetterAsync()
		{
			return DoTestAsync("MissingSetter");
		}
	}
}
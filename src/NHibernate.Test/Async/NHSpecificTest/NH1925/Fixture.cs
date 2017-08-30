﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Collections;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH1925
{
	using System.Threading.Tasks;
	using System.Threading;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		protected override bool AppliesTo(Dialect.Dialect dialect)
		{
			return Dialect.SupportsScalarSubSelects;
		}

		private const string NAME_JOE = "Joe";
		private const string NAME_ALLEN = "Allen";

		protected override void OnSetUp()
		{
			base.OnSetUp();
			using (ISession session = OpenSession())
			{
				using (ITransaction tx = session.BeginTransaction())
				{
					var joe = new Customer {Name = NAME_JOE};
					session.Save(joe);

					var allen = new Customer {Name = NAME_ALLEN};
					session.Save(allen);

					var joeInvoice0 = new Invoice {Customer = joe, Number = 0};
					session.Save(joeInvoice0);

					var allenInvoice1 = new Invoice {Customer = allen, Number = 1};
					session.Save(allenInvoice1);

					tx.Commit();
				}
			}
		}

		protected override void OnTearDown()
		{
			using (ISession session = OpenSession())
			{
				using (ITransaction tx = session.BeginTransaction())
				{
					session.Delete("from Invoice");
					session.Delete("from Customer");
					tx.Commit();
				}
			}
			base.OnTearDown();
		}

		private async Task FindJoesLatestInvoiceAsync(string hql, CancellationToken cancellationToken = default(CancellationToken))
		{
			using (ISession session = OpenSession())
			{
				using (ITransaction tx = session.BeginTransaction())
				{
					IList list = await (session.CreateQuery(hql)
						.SetString("name", NAME_JOE)
						.ListAsync(cancellationToken));

					Assert.That(list, Is.Not.Empty);
					await (tx.CommitAsync(cancellationToken));
				}
			}
		}

		[Test]
		public Task Query1Async()
		{
			return FindJoesLatestInvoiceAsync(
				@"
                    select invoice
                    from Invoice invoice
                        join invoice.Customer customer
                    where
                        invoice.Number = (
                            select max(invoice2.Number) 
                            from 
                                invoice.Customer d2
                                    join d2.Invoices invoice2
                            where
                                d2 = customer
                        )
                        and customer.Name = :name
                ");
		}

		[Test]
		public Task Query2Async()
		{
			return FindJoesLatestInvoiceAsync(
				@"
                    select invoice
                    from Invoice invoice
                        join invoice.Customer customer
                    where
                        invoice.Number = (select max(invoice2.Number) from customer.Invoices invoice2)
                        and customer.Name = :name
                ");
		}
	}
}
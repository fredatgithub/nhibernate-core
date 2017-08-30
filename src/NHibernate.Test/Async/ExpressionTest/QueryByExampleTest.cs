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
using NHibernate.Criterion;
using NHibernate.DomainModel;
using NUnit.Framework;

namespace NHibernate.Test.ExpressionTest
{
	using System.Threading.Tasks;
	using System.Threading;
	[TestFixture]
	public class QueryByExampleTestAsync : TestCase
	{
		protected override IList Mappings
		{
			get { return new string[] {"Componentizable.hbm.xml"}; }
		}

		protected override void OnSetUp()
		{
			InitData();
		}

		protected override void OnTearDown()
		{
			DeleteData();
		}

		[Test]
		public async Task TestSimpleQBEAsync()
		{
			using (ISession s = OpenSession())
			using (ITransaction t = s.BeginTransaction())
			{
				Componentizable master = GetMaster("hibernate", null, "ope%");
				ICriteria crit = s.CreateCriteria(typeof(Componentizable));
				Example ex = Example.Create(master).EnableLike();
				crit.Add(ex);
				IList result = await (crit.ListAsync());
				Assert.IsNotNull(result);
				Assert.AreEqual(1, result.Count);
				await (t.CommitAsync());
			}
		}

		[Test]
		public async Task TestEnableLikeWithMatchmodeStartAsync()
		{
			using (ISession s = OpenSession())
			using (ITransaction t = s.BeginTransaction()) {
				Componentizable master = GetMaster("hib", null, "open source1");
				ICriteria crit = s.CreateCriteria(typeof(Componentizable));
				Example ex = Example.Create(master).EnableLike(MatchMode.Start);
				crit.Add(ex);
				IList result = await (crit.ListAsync());
				Assert.IsNotNull(result);
				Assert.AreEqual(1, result.Count);
				await (t.CommitAsync());
			}
		}

		[Test]
		public async Task TestEnableLikeWithMatchmodeEndAsync()
		{
			using (ISession s = OpenSession())
			using (ITransaction t = s.BeginTransaction()) {
				Componentizable master = GetMaster("nate", null, "ORM tool1");
				ICriteria crit = s.CreateCriteria(typeof(Componentizable));
				Example ex = Example.Create(master).EnableLike(MatchMode.End);
				crit.Add(ex);
				IList result = await (crit.ListAsync());
				Assert.IsNotNull(result);
				Assert.AreEqual(1, result.Count);
				await (t.CommitAsync());
			}
		}

		[Test]
		public async Task TestEnableLikeWithMatchmodeAnywhereAsync()
		{
			using (ISession s = OpenSession())
			using (ITransaction t = s.BeginTransaction()) {
				Componentizable master = GetMaster("bern", null, null);
				ICriteria crit = s.CreateCriteria(typeof(Componentizable));
				Example ex = Example.Create(master).EnableLike(MatchMode.Anywhere);
				crit.Add(ex);
				IList result = await (crit.ListAsync());
				Assert.IsNotNull(result);
				Assert.AreEqual(3, result.Count);
				await (t.CommitAsync());
			}
		}

		[Test]
		public async Task TestJunctionNotExpressionQBEAsync()
		{
			using (ISession s = OpenSession())
			using (ITransaction t = s.BeginTransaction())
			{
				Componentizable master = GetMaster("hibernate", null, "ope%");
				ICriteria crit = s.CreateCriteria(typeof(Componentizable));
				Example ex = Example.Create(master).EnableLike();


				crit.Add(Expression.Or(Expression.Not(ex), ex));

				IList result = await (crit.ListAsync());
				Assert.IsNotNull(result);
				//if ( !(dialect is HSQLDialect - h2.1 test

				Assert.AreEqual(2, result.Count, "expected 2 objects");
				await (t.CommitAsync());
			}
		}

		[Test]
		public async Task TestExcludingQBEAsync()
		{
			using (ISession s = OpenSession())
			using (ITransaction t = s.BeginTransaction())
			{
				Componentizable master = GetMaster("hibernate", null, "ope%");
				ICriteria crit = s.CreateCriteria(typeof(Componentizable));
				Example ex = Example.Create(master).EnableLike()
					.ExcludeProperty("Component.SubComponent");
				crit.Add(ex);
				IList result = await (crit.ListAsync());
				Assert.IsNotNull(result);
				Assert.AreEqual(3, result.Count);

				master = GetMaster("hibernate", "ORM tool", "fake stuff");
				crit = s.CreateCriteria(typeof(Componentizable));
				ex = Example.Create(master).EnableLike()
					.ExcludeProperty("Component.SubComponent.SubName1");
				crit.Add(ex);
				result = await (crit.ListAsync());
				Assert.IsNotNull(result);
				Assert.AreEqual(1, result.Count);
				await (t.CommitAsync());
			}
		}

		private async Task InitDataAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			using (ISession s = OpenSession())
			{
				Componentizable master = GetMaster("hibernate", "ORM tool", "ORM tool1");
				await (s.SaveAsync(master, cancellationToken));
				await (s.FlushAsync(cancellationToken));
			}

			using (ISession s = OpenSession())
			{
				Componentizable master = GetMaster("hibernate", "open source", "open source1");
				await (s.SaveAsync(master, cancellationToken));
				await (s.FlushAsync(cancellationToken));
			}

			using (ISession s = OpenSession())
			{
				Componentizable master = GetMaster("hibernate", null, null);
				await (s.SaveAsync(master, cancellationToken));
				await (s.FlushAsync(cancellationToken));
			}
		}

		private void InitData()
		{
			using (ISession s = OpenSession())
			{
				Componentizable master = GetMaster("hibernate", "ORM tool", "ORM tool1");
				s.Save(master);
				s.Flush();
			}

			using (ISession s = OpenSession())
			{
				Componentizable master = GetMaster("hibernate", "open source", "open source1");
				s.Save(master);
				s.Flush();
			}

			using (ISession s = OpenSession())
			{
				Componentizable master = GetMaster("hibernate", null, null);
				s.Save(master);
				s.Flush();
			}
		}

		private async Task DeleteDataAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			using (ISession s = OpenSession())
			using (ITransaction t = s.BeginTransaction())
			{
				await (s.DeleteAsync("from Componentizable", cancellationToken));
				await (t.CommitAsync(cancellationToken));
			}
		}

		private void DeleteData()
		{
			using (ISession s = OpenSession())
			using (ITransaction t = s.BeginTransaction())
			{
				s.Delete("from Componentizable");
				t.Commit();
			}
		}

		private Componentizable GetMaster(String name, String subName, String subName1)
		{
			Componentizable master = new Componentizable();
			if (name != null)
			{
				NHibernate.DomainModel.Component masterComp = new NHibernate.DomainModel.Component();
				masterComp.Name = name;
				if (subName != null || subName1 != null)
				{
					SubComponent subComponent = new SubComponent();
					subComponent.SubName = subName;
					subComponent.SubName1 = subName1;
					masterComp.SubComponent = subComponent;
				}
				master.Component = masterComp;
			}
			return master;
		}
	}
}
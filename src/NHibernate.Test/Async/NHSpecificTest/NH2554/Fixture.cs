﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH2554
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync: BugTestCase
	{
		protected override bool AppliesTo(NHibernate.Dialect.Dialect dialect)
		{
			return (dialect is NHibernate.Dialect.MsSql2005Dialect) || (dialect is NHibernate.Dialect.MsSql2008Dialect);
		}
		
		protected override void Configure(NHibernate.Cfg.Configuration configuration)
		{
			configuration.SetProperty(NHibernate.Cfg.Environment.Hbm2ddlKeyWords, "keywords");
			base.Configure(configuration);
		}
		
		protected override void OnSetUp()
		{
			base.OnSetUp();
			
			using (ISession session = Sfi.OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				session.Persist(new Student() { FullName = "Julian Maughan" });
				transaction.Commit();
			}
		}
		
		protected override void OnTearDown()
		{
			using (ISession session = Sfi.OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				session.CreateQuery("delete from Student").ExecuteUpdate();
				transaction.Commit();
			}
			
			base.OnTearDown();
		}
		
		[Test]
		public async Task TestMappedFormulasContainingSqlServerDataTypeKeywordsAsync()
		{
			using (ISession session = Sfi.OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				var students = await (session.CreateQuery("from Student").ListAsync<Student>());
				Assert.That(students.Count, Is.EqualTo(1));
				Assert.That(students[0].FullName, Is.EqualTo("Julian Maughan"));
				Assert.That(students[0].FullNameAsVarBinary.Length, Is.EqualTo(28));
				Assert.That(students[0].FullNameAsVarBinary512.Length, Is.EqualTo(28));
				// Assert.That(students[0].FullNameAsBinary.Length, Is.EqualTo(28)); 30???
				Assert.That(students[0].FullNameAsBinary256.Length, Is.EqualTo(256));
				Assert.That(students[0].FullNameAsVarChar.Length, Is.EqualTo(14));
				Assert.That(students[0].FullNameAsVarChar125.Length, Is.EqualTo(14));
				
				await (transaction.CommitAsync());
			}
		}
		
		[Test]
		public async Task TestHqlStatementsContainingSqlServerDataTypeKeywordsAsync()
		{
			using (ISession session = Sfi.OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				var students = await (session
					.CreateQuery("from Student where length(convert(varbinary, FullName)) = 28")
					.ListAsync<Student>());
				
				Assert.That(students.Count, Is.EqualTo(1));
				
				students = await (session
					.CreateQuery("from Student where length(convert(varbinary(256), FullName)) = 28")
					.ListAsync<Student>());
				
				Assert.That(students.Count, Is.EqualTo(1));
				
				students = await (session
					.CreateQuery("from Student where convert(int, 1) = 1")
					.ListAsync<Student>());
				
				Assert.That(students.Count, Is.EqualTo(1));
				
				await (transaction.CommitAsync());
			}
		}
	}
}

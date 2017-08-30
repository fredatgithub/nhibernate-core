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
using NHibernate.Dialect;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH1552
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		protected override bool AppliesTo(NHibernate.Dialect.Dialect dialect)
		{
			return dialect is MsSql2005Dialect;
		}
		protected override void OnSetUp()
		{
			using (var session = this.OpenSession())
			{
				using (var tran = session.BeginTransaction())
				{
					MyClass newServ = new MyClass();
					newServ.Name = "tuna";
                    MyClass newServ2 = new MyClass();
                    newServ2.Name = "sidar";
                    MyClass newServ3 = new MyClass();
                    newServ3.Name = "berker";
					session.Save(newServ);
                    session.Save(newServ2);
                    session.Save(newServ3);
					tran.Commit();
				}
			}
		}
		protected override void OnTearDown()
		{
			using (var session = this.OpenSession())
			{
				using (var tran = session.BeginTransaction())
				{
					session.Delete("from MyClass");
					tran.Commit();
				}
			}
		}

		[Test]
		public async Task Paging_with_sql_works_as_expected_with_FirstResultAsync()
		{
			using (var session = this.OpenSession())
			{
				using (var tran = session.BeginTransaction())
				{
					string sql = "select * from MyClass order by Name asc";
					IList<MyClass> list = await (session.CreateSQLQuery(sql)
						.AddEntity(typeof(MyClass))
						.SetFirstResult(1)
						.ListAsync<MyClass>());
					Assert.That(list.Count, Is.EqualTo(2));
				    Assert.That(list[0].Name, Is.EqualTo("sidar"));
                    Assert.That(list[1].Name, Is.EqualTo("tuna"));
				}
			}
		}

        [Test]
        public async Task Paging_with_sql_works_as_expected_with_MaxResultAsync()
        {
            using (var session = this.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    string sql = "select * from MyClass order by Name asc";
                    IList<MyClass> list = await (session.CreateSQLQuery(sql)
                        .AddEntity(typeof(MyClass))
                        .SetMaxResults(2)
                        .ListAsync<MyClass>());
                    Assert.That(list.Count, Is.EqualTo(2));
                    Assert.That(list[0].Name, Is.EqualTo("berker"));
                    Assert.That(list[1].Name, Is.EqualTo("sidar"));
                }
            }
        }


        [Test]
        public async Task Paging_with_sql_works_as_expected_with_FirstResultMaxResultAsync()
        {
            using (var session = this.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    string sql = "select * from MyClass";
                    IList<MyClass> list = await (session.CreateSQLQuery(sql)
                        .AddEntity(typeof(MyClass))
                        .SetFirstResult(1)
                        .SetMaxResults(1)
                        .ListAsync<MyClass>());
                    Assert.That(list.Count, Is.EqualTo(1));
                    Assert.That(list[0].Name, Is.EqualTo("sidar"));
                }
            }
        }
	}
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using NHibernate.Dialect;
using NHibernate.Type;
using NUnit.Framework;

namespace NHibernate.Test.TypesTest
{
	using System.Threading.Tasks;
	[TestFixture]
	public class CurrencyTypeFixtureAsync : TypeFixtureBase
	{
		protected override string TypeName
		{
			get { return "Currency"; }
		}

		[Test]
		public async Task ReadWriteAsync()
		{
			if (Dialect is Oracle8iDialect)
				Assert.Ignore("The Oracle dialect maps currency as Number(20, 2), this test can only fail.");

			const decimal expected = 5.6435M;

			var basic = new CurrencyClass {CurrencyValue = expected};
			ISession s = OpenSession();
			object savedId = await (s.SaveAsync(basic));
			await (s.FlushAsync());
			s.Close();

			s = OpenSession();
			basic = await (s.LoadAsync<CurrencyClass>(savedId));

			Assert.AreEqual(expected, basic.CurrencyValue);

			await (s.DeleteAsync(basic));
			await (s.FlushAsync());
			s.Close();
		}

	}
}
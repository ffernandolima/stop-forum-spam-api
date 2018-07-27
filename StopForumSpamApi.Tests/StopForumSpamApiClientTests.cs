using Microsoft.VisualStudio.TestTools.UnitTesting;
using StopForumSpamApi.Clients;
using StopForumSpamApi.Parameters;
using StopForumSpamApi.Threading;
using System.Threading.Tasks;

namespace StopForumSpamApi.Tests
{
	[TestClass]
	public class StopForumSpamApiClientTests
	{
		#region Fields

		private readonly IStopForumSpamApiClient _client = null;

		#endregion Fields

		#region Constants

		private const string Ip = "5.188.210.7";
		private const string Email = "asd@asd.com";
		private const string Username = "Targeted website visitors";

		#endregion Constants

		#region Ctor

		public StopForumSpamApiClientTests()
		{
			this._client = new StopForumSpamApiClient();
		}

		#endregion Ctor

		#region CheckIp

		[TestMethod]
		public void CheckIpTest()
		{
			var response = this._client.CheckIp(Ip);
			Assert.AreEqual(true, response.Successful);
		}

		[TestMethod]
		public async Task CheckIpAsyncTest()
		{
			var response = await this._client.CheckIpAsync(Ip);
			Assert.AreEqual(true, response.Successful);
		}

		[TestMethod]
		public async Task CheckIpAsyncWithTokenTest()
		{
			var token = CancellationTokenFactory.Token();
			var response = await this._client.CheckIpAsync(Ip, token);
			Assert.AreEqual(true, response.Successful);
		}

		#endregion CheckIp

		#region CheckEmail

		[TestMethod]
		public void CheckEmailTest()
		{
			var response = this._client.CheckEmail(Email);
			Assert.AreEqual(true, response.Successful);
		}

		[TestMethod]
		public async Task CheckEmailAsyncTest()
		{
			var response = await this._client.CheckEmailAsync(Email);
			Assert.AreEqual(true, response.Successful);
		}

		[TestMethod]
		public async Task CheckEmailAsyncWithTokenTest()
		{
			var token = CancellationTokenFactory.Token();
			var response = await this._client.CheckEmailAsync(Email, token);
			Assert.AreEqual(true, response.Successful);
		}

		#endregion CheckEmail

		#region CheckUsername

		[TestMethod]
		public void CheckUsernameTest()
		{
			var response = this._client.CheckUsername(Username);
			Assert.AreEqual(true, response.Successful);
		}

		[TestMethod]
		public async Task CheckUsernameAsyncTest()
		{
			var response = await this._client.CheckUsernameAsync(Username);
			Assert.AreEqual(true, response.Successful);
		}

		[TestMethod]
		public async Task CheckUsernameAsyncWithTokenTest()
		{
			var token = CancellationTokenFactory.Token();
			var response = await this._client.CheckUsernameAsync(Username, token);
			Assert.AreEqual(true, response.Successful);
		}

		#endregion CheckUsername

		#region Check

		[TestMethod]
		public void CheckTest()
		{
			var firstResponse = this._client.Check(Username, Email, Ip);
			Assert.AreEqual(true, firstResponse.Successful);

			var parameters = new CheckParameters { Username = Username, Email = Email, Ip = Ip };
			var secondResponse = this._client.Check(parameters);
			Assert.AreEqual(true, secondResponse.Successful);
		}

		[TestMethod]
		public async Task CheckAsyncTest()
		{
			var firstResponse = await this._client.CheckAsync(Username, Email, Ip);
			Assert.AreEqual(true, firstResponse.Successful);

			var parameters = new CheckParameters { Username = Username, Email = Email, Ip = Ip };
			var secondResponse = await this._client.CheckAsync(parameters);
			Assert.AreEqual(true, secondResponse.Successful);
		}

		[TestMethod]
		public async Task CheckAsyncWithTokenTest()
		{
			var token = CancellationTokenFactory.Token();

			var firstResponse = await this._client.CheckAsync(Username, Email, Ip, token);
			Assert.AreEqual(true, firstResponse.Successful);

			var parameters = new CheckParameters { Username = Username, Email = Email, Ip = Ip };
			var secondResponse = await this._client.CheckAsync(parameters, token);
			Assert.AreEqual(true, secondResponse.Successful);
		}

		#endregion Check
	}
}

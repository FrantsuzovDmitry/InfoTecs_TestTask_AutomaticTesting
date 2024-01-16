using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Infotecs_TestTask
{
	[TestFixture]
	public class ChangePasswordTest
	{
		private IWebDriver driver;
		private string url = "https://gosuslugi.ru";

		[SetUp]
		public void Setup()
		{
			// ������������� WebDriver (ChromeDriver)
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
		}

		[Test]
		public void ChangePasswordFormTest()
		{
			// ��� 1: ������� �� �������� gosuslugi.ru
			driver.Navigate().GoToUrl(url);

			// ��� 2: ������� ������ "�����"
			IWebElement loginButton = driver.FindElement(By.CssSelector(".login-button"));
			loginButton.Click();

			//// ��� 3: ������� ������ "�� ������� �����?"
			var unableToLoginButton = driver.FindElements(By.CssSelector(".plain-button-inline"))
									.SingleOrDefault(e => e.Text == "�� ������ �����?");
			unableToLoginButton?.Click();

			// ��� 4: ������� "�������������� ������"
			var passwordRecoveryButton = driver.FindElements(By.CssSelector(".plain-button-inline"))
									.SingleOrDefault(e => e.Text == "�������������� ������");
			passwordRecoveryButton?.Click();

			// ��� 5: ��������, ��� ��������� ����� "�������������� ������"
			IWebElement formLabel = driver.FindElement(By.CssSelector("h3"));
			bool areExistOfFormLabel = formLabel.Text == "�������������� ������";
			Assert.IsTrue(areExistOfFormLabel);
		}

		[TearDown]
		public void TearDown()
		{
			// �������� ��������
			driver.Quit();
		}
	}
}
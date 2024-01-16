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
			// Инициализация WebDriver (ChromeDriver)
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
		}

		[Test]
		public void ChangePasswordFormTest()
		{
			// Шаг 1: Переход на страницу gosuslugi.ru
			driver.Navigate().GoToUrl(url);

			// Шаг 2: Нажатие кнопки "Войти"
			IWebElement loginButton = driver.FindElement(By.CssSelector(".login-button"));
			loginButton.Click();

			//// Шаг 3: Нажатие кнопки "Не удается войти?"
			var unableToLoginButton = driver.FindElements(By.CssSelector(".plain-button-inline"))
									.SingleOrDefault(e => e.Text == "Не удаётся войти?");
			unableToLoginButton?.Click();

			// Шаг 4: Нажатие "Восстановление пароля"
			var passwordRecoveryButton = driver.FindElements(By.CssSelector(".plain-button-inline"))
									.SingleOrDefault(e => e.Text == "восстановления пароля");
			passwordRecoveryButton?.Click();

			// Шаг 5: Проверка, что открылась форма "Восстановление пароля"
			IWebElement formLabel = driver.FindElement(By.CssSelector("h3"));
			bool areExistOfFormLabel = formLabel.Text == "Восстановление пароля";
			Assert.IsTrue(areExistOfFormLabel);
		}

		[TearDown]
		public void TearDown()
		{
			// Закрытие браузера
			driver.Quit();
		}
	}
}
using LB_5_PP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace LB_5_PP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public IActionResult TaskFirst()
		{
			return View();
		}

		public IActionResult TaskSecond()
		{
			return View();
		}

		public IActionResult TaskThird()
		{
			return View();
		}



        [HttpPost]
        public IActionResult CountSpaces(string sentence)
        {
            int spaceCount = CountSpacesInSentence(sentence);
            ViewData["SpaceCount"] = spaceCount;
            return View("TaskFirst");
        }

        private int CountSpacesInSentence(string sentence)
        {
            if (sentence == null)
            {
                return 0;
            }

            int spaceCount = 0;
            foreach (char character in sentence)
            {
                if (char.IsWhiteSpace(character))
                {
                    spaceCount++;
                }
            }
            return spaceCount;
        }
        [HttpPost]
        public IActionResult Calculate(int N)
        {
            double result = CalculateExpression(N);
            ViewBag.Result = result;
            return View("TaskSecond");
        }

        private double CalculateExpression(int N)
        {
            double a1 = 1.1;
            double d = 0.1;
            double sum = 0;

            for (int i = 0; i < N; i++)
            {
                // Чередование знаков
                if (i % 2 == 0)
                    sum += a1 + i * d;
                else
                    sum -= a1 + i * d;
            }

            return sum;
        }
        [HttpPost]
        public ActionResult CheckWord(string inputWord)
        {
            bool isSameLetter = false;

            // Проверяем, начинается ли и заканчивается ли слово на одну и ту же букву
            if (!string.IsNullOrEmpty(inputWord) && inputWord.Length > 1)
            {
                char firstLetter = char.ToLower(inputWord[0]);
                char lastLetter = char.ToLower(inputWord[inputWord.Length - 1]);

                isSameLetter = (firstLetter == lastLetter);
            }

            // Передаем результат в представление
            ViewBag.IsSameLetter = isSameLetter;
            ViewBag.InputWord = inputWord;

            return View("TaskThird");
        }

    }
}
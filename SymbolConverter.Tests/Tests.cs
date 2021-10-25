namespace SymbolConverter.Tests
{
    using NUnit.Framework;

    using System.Text;
    using SymbolConverter;
    using System;
    using System.Collections.Generic;

    public class Tests
    {
        [Test]
        public void AllSingleSymbols_AllOpenBrackets()
        {
            var builder = new StringBuilder();
            for (var i = 'a'; i <= 'z'; i++)
            {
                builder.Append(i);
            }

            var output = Converter.Convert(builder.ToString());
            Assert.That(output, Is.All.EqualTo('('));
        }

        [Test]
        public void AllDuplicateSymbols_DuplicatesAreLowercase_AllClosedBrackets()
        {
            var builder = new StringBuilder();
            for (var i = 'a'; i <= 'z'; i++)
            {
                builder.Append(i);
                builder.Append(i);
            }

            var output = Converter.Convert(builder.ToString());
            Assert.That(output, Is.All.EqualTo(')'));
        }

        [Test]
        public void AllDuplicateSymbols_DuplicatesAreUppercase_AllClosedBrackets()
        {
            var builder = new StringBuilder();
            for (var i = 'a'; i <= 'z'; i++)
            {
                builder.Append(i);
                builder.Append(char.ToUpper(i));
            }

            var output = Converter.Convert(builder.ToString());
            Assert.That(output, Is.All.EqualTo(')'));
        }

        [TestCase("din", ExpectedResult = "(((")]
        [TestCase("recede", ExpectedResult = "()()()")]
        [TestCase("Success", ExpectedResult = ")())())")]
        [TestCase("(( @", ExpectedResult = "))((")]
        [Test]
        public string UnitTestsFromTask_Success(string input)
        {
            return Converter.Convert(input);
        }

        [Test]
        public void RandomStressTest_Success()
        {
            var random = new Random();
            var dict = new Dictionary<char, int>();
            var builder = new StringBuilder();
            var length = 1000000;

            for (var i = 0; i < length; i++)
            {
                var IsUpper = random.Next(0, 1) is 1;
                var symbol = IsUpper ? char.ToUpper((char)random.Next(0, 255)) : (char)random.Next(0, 255);

                if (!dict.ContainsKey(symbol))
                {
                    dict[symbol] = 0;
                }

                dict[symbol]++;
                builder.Append(symbol);
            }

            var data = builder.ToString();
            var actual = Converter.Convert(data);

            Assert.That(data.Length, Is.EqualTo(actual.Length));

            for(var i = 0; i < length; i++)
            {
                Assert.That(actual[i], Is.EqualTo(dict[data[i]] > 1 ? ')' : '('));
            }
        }
    }
}
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CxxDemangler.Tests.Parsing
{
    [TestClass]
    public class DestructorName : TestBase
    {
        [TestMethod]
        public void DestructorNameUnresolved()
        {
            Verify("S_...",
                new Parsers.DestructorName(
                    new Parsers.Substitution(0)));
        }

        [TestMethod]
        public void DestructorNameName()
        {
            Verify("3abc...",
                new Parsers.DestructorName(
                    new Parsers.SimpleId(
                        new Parsers.SourceName.Identifier("abc"),
                        arguments: null)));
        }

        [TestMethod]
        public void DestructorNameFailures()
        {
            Assert.IsNull(Parse("zzz"));
            Assert.IsNull(Parse(""));
        }

        internal override IParsingResult Parse(ParsingContext context)
        {
            return Parsers.DestructorName.Parse(context);
        }
    }
}

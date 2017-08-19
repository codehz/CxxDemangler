using CxxDemangler.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CxxDemangler.Tests
{
    [TestClass]
    public class MangledName : TestBase
    {
        [TestMethod]
        public void MangledNameData()
        {
            Verify("_Z3foo...",
                new SourceName.Identifier("foo"));
        }

        [TestMethod]
        public void MangledNameFailures()
        {
            Assert.IsNull(Parse("_Y"));
            Assert.IsNull(Parse("_"));
            Assert.IsNull(Parse(""));
        }

        internal override IParsingResult Parse(ParsingContext context)
        {
            return Parsers.MangledName.Parse(context);
        }
    }
}

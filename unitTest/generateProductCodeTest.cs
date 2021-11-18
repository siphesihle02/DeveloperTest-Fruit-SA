using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products;

namespace unitTest
{
    public class generateProductCodeTest
    {
        [TestClass]
        public class Tests
        {


            [TestCase(" 202105-023", "true")]
            [TestCase("200308-654", "true")]
            [TestCase("202111-675", "true")]
            public void ValidateProductCode_GivenDigitsNumber_ThenShouldReturnTrue(string id, string expected)
            {
                //Arrange
                GeneratedCode validate = new GeneratedCode();



                //Act
                var result = validate.checkCode(id);



                //Assert
                NUnit.Framework.Assert.AreEqual(expected, result);
            }
            [TestCase("HGF567", "true")]
            [TestCase("GHD768", "true")]
            [TestCase("YHF987", "true")]
            public void Check_CategoryCodeLengthEqualSix_ThenShouldReturnTrue(string id, string expected)
            {
                //Arrange
                GeneratedCode validate = new GeneratedCode();



                //Act
                var result = validate.ValidateLength(id);



                //Assert
                NUnit.Framework.Assert.AreEqual(expected, result);
            }


        }
    }
}
}

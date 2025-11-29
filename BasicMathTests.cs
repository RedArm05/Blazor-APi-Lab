using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
public class BasicMathTests

{

    [Fact]

    public void AddNumbers_ReturnsSum()

    {

        // Arrange

        int a = 2;

        int b = 3;


        // Act

        int result = a + b;


        // Assert

        Assert.Equal(5, result);

    }

}
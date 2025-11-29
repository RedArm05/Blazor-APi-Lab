
public class TextUtilitiesTests
{
    [Fact]
    public void NormalizeFact_NullInput_ReturnsFallback()
    {
        string? fact = null;
        string result = TextUtilities.NormalizeFact(fact);
        Assert.Equal("No fact available.", result);
    }

    [Fact]
    public void NormalizeFact_EmptyString_ReturnsFallback()
    {
        string fact = "";
        string result = TextUtilities.NormalizeFact(fact);
        Assert.Equal("No fact available.", result);
    }

    [Fact]
    public void NormalizeFact_MissingPeriod_AddsPeriod()
    {
        string fact = "Cats are cute";
        string result = TextUtilities.NormalizeFact(fact);
        Assert.Equal("Cats are cute.", result);
    }

    [Fact]
    public void NormalizeFact_ExistingPeriod_KeepsPeriod()
    {
        string fact = "Cats are cute.";
        string result = TextUtilities.NormalizeFact(fact);
        Assert.Equal("Cats are cute.", result);
    }

    [Fact]
    public void NormalizeFact_ExtraWhitespace_TrimsAndAddsPeriod()
    {
        string fact = "   Cats are fluffy   ";
        string result = TextUtilities.NormalizeFact(fact);
        Assert.Equal("Cats are fluffy.", result);
    }
}

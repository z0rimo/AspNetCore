using System.Security.Claims;
using System.Text.Json;
using Zolab.AspNetCore.Authentication.OAuth.Actions;

namespace Zolab.AspNetCore.Authentication.OAuth.Tests;

public class NestedJsonClaimActionTests
{
    private readonly string _claimType = "test-claim";
    private readonly string _valueType = ClaimValueTypes.String;
    private readonly string _jsonKey = "key1";
    private readonly string _subKey = "key2";
    private readonly string _thirdKey = "key3";
    private readonly string _issuer = "test-issuer";
    private readonly NestedJsonClaimAction _action;
    private readonly ClaimsIdentity _identity;

    public NestedJsonClaimActionTests()
    {
        _action = new NestedJsonClaimAction(_claimType, _valueType, _jsonKey, _subKey, _thirdKey);
        _identity = new ClaimsIdentity();
    }

    [Fact]
    public void Run_Should_Add_Claim_When_Keys_Found()
    {
        // Arrange
        var json = "{\"key1\":{\"key2\":{\"key3\":\"value\"}}}";
        var userData = JsonDocument.Parse(json).RootElement;

        // Act
        _action.Run(userData, _identity, _issuer);

        // Assert
        var claim = _identity.FindFirst(_claimType);
        Assert.NotNull(claim);
        Assert.Equal("value", claim.Value);
        Assert.Equal(_valueType, claim.ValueType);
        Assert.Equal(_issuer, claim.Issuer);
    }

    [Fact]
    public void Run_Should_Not_Add_Claim_When_Keys_Not_Found()
    {
        // Arrange
        var json = "{\"key1\":{\"key2\":{\"key4\":\"value\"}}}";
        var userData = JsonDocument.Parse(json).RootElement;

        // Act
        _action.Run(userData, _identity, _issuer);

        // Assert
        var claim = _identity.FindFirst(_claimType);
        Assert.Null(claim);
    }
}

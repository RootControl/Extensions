using Extensions;

namespace TestExtensions;

public class DictionaryTests
{
    private readonly VerifySettings _settings;
    
    public DictionaryTests()
    {
        _settings = new VerifySettings();
        _settings.UseDirectory("snapshots");
    }
    
    [Fact]
    public Task GetOrAdd_ShouldReturnNewValue_WhenValueDoesNotExistInDictionary()
    {
        // Arrange
        var dictionary = new Dictionary<string, string>();
        
        // Act
        var result = dictionary.GetOrAdd("key", "value");
        
        // Assert
        return Verify(result, _settings);
    }
    
    [Fact]
    public Task GetOrAdd_ShouldReturnValue_WhenValueExistsInDictionary()
    {
        // Arrange
        var dictionary = new Dictionary<string, string>
        {
            ["key"] = "value"
        };
        
        // Act
        var result = dictionary.GetOrAdd("key", "new value");
        
        // Assert
        return Verify(result, _settings);
    }
    
    [Fact]
    public Task TryUpdate_ShouldReturnFalse_WhenValueDoesNotExistInDictionary()
    {
        // Arrange
        var dictionary = new Dictionary<string, string>();
        
        // Act
        var result = dictionary.TryUpdate("key", "value");
        
        // Assert
        return Verify(result, _settings);
    }
    
    [Fact]
    public Task TryUpdate_ShouldReturnTrue_WhenValueExistsInDictionary()
    {
        // Arrange
        var dictionary = new Dictionary<string, string>
        {
            ["key"] = "value"
        };
        
        // Act
        var result = dictionary.TryUpdate("key", "new value");
        
        // Assert
        return Verify(result, _settings);
    }
}
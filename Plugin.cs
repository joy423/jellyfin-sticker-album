using JellyfinStickerAlbum.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using Microsoft.Extensions.Logging;

namespace JellyfinStickerAlbum;

/// <summary>
/// Jellyfin Sticker Album Plugin.
/// Tracks video watch time and awards collectible stickers based on viewing duration.
/// </summary>
public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
{
    public const string PluginName = "Sticker Album";
    private static readonly Guid PluginGuid = new("8c0f1f4a-8f4f-4c4f-9a3b-1f2e3d4c5b6a");

    private readonly ILogger<Plugin> _logger;

    public Plugin(
        IApplicationPaths applicationPaths,
        IXmlSerializer xmlSerializer,
        ILogger<Plugin> logger)
        : base(applicationPaths, xmlSerializer)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        Instance = this;
        _logger.LogInformation("[{Name}] Plugin initialised", Name);
    }

    /// <inheritdoc />
    public override string Name => PluginName;

    /// <inheritdoc />
    public override Guid Id => PluginGuid;

    /// <inheritdoc />
    public override string Description => "Sammle Sticker während du Videos in Jellyfin schaust!";

    /// <summary>Gets the current plugin instance.</summary>
    public static Plugin? Instance { get; private set; }

    /// <inheritdoc />
    public IEnumerable<PluginPageInfo> GetPages()
    {
        return new[]
        {
            new PluginPageInfo
            {
                Name                 = Name,
                EmbeddedResourcePath = GetType().Namespace + ".web.index.html",
                EnableInMainMenu     = true,
                MenuSection          = "server",
                MenuIcon             = "🎬",
                DisplayName          = "Sticker Album",
            }
        };
    }
}

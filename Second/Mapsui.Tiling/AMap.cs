using System.IO;
using BruTile.Cache;
using BruTile.Predefined;
using BruTile.Web;
using Mapsui.Tiling.Layers;

namespace Mapsui.Tiling;

public class AMap
{
    public static IPersistentCache<byte[]>? DefaultCache = null;

    private static readonly BruTile.Attribution OpenStreetMapAttribution = new(
        "© AMap contributors", "https://ditu.amap.com/copyright");

    public static TileLayer CreateTileLayer(string? userAgent = null)
    {
        userAgent ??= $"user-agent-of-{Path.GetFileNameWithoutExtension(System.AppDomain.CurrentDomain.FriendlyName)}";

        return new TileLayer(CreateTileSource(userAgent)) { Name = "OpenStreetMap" };
    }

    private static HttpTileSource CreateTileSource(string userAgent)
    {
        return new HttpTileSource(new GlobalSphericalMercator(),
            "https://wprd04.is.autonavi.com/appmaptile?size=1&style=7&x={x}&y={y}&z={z}",
            name: "AMap",
            attribution: OpenStreetMapAttribution, userAgent: userAgent, persistentCache: DefaultCache);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraMap;
using System.Drawing;
using System.IO;

namespace SbotControl.Core
{
    public class LocalProvider : MapDataProviderBase
    {
        readonly SphericalMercatorProjection projection = new SphericalMercatorProjection();
        public LocalProvider()
        {
            TileSource = new LocalTileSource(this);
        }
        public override ProjectionBase Projection
        {
            get
            {
                return projection;
            }
        }
        public override MapSize GetMapSizeInPixels(double zoomLevel)
        {
            double imageSize;
            imageSize = LocalTileSource.CalculateTotalImageSize(zoomLevel);
            return new MapSize(imageSize, imageSize);
        }
        protected override Size BaseSizeInPixels
        {
            get { return new Size(Convert.ToInt32(LocalTileSource.tileSize * 2), Convert.ToInt32(LocalTileSource.tileSize * 2)); }
        }
    }
    public class LocalTileSource : MapTileSourceBase
    {
        public const int tileSize = 256;
        public const int maxZoomLevel = 9;
        string directoryPath;
        internal static double CalculateTotalImageSize(double zoomLevel)
        {
            if (zoomLevel < 1.0)
                return zoomLevel * tileSize * 2;
            return Math.Pow(2.0, zoomLevel) * tileSize;
        }
        public LocalTileSource(ICacheOptionsProvider cacheOptionsProvider) : base((int)CalculateTotalImageSize(maxZoomLevel), (int)CalculateTotalImageSize(maxZoomLevel), tileSize, tileSize, cacheOptionsProvider)
        {
            //DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            //directoryPath = dir.Parent.Parent.FullName;
            DirectoryInfo dir = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\TMaps\\");
            directoryPath = dir.FullName;
        }
        public override Uri GetTileByZoomLevel(int zoomLevel, int tilePositionX, int tilePositionY)
        {
            if (zoomLevel <= maxZoomLevel)
            {
                Uri u = new Uri(string.Format("file://" + directoryPath + "sro_{0}_{1}_{2}.jpg", zoomLevel, tilePositionX, tilePositionY));
                return u;
            }
            return null;
        }
    }

}
